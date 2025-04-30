using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Implementation;
using System.Security.Claims;

namespace PropertyPro.Api.Controllers
{
    
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class CategoryController : AppControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;


        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet("Category")]
        public async Task<IActionResult> GetCategoriesListAsync()
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the GetCategoriesListAsync endpoint.");
            var response = await _categoryService.GetCategoriesListAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully retrieved the categories list.");
            }
            else
            {
                _logger.LogWarning($"User {username} failed to retrieve the categories list. Status: {response.Status}");
            }
            return NewResult(response);
        }

        [HttpPost("Category")]
        public async Task<IActionResult> AddCategoryAsync(string category)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the AddCategoryAsync endpoint.");
            var response = await _categoryService.AddCategoryAsync(category);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                _logger.LogInformation($"User {username} successfully added a new category.");
            }
            else
            {
                _logger.LogWarning($"User {username} failed to add a new category. Status: {response.Status}");
            }
            return NewResult(response);
        }

        [HttpDelete("Category/{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            // Get the username from the claims
            var username = User.FindFirstValue(ClaimTypes.Name);
            _logger.LogInformation($"User {username} is accessing the DeleteCategoryAsync endpoint.");
            var response = await _categoryService.DeleteCategoryAsync(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation($"User {username} successfully deleted the category with ID {id}.");
            }
            else
            {
                _logger.LogWarning($"User {username} failed to delete the category with ID {id}. Status: {response.Status}");
            }
            return NewResult(response);
        }
    }
}
