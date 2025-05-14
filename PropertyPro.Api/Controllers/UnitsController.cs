using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Units;
using System.Security.Claims;

namespace PropertyPro.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    

    public class UnitsController : AppControllerBase
    {
        private readonly IUnitService _unitService;
        private readonly ILogger<UnitsController> _logger;

        public UnitsController(IUnitService unitService, ILogger<UnitsController> logger)
        {
            _unitService = unitService;
            _logger = logger;
        }


        /// <summary>
        /// Get units with optional filters.
        /// </summary>
        /// <param name="hotDeals">Set to 1 to get only hot deals, 2 to ignore hot deals or 0 to ignore this filter.</param>
        [HttpGet]
        [Route("Get-All-Units")]
        public async Task<IActionResult> GetUnitsFilteredAsync([FromQuery] string search = "", int page = 1, int pageSize = 10,
                                                        int unitType = 0,
                                                        int userType = 0,
                                                        int minPrice = 0,
                                                        int maxPrice = 0,
                                                        int NumOfRooms = 0,
                                                        int NumOfBathrooms =0,
                                                        int hotDeals = 0)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the GetUnitsFilteredAsync endpoint.");
            var response = await _unitService.GetUnitsPaginatedListFilteredAsync(search, page, pageSize, unitType, userType, minPrice, maxPrice, NumOfRooms, NumOfBathrooms, hotDeals);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully fetch units list.");
            }
            else
            {
                _logger.LogError($"User {username} failed to Fetch units list. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpGet]
        [Route("Hot-Deals-Units")]
        public async Task<IActionResult> GetUnitsFilteredAsync([FromQuery] string search = "", 
                                                        int page = 1, 
                                                        int pageSize = 10, 
                                                        int minPrice = 0,
                                                        int maxPrice = 0)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the GetUnitsFilteredAsync endpoint.");
            var response = await _unitService.GetUnitsPaginatedListHotDealsAsync(search, page, pageSize, minPrice, maxPrice);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully fetch hot deals units list.");
            }
            else
            {
                _logger.LogError($"User {username} failed to Fetch hot deals units list. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUnitByIdAsync(int id)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the GetUnitByIdAsync endpoint.");
            var response = await _unitService.GetUnitByIdAsync(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully fetch unit with id {id}.");
            }
            else
            {
                _logger.LogError($"User {username} failed to Fetch unit with id {id}. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        [Route("Add-Unit")]
        public async Task<IActionResult> AddUnitAsync([FromForm]AddUnitDto unit)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is trying to add a unit.");
            var response = await _unitService.AddUnitAsync(unit);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully added a unit.");
            }
            else
            {
                _logger.LogError($"User {username} failed to add a unit. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPut]
        [Route("Upate-Unit")]
        public async Task<IActionResult> UpdateUnitAsync([FromForm] UpdateUnitDto unit)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is trying to update a unit.");
            var response = await _unitService.UpdateUnitAsync(unit);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully updated a unit.");
            }
            else
            {
                _logger.LogError($"User {username} failed to update a unit. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete]
        [Route("Delete-Unit/{id}")]
        public async Task<IActionResult> DeleteUnitByIdAsync(int id)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is trying to delete a unit with id {id}.");
            var response = await _unitService.DeleteUnitByIdAsync(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully deleted a unit with id {id}.");
            }
            else
            {
                _logger.LogError($"User {username} failed to delete a unit with id {id}. Error: {response.Message}");
            }
            return NewResult(response);
        }

    }
}
