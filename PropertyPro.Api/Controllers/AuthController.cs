using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Auth;
using PropertyPro.Service.Implementation;
using System.Security.Claims;

namespace PropertyPro.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : AppControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto registerDto)
        {
            // logging the registration attempt
            _logger.LogInformation($"User {registerDto.Email} is attempting to register.");
            var response = await _authService.RegisterAsync(registerDto);
            _logger.LogInformation($"{response.Message}");
            return NewResult(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            // logging the login attempt
            _logger.LogInformation($"User {loginDto.Email} is attempting to login.");
            var response = await _authService.LoginAsync(loginDto);
            _logger.LogInformation($"{response.Message}");
            return NewResult(response);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync(string email)
        {
            // logging the password reset attempt
            _logger.LogInformation($"User {email} is attempting to reset password.");
            var response = await _authService.ForgotPasswordAsync(email);
            _logger.LogInformation($"{response}");
            return Ok(response);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the ChangePasswordAsync endpoint.");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"User {username} failed to change password. Error: {ModelState}");
                return BadRequest(ModelState);
            }
            var result = await _authService.ChangePasswordAsync(changePasswordDto);
            if (!string.IsNullOrEmpty(result))
            {
                _logger.LogError($"User {username} failed to change password. Error: {result}");
                return BadRequest(result);
            }
            _logger.LogInformation($"User {username} successfully changed password.");
            return Ok("Password changed successfully.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add-role")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name) ?? "Unknown User";
            _logger.LogInformation("User {Username} is attempting to add a role.", username);

            if (!ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                _logger.LogWarning("Validation failed for {Username}. Errors: {Errors}", username, errors);
                return BadRequest(ModelState);
            }

            var result = await _authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
            {
                _logger.LogError($"User {username} failed to add role. Error: {result}");
                return BadRequest(result);
            }

            _logger.LogInformation($"User {username} successfully added role.");
            return Ok("Role added to user Successfully.");
        }


    }
}
