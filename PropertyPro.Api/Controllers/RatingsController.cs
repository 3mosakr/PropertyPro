using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Data.Models;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Ratings;
using PropertyPro.Service.Implementation;

namespace PropertyPro.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin, User")]

    public class RatingsController : AppControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }


        [HttpPost]
        public async Task<IActionResult> AddRateAsync(RatingDto rate)
        {
            var response = await _ratingService.AddOrUpdateRatingAsync(rate);
            return NewResult(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRateAsync(int unitId)
        {
            var response = await _ratingService.DeleteRatingAsync(unitId);
            return NewResult(response);
        }
    }
}
