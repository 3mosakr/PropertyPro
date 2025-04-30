using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Data.Models;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Ratings;
using PropertyPro.Service.Implementation;
using System.Security.Claims;

namespace PropertyPro.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin, User")]

    public class RatingsController : AppControllerBase
    {
        private readonly IRatingService _ratingService;
        private readonly ILogger<RatingsController> _logger;

        public RatingsController(IRatingService ratingService, ILogger<RatingsController> logger)
        {
            _ratingService = ratingService;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> AddRateAsync(RatingDto rate)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is trying to add a rating.");
            var response = await _ratingService.AddOrUpdateRatingAsync(rate);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully added a rating.");
            }
            else
            {
                _logger.LogError($"User {username} failed to add a rating. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRateAsync(int unitId)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is trying to delete a rating for unit {unitId}.");
            var response = await _ratingService.DeleteRatingAsync(unitId);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully deleted a rating for unit {unitId}.");
            }
            else
            {
                _logger.LogError($"User {username} failed to delete a rating for unit {unitId}. Error: {response.Message}");
            }
            return NewResult(response);
        }
    }
}
