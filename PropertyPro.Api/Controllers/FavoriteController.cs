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
