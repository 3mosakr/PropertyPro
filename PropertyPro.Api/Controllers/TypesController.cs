using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Implementation;
using System.Security.Claims;

namespace PropertyPro.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class TypesController : AppControllerBase
    {
        private readonly ITypesService _typesService;
        private readonly ILogger<TypesController> _logger;

        public TypesController(ITypesService typesService, ILogger<TypesController> logger)
        {
            _typesService = typesService;
            _logger = logger;
        }


        #region UserType

        [HttpGet("UserType")]
        public async Task<IActionResult> GetUserTypesListAsync()
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the GetUserTypesListAsync endpoint.");
            var response = await _typesService.GetUserTypesListAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully fetch user types list.");
            }
            else
            {
                _logger.LogError($"User {username} failed to Fetch user types list. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpPost("UserType")]
        public async Task<IActionResult> AddUserTypesAsync(string Type)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is trying to add a user type.");
            var response = await _typesService.AddUserTypeAsync(Type);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully added a user type.");
            }
            else
            {
                _logger.LogError($"User {username} failed to add a user type. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpDelete("UserType/{id}")]
        public async Task<IActionResult> DeleteUserTypesAsync(int id)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            var response = await _typesService.DeleteUserTypeAsync(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully deleted a user type.");
            }
            else
            {
                _logger.LogError($"User {username} failed to delete a user type. Error: {response.Message}");
            }
            return NewResult(response);
        }

        #endregion

        #region SaleType

        [HttpGet("SaleType")]
        public async Task<IActionResult> GetSaleTypesListAsync()
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the GetSaleTypesListAsync endpoint.");
            var response = await _typesService.GetSaleTypesListAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully fetch sale types list.");
            }
            else
            {
                _logger.LogError($"User {username} failed to Fetch sale types list. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpPost("SaleType")]
        public async Task<IActionResult> AddSaleTypeAsync(string Type)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is trying to add a sale type.");
            var response = await _typesService.AddSaleTypeAsync(Type);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully added a sale type.");
            }
            else
            {
                _logger.LogError($"User {username} failed to add a sale type. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpDelete("SaleType/{id}")]
        public async Task<IActionResult> DeleteSaleTypeAsync(int id)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            var response = await _typesService.DeleteSaleTypeAsync(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully deleted a sale type.");
            }
            else
            {
                _logger.LogError($"User {username} failed to delete a sale type. Error: {response.Message}");
            }
            return NewResult(response);
        }

        #endregion

        #region UnitType

        [HttpGet("UnitType")]
        public async Task<IActionResult> GetUnitTypesListAsync()
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            var response = await _typesService.GetUnitTypesListAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully fetch unit types list.");
            }
            else
            {
                _logger.LogError($"User {username} failed to Fetch unit types list. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpPost("UnitType")]
        public async Task<IActionResult> AddUnitTypeAsync(string Type)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is trying to add a unit type.");
            var response = await _typesService.AddUnitTypeAsync(Type);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully added a unit type.");
            }
            else
            {
                _logger.LogError($"User {username} failed to add a unit type. Error: {response.Message}");
            }
            return NewResult(response);
        }

        [HttpDelete("UnitType/{id}")]
        public async Task<IActionResult> DeleteUnitTypeAsync(int id)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is trying to delete a unit type.");
            var response = await _typesService.DeleteUnitTypeAsync(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully deleted a unit type.");
            }
            else
            {
                _logger.LogError($"User {username} failed to delete a unit type. Error: {response.Message}");
            }
            return NewResult(response);
        }

        #endregion
    }
}
