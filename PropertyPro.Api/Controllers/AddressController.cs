using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Api.Middleware;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Address;
using System.Security.Claims;

namespace PropertyPro.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class AddressController : AppControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly ILogger<AddressController> _logger;

        public AddressController(IAddressService addressService, ILogger<AddressController> logger)
        {
            _addressService = addressService;
            _logger = logger;
        }


        #region Governorate
        [HttpGet("Governorate")]
        public async Task<IActionResult> GetGovernorateListAsync()
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the Governorate list.");
            var response = await _addressService.GetGovernorateListAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"Governorate list retrieved successfully for user {username}.");
            }
            else
            {
                _logger.LogWarning($"Failed to retrieve Governorate list for user {username}. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpPost("Governorate")]
        public async Task<IActionResult> AddGovernorateAsync(string GovernorateName)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is adding a new Governorate: {GovernorateName}.");
            var response = await _addressService.AddGovernorateAsync(GovernorateName);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                _logger.LogInformation($"Governorate {GovernorateName} added successfully by user {username}.");
            }
            else
            {
                _logger.LogWarning($"Failed to add Governorate {GovernorateName} for user {username}. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpDelete("Governorate/{id}")]
        public async Task<IActionResult> DeleteGovernorateAsync(int id)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is deleting Governorate with ID: {id}.");
            var response = await _addressService.DeleteGovernorateAsync(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"Governorate with ID {id} deleted successfully by user {username}.");
            }
            else
            {
                _logger.LogWarning($"Failed to delete Governorate with ID {id} for user {username}. Error: {response.Message}");
            }
            return NewResult(response);
        }

        #endregion

        #region City
        [HttpGet("City")]
        public async Task<IActionResult> GetCitiesListAsync()
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the City list.");
            var response = await _addressService.GetCitiesListAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"City list retrieved successfully for user {username}.");
            }
            else
            {
                _logger.LogWarning($"Failed to retrieve City list for user {username}. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpGet("City-in-Governorate")]
        public async Task<IActionResult> GetCitiesInGovernorateListAsync(int governorateId)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the City list for Governorate ID: {governorateId}.");
            var response = await _addressService.GetCitiesInGovernorateListAsync(governorateId);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"City list for Governorate ID {governorateId} retrieved successfully for user {username}.");
            }
            else
            {
                _logger.LogWarning($"Failed to retrieve City list for Governorate ID {governorateId} for user {username}. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpPost("City")]
        public async Task<IActionResult> AddCityAsync(AddCityDto model)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is adding a new City: {model.CityName}.");
            var response = await _addressService.AddCityAsync(model);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                _logger.LogInformation($"City {model.CityName} added successfully by user {username}.");
            }
            else
            {
                _logger.LogWarning($"Failed to add City {model.CityName} for user {username}. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpDelete("City/{id}")]
        public async Task<IActionResult> DeleteCityAsync(int id)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is deleting City with ID: {id}.");
            var response = await _addressService.DeleteCityAsync(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"City with ID {id} deleted successfully by user {username}.");
            }
            else
            {
                _logger.LogWarning($"Failed to delete City with ID {id} for user {username}. Error: {response.Message}");
            }
            return NewResult(response);
        }
        #endregion

        #region Area
        [HttpGet("Area")]
        public async Task<IActionResult> GetAreasListAsync()
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the Area list.");
            var response = await _addressService.GetAreasListAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"Area list retrieved successfully for user {username}.");
            }
            else
            {
                _logger.LogWarning($"Failed to retrieve Area list for user {username}. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpGet("Area-in-City")]
        public async Task<IActionResult> GetAreasInCitiesListAsync(int CityId)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the Area list for City ID: {CityId}.");
            var response = await _addressService.GetAreasInCityListAsync(CityId);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"Area list for City ID {CityId} retrieved successfully for user {username}.");
            }
            else
            {
                _logger.LogWarning($"Failed to retrieve Area list for City ID {CityId} for user {username}. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpPost("Area")]
        public async Task<IActionResult> AddAreaAsync(AddAreaDto model)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is adding a new Area: {model.AreaName}.");
            var response = await _addressService.AddAreaAsync(model);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                _logger.LogInformation($"Area {model.AreaName} added successfully by user {username}.");
            }
            else
            {
                _logger.LogWarning($"Failed to add Area {model.AreaName} for user {username}. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpDelete("Area/{id}")]
        public async Task<IActionResult> DeleteAreaAsync(int id)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is deleting Area with ID: {id}.");
            var response = await _addressService.DeleteAreaAsync(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"Area with ID {id} deleted successfully by user {username}.");
            }
            else
            {
                _logger.LogWarning($"Failed to delete Area with ID {id} for user {username}. Error: {response.Message}");
            }
            return NewResult(response);
        }
        #endregion
    }
}
