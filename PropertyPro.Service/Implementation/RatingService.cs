using AutoMapper;
using Microsoft.AspNetCore.Http;
using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Reposatories.Abstraction;
using PropertyPro.Infrastructure.Responses;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Implementation
{
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public RatingService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<ResponseModel<Rating>> AddOrUpdateRatingAsync(RatingDto rate)
        {
            try
            {
                // user Id
                int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Validate input
                // Check if Rate exist with id
                var ExistingRate = await _unitOfWork.Ratings.GetRatingByIdAsync(userId, rate.UnitId);
                if (ExistingRate != null)
                {
                    if (ExistingRate.RatingValue != rate.RatingValue)
                    {
                        // update
                        var updatedRate = _mapper.Map(rate, ExistingRate);
                        var updatResult = await _unitOfWork.Ratings.UpdateAsync(updatedRate);

                        if (updatResult != null)
                            return new ResponseModel<Rating>([updatResult], "Rate Updated successfully");
                        return new ResponseModel<Rating>("Rating didn't Update now please try again later", false);
                    }
                    else
                    {
                        return new ResponseModel<Rating>("Rating is already exist", false);
                    }

                }

                rate.RatingValue = rate.RatingValue > 5 ? 5 : rate.RatingValue; 
                // mapping 
                var mappedRate = _mapper.Map<Rating>(rate);
                // Set user Id
                mappedRate.UserId = userId;
                // Add Rate Date
                mappedRate.RatingDate = DateTime.Now;
                // Add operation
                var result = await _unitOfWork.Ratings.AddAsync(mappedRate);
                // return response
                if (result != null)
                    return new ResponseModel<Rating>([result], "Rate Added successfully");
                return new ResponseModel<Rating>("Rating didn't added please try again later", false);

            }
            catch (Exception ex)
            {
                return new ResponseModel<Rating>
                {
                    Status = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    Errors = [ex.ToString()]
                };
            }
        }

        public async Task<ResponseModel<Rating>> DeleteRatingAsync( int unitId)
        {
            try
            {
                // user Id
                int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Check if Rate exist with id
                var ExistingRate = await _unitOfWork.Ratings.GetRatingByIdAsync(userId, unitId);
                if (ExistingRate != null)
                {
                    await _unitOfWork.Ratings.DeleteAsync(ExistingRate);
                    return new ResponseModel<Rating>([ExistingRate], "Rate deleted successfully.");
                }
                return new ResponseModel<Rating>
                {
                    Status = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Rating Not Found."
                };

            }
            catch (Exception ex)
            {
                return new ResponseModel<Rating>
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
