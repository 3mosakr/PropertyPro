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

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFavoriteAsync(int unitId)
        {

            var response = await _favoriteService.AddFavoriteAsync(unitId);
            return NewResult(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFavoriteAsync(int unitId)
        {
            var response = await _favoriteService.DeleteFavoriteAsync(unitId);
            return NewResult(response);
        }

    }
}
