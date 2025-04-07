

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Implementation;

namespace PropertyPro.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize(Roles ="Admin, User")]
    public class UsersController : AppControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var response = await _userService.GetUserByIdAsync(id);
            return NewResult(response);
        }

        [HttpGet]
        [Route("User-Posts")]
        public async Task<IActionResult> GetUserPostsByIdAsync(int id, int page = 1, int pageSize = 10)
        {
            var response = await _userService.GetUserPostsByIdAsync(id, page, pageSize);
            return NewResult(response);
        }

        [HttpGet]
        [Route("User-Favorits")]
        public async Task<IActionResult> GetUserFavoritsByIdAsync(int id, int page = 1, int pageSize = 10)
        {
            var response = await _userService.GetUserFavoritsByIdAsync(id, page, pageSize);
            return NewResult(response);
        }
    }
}
