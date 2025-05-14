using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Reposatories.Abstraction;
using PropertyPro.Infrastructure.Responses;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Favorites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Implementation
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public FavoriteService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<FavoriteDto>> GetAllFavoritesForUserAsync(int userId)
        {
            if (userId == 0)
            {
                // user Id
                int uId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                userId = uId;
            }

            var favorites = _unitOfWork.Favorites.GetFavoritsQuerableAsync().Result
                .Where(f => f.UserId == userId);

            var data = await _mapper.ProjectTo<FavoriteDto>(favorites).ToListAsync();
            if (favorites == null || !favorites.Any())
            {
                return new ResponseModel<FavoriteDto>
                {
                    Status = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "No favorites found for this user."
                };
            }
            return new ResponseModel<FavoriteDto>
            {
                Status = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Favorites retrieved successfully.",
                Data = data
            };
        }

        public async Task<ResponseModel<Favorite>> AddFavoriteAsync(int unitId)
        {
            
            try
            {
                // user Id
                int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

                // validate Input
                // Check if Favorite exist with id
                var ExistingFavorite = await _unitOfWork.Favorites.GetFavoriteByIdAsync(userId, unitId);
                if (ExistingFavorite != null)
                {
                    return new ResponseModel<Favorite>("Already exist.", false);
                }

                // mapping 
                Favorite mappedFavorite = new(userId,  unitId);
                // Add operation
                var result = await _unitOfWork.Favorites.AddAsync(mappedFavorite);
                // return response
                if (result != null)
                    return new ResponseModel<Favorite>([result], "Favorite Added successfully");
                return new ResponseModel<Favorite>("Favorite didn't added please try again later", false);

            }
            catch (Exception ex)
            {
                return new ResponseModel<Favorite>
                {
                    Status = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    Errors = [ex.ToString()]
                };
            }
        }

        public async Task<ResponseModel<Favorite>> DeleteFavoriteAsync(int unitId)
        {
            try
            {
                // user Id
                int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Check if Favorite exist with id
                var ExistingFavorite = await _unitOfWork.Favorites.GetFavoriteByIdAsync(userId, unitId);
                if (ExistingFavorite != null)
                {
                    await _unitOfWork.Favorites.DeleteAsync(ExistingFavorite);
                    return new ResponseModel<Favorite>([ExistingFavorite], "Favorite deleted successfully.");
                }
                return new ResponseModel<Favorite>
                {
                    Status = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Favorite Not Found."
                };

            }
            catch (Exception ex)
            {
                return new ResponseModel<Favorite>
                {
                    Status = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    Errors = [ex.ToString()]
                };
            }
        }

        
    }
}
