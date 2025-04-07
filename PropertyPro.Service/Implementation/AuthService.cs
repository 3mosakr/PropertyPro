using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Responses;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Auth;
using PropertyPro.Service.Helper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IMapper _mapper;
        private readonly JWT _jwt;
        private readonly IImageManagementService _imageManagementService;


        public AuthService(UserManager<User> userManager, IMapper mapper, RoleManager<IdentityRole<int>> roleManager, JWT jwt, IImageManagementService imageManagementService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _jwt = jwt;
            _imageManagementService = imageManagementService;
        }

        public async Task<ResponseModel<AuthModel>> RegisterAsync(RegisterDto model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new ResponseModel<AuthModel>("Email is already registered!", false);

            if (await _userManager.FindByNameAsync(model.UserName) is not null)
                return new ResponseModel<AuthModel>("UserName is already registered!", false);
            
            if (await _userManager.Users.SingleOrDefaultAsync(u => u.PhoneNumber.Equals(model.PhoneNumber)) is not null)
                return new ResponseModel<AuthModel>("Phone Number is already registered!", false);

            // mappping dto to model
            var user = _mapper.Map<User>(model);

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new ResponseModel<AuthModel>("Failed to register user!", false, result.Errors.Select(e => e.Description).ToList());

            // add user photo to server
            if (model.Photo != null)
            {
                // Add Images to server and DB
                var ImagePath = await _imageManagementService.AddUserImageAsync(model.Photo, user.Id.ToString());
                user.Photo = ImagePath;
            }
            // add User Role
            await _userManager.AddToRoleAsync(user, "User");

            var jwtSecurityToken = await CreateJwtToken(user);

            var response = new AuthModel
            {
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName
            };

            return new ResponseModel<AuthModel>([response], "User registered successfully!");
        }

        

        public async Task<ResponseModel<AuthModel>> LoginAsync(LoginDto model)
        {
            var authModel = new AuthModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                // unauthorized
                return new ResponseModel<AuthModel>([authModel], "Email or Password is incorrect!")
                {
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    Status = false
                };
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            return new ResponseModel<AuthModel>([authModel]);
        }

        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim(ClaimTypes.Role, role));

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;
        }

    }
}
