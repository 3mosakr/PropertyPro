using PropertyPro.Frontend.Models;
using PropertyPro.Frontend.Models.Response;
using PropertyPro.Frontend.Models.Unit;
using PropertyPro.Frontend.Services.Interfaces;
using System.Text.Json;

namespace PropertyPro.Frontend.Services.Implementations
{
    public class UnitService : IUnitService
    {

        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly IAuthService _authService;

        public UnitService(HttpClient httpClient, IAuthService authService)
        {
            _baseUrl = $"{Const.BaseUrl}/Units";
            _httpClient = httpClient;
            _authService = authService;
        }
        

        

        public async Task<PaginatedResult<GetUnitsForListingDto>> GetUnitsPaginatedListFilteredAsync(string search, int page, int pageSize, int unitType, int userType, int minPrice, int maxPrice, int NumOfRooms, int NumOfBathrooms)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Get, $"{_baseUrl}/Get-All-Units?page={page}&pageSize={pageSize}&unitType=0&userType=0&minPrice=0&maxPrice=0&NumOfRooms=0&NumOfBathrooms=0");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<PaginatedResult<GetUnitsForListingDto>>(content, options)
                       ?? new PaginatedResult<GetUnitsForListingDto> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new PaginatedResult<GetUnitsForListingDto> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task DeleteUnitByIdAsync(int id)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Delete, $"{_baseUrl}/Delete-Unit/{id}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete Category: {ex.Message}");
            }
        }

        public async Task<ResponseModel<AddUnitDto>> AddUnitAsync(AddUnitDto addUnit)
        {
            try
            {
                
                var request = await _authService.CreateRequestMessage(HttpMethod.Post, $"{_baseUrl}/Add-Unit", addUnit);
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<AddUnitDto>>(content, options)
                       ?? new ResponseModel<AddUnitDto> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<AddUnitDto> { Message = $"Error: {ex.Message}" };
            }
        }
        
        public async Task<ResponseModel<AddUnitDto>> AddUnitFormAsync(MultipartFormDataContent formContent)
        {
            try
            {
                
                var request = await _authService.CreateRequestMessage(HttpMethod.Post, $"{_baseUrl}/Add-Unit", formContent);
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<AddUnitDto>>(content, options)
                       ?? new ResponseModel<AddUnitDto> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<AddUnitDto> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<ResponseModel<UpdateUnitDto>> UpdateUnitAsync(MultipartFormDataContent formContent)
        {
            try
            {

                var request = await _authService.CreateRequestMessage(HttpMethod.Put, $"{_baseUrl}/Upate-Unit", formContent);
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<UpdateUnitDto>>(content, options)
                       ?? new ResponseModel<UpdateUnitDto> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<UpdateUnitDto> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<ResponseModel<GetUnitByIdDto>> GetUnitByIdAsync(int id)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Get, $"{_baseUrl}/{id}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<PaginatedResult<GetUnitByIdDto>>(content, options)
                       ?? new PaginatedResult<GetUnitByIdDto> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new PaginatedResult<GetUnitByIdDto> { Message = $"Error: {ex.Message}" };
            }
        }
    }
}
