using Microsoft.AspNetCore.Components.Authorization;
using PropertyPro.Frontend.Auth;
using PropertyPro.Frontend.Models;
using PropertyPro.Frontend.Models.Response;
using PropertyPro.Frontend.Models.Types;
using PropertyPro.Frontend.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace PropertyPro.Frontend.Services.Implementations
{
    public class TypesService : ITypesService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly IAuthService _authService;

        public TypesService(HttpClient httpClient, IAuthService authService)
        {
            _baseUrl = $"{Const.BaseUrl}/Types";
            _httpClient = httpClient;
            _authService = authService;
        }


        #region UserType
        public async Task<ResponseModel<UserType>> GetUserTypesListAsync()
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Get, $"{_baseUrl}/UserType");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<UserType>>(content, options)
                       ?? new ResponseModel<UserType> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<UserType> { Message = $"Error: {ex.Message}" };
            }
        }
        
        public async Task<ResponseModel<UserType>> AddUserTypeAsync(string type)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Post, $"{_baseUrl}/UserType?Type={type}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<UserType>>(content, options)
                       ?? new ResponseModel<UserType> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<UserType> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task DeleteUserTypeAsync(int id)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Delete, $"{_baseUrl}/UserType/{id}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete User Type: {ex.Message}");
            }
        }
        #endregion


        #region UnitType
        public async Task<ResponseModel<UnitType>> GetUnitTypesListAsync()
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Get, $"{_baseUrl}/UnitType");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<UnitType>>(content, options)
                       ?? new ResponseModel<UnitType> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<UnitType> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<ResponseModel<UnitType>> AddUnitTypeAsync(string type)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Post, $"{_baseUrl}/UnitType?Type={type}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<UnitType>>(content, options)
                       ?? new ResponseModel<UnitType> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<UnitType> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task DeleteUnitTypeAsync(int id)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Delete, $"{_baseUrl}/UnitType/{id}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete User Type: {ex.Message}");
            }
        }


        #endregion

        #region SaleType

        public async Task<ResponseModel<SaleType>> GetSaleTypesListAsync()
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Get, $"{_baseUrl}/SaleType");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<SaleType>>(content, options)
                       ?? new ResponseModel<SaleType> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<SaleType> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<ResponseModel<SaleType>> AddSaleTypeAsync(string type)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Post, $"{_baseUrl}/SaleType?Type={type}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<SaleType>>(content, options)
                       ?? new ResponseModel<SaleType> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<SaleType> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task DeleteSaleTypeAsync(int id)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Delete, $"{_baseUrl}/SaleType/{id}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete Sale Type: {ex.Message}");
            }
        }

        #endregion

    }
}
