using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Favorites;
using System.Security.Claims;

namespace PropertyPro.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin, User")]

    public class FavoriteController : AppControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        private readonly ILogger<FavoriteController> _logger;

        public FavoriteController(IFavoriteService favoriteService, ILogger<FavoriteController> logger)
        {
            _favoriteService = favoriteService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieve the favorite units list of user.
        /// </summary>
        /// <param name="userId"> Default Value 0 will get the favorite units list for the signed in user,
        /// if you need spacific user enter his id.</param>
        /// <returns> retrive list if found contains the unit Id and Unit Title</returns>
        [HttpGet]
        [Route("Get-Favorites/{userId:int}")]
        public async Task<IActionResult> GetFavoritesAsync(int userId = 0)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is trying to get favorites");
            var response = await _favoriteService.GetAllFavoritesForUserAsync(userId);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully retrieved favorites");
            }
            else
            {
                _logger.LogWarning($"User {username} failed to retrieve favorites. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddFavoriteAsync(int unitId)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is trying to add a favorite with unitId: {unitId}");
            var response = await _favoriteService.AddFavoriteAsync(unitId);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully added a favorite with unitId: {unitId}");
            }
            else
            {
                _logger.LogWarning($"User {username} failed to add a favorite with unitId: {unitId}. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFavoriteAsync(int unitId)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is trying to delete a favorite with unitId: {unitId}");
            var response = await _favoriteService.DeleteFavoriteAsync(unitId);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully deleted a favorite with unitId: {unitId}");
            }
            else
            {
                _logger.LogWarning($"User {username} failed to delete a favorite with unitId: {unitId}. Error: {response.Message}");
            }
            return NewResult(response);
        }

    }
}
