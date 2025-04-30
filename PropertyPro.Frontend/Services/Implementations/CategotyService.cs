using PropertyPro.Frontend.Models;
using PropertyPro.Frontend.Models.Response;
using PropertyPro.Frontend.Services.Interfaces;
using System.Text.Json;

namespace PropertyPro.Frontend.Services.Implementations
{
    public class CategotyService : ICategotyService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly IAuthService _authService;

        public CategotyService(HttpClient httpClient, IAuthService authService)
        {
            _baseUrl = $"{Const.BaseUrl}/Category";
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<ResponseModel<Category>> GetCategoriesListAsync()
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Get, $"{_baseUrl}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<Category>>(content, options)
                       ?? new ResponseModel<Category> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<Category> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<ResponseModel<Category>> AddCategoryAsync(string category)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Post, $"{_baseUrl}?category={category}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<Category>>(content, options)
                       ?? new ResponseModel<Category> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<Category> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Delete, $"{_baseUrl}/{id}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete Category: {ex.Message}");
            }
        }

        
    }
}
