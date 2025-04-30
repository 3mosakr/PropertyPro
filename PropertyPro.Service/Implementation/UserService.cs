using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Reposatories.Abstraction;
using PropertyPro.Infrastructure.Responses;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.AppUser;
using PropertyPro.Service.Dto.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public UserService(UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel<GetUserByIdDto>> GetUserByIdAsync(int id)
        {
            var user = await _userManager.Users
                                         .AsNoTracking()
                                         .Include(u => u.UserType)
                                         .FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
                return new ResponseModel<GetUserByIdDto>("", false);

            var result = _mapper.Map<GetUserByIdDto>(user);
            return new ResponseModel<GetUserByIdDto>([result]);

        }


        public async Task<ResponseModel<GetUserByIdDto>> GetUsersListAsync(int page = 1, int pageSize = 10)
        {
            var users = _userManager.Users
                .AsNoTracking()
                .Include(u => u.UserType)
                .Select(u => new GetUserByIdDto
                {
                    Id = u.Id,
                    FullName = u.FirstName + " " + u.LastName,
                    Email = u.Email,
                    Address = u.Address,
                    UserType = u.UserType.Type,
                    LockoutEnd = u.LockoutEnd,
                    Photo = u.Photo
                });

            if (users is null)
                return new ResponseModel<GetUserByIdDto>("", false);

            // mapping
            var paginatedList = await users
                .ToPaginatedListAsync(page, pageSize);
            return paginatedList;
        }

        public async Task<ResponseModel<UserPostsDto>> GetUserPostsByIdAsync(int id, int page, int pageSize)
        {
            var posts = await _unitOfWork.Units.GetUnitsQuerableAsync();
            if (posts is null)
                return new ResponseModel<UserPostsDto>("", false);

            posts = posts.Where(u => u.UserId == id);
            // mapping
            var paginatedList = await _mapper
            .ProjectTo<UserPostsDto>(posts)
            .ToPaginatedListAsync(page, pageSize);

            return paginatedList;
        }

        public async Task<ResponseModel<UserFavoritsDto>> GetUserFavoritsByIdAsync(int id, int page, int pageSize)
        {
            var favorits = await _unitOfWork.Favorites.GetFavoritsQuerableAsync();
            if (favorits is null)
                return new ResponseModel<UserFavoritsDto>("", false);
            favorits = favorits.Where(f => f.UserId == id);

            // mapping
            var paginatedList = await _mapper
            .ProjectTo<UserFavoritsDto>(favorits)
            .ToPaginatedListAsync(page, pageSize);

            return paginatedList;
        }

        public async Task<ResponseModel<bool>> LockUnlockUserAsync(int id)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
                return new ResponseModel<bool>("", false);
            if (user.LockoutEnd != null && user.LockoutEnd > DateTime.UtcNow)
            {
                user.LockoutEnd = null;
                await _userManager.UpdateAsync(user);
                return new ResponseModel<bool>("User unlocked successfully", true);
            }
            else
            {
                user.LockoutEnd = DateTime.UtcNow.AddDays(10);
                await _userManager.UpdateAsync(user);
                return new ResponseModel<bool>("User locked successfully", true);
            }

        }
    }
}
