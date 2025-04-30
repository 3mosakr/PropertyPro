using PropertyPro.Frontend.Models;
using PropertyPro.Frontend.Models.Auth;
using PropertyPro.Frontend.Models.Response;
using PropertyPro.Frontend.Models.User;
using PropertyPro.Frontend.Services.Interfaces;
using System.Net;
using System.Text.Json;

namespace PropertyPro.Frontend.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly IAuthService _authService;

        public UserService(HttpClient httpClient, IAuthService authService)
        {
            _baseUrl = $"{Const.BaseUrl}/Users";
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<string> AddUserRoleAsync(AddRoleModel model)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Post, $"{Const.BaseUrl}/Auth/add-role", model);
                var response = await _httpClient.SendAsync(request);

                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return !string.IsNullOrWhiteSpace(content) ? content : "Role added successfully.";
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return !string.IsNullOrWhiteSpace(content) ? $"Bad Request: {content}" : "Bad Request while adding role.";
                }
                else
                {
                    return $"Unexpected error: {response.StatusCode} - {content}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred while adding role: {ex.Message}");
                return $"Exception: {ex.Message}";
            }
        }


        public async Task<ResponseModel<AuthModel>> CreateUserAsync(MultipartFormDataContent model)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Post, $"{Const.BaseUrl}/Auth/register", model);
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<AuthModel>>(content, options)
                    ?? new PaginatedResult<AuthModel> { Message = "Unexpected null response!" };

            }
            catch (Exception ex)
            {
                return new ResponseModel<AuthModel> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<PaginatedResult<UserDto>> GetUsersListAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Get, $"{_baseUrl}?page={page}&pageSize={pageSize}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<PaginatedResult<UserDto>>(content, options)
                       ?? new PaginatedResult<UserDto> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new PaginatedResult<UserDto> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<ResponseModel<bool>> LockUnlockUserAsync(int id)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Post, $"{_baseUrl}/lock-unlock-user/{id}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<bool>>(content, options)
                    ?? new PaginatedResult<bool> { Message = "Unexpected null response!" };

            }
            catch (Exception ex)
            {
                return new ResponseModel<bool> { Message = $"Error: {ex.Message}" };
            }
        }
    }
}
