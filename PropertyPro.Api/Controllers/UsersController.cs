

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Implementation;
using System.Security.Claims;

namespace PropertyPro.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize(Roles ="Admin, User")]
    public class UsersController : AppControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the GetUserByIdAsync endpoint with ID: {id}.");
            var response = await _userService.GetUserByIdAsync(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully fetch user with id.");
            }
            else
            {
                _logger.LogError($"User {username} failed to Fetch user with id. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetUsersListAsync(int page = 1, int pageSize = 10)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the GetUsersListAsync endpoint.");
            var response = await _userService.GetUsersListAsync(page, pageSize);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully fetch users list.");
            }
            else
            {
                _logger.LogError($"User {username} failed to Fetch users list. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpGet]
        [Route("User-Posts")]
        public async Task<IActionResult> GetUserPostsByIdAsync(int id, int page = 1, int pageSize = 10)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the GetUserPostsByIdAsync endpoint with ID: {id}.");
            var response = await _userService.GetUserPostsByIdAsync(id, page, pageSize);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully fetch user posts with id.");
            }
            else
            {
                _logger.LogError($"User {username} failed to Fetch user posts with id. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpGet]
        [Route("User-Favorits")]
        public async Task<IActionResult> GetUserFavoritsByIdAsync(int id, int page = 1, int pageSize = 10)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the GetUserFavoritsByIdAsync endpoint with ID: {id}.");
            var response = await _userService.GetUserFavoritsByIdAsync(id, page, pageSize);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully fetch user favorits with id.");
            }
            else
            {
                _logger.LogError($"User {username} failed to Fetch user favorits with id. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("lock-unlock-user/{id}")]
        public async Task<IActionResult> LockUnlockUserAsync(int id)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the LockUnlockUserAsync endpoint with ID: {id}.");
            var response = await _userService.LockUnlockUserAsync(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully lock/unlock user with id.");
            }
            else
            {
                _logger.LogError($"User {username} failed to lock/unlock user with id. Error: {response.Message}");
            }
            return NewResult(response);
        }


    }
}
