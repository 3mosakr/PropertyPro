using PropertyPro.Frontend.Models.Address.Governorate;
using PropertyPro.Frontend.Services.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;
using PropertyPro.Frontend.Auth;
using Microsoft.JSInterop;
using PropertyPro.Frontend.Models.Response;
using PropertyPro.Frontend.Models.Address.City;
using PropertyPro.Frontend.Models.Address.Area;
using System.Reflection;
using PropertyPro.Frontend.Models;

namespace PropertyPro.Frontend.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly IAuthService _authService;

        public AddressService(HttpClient httpClient, IAuthService authService)
        {
            _baseUrl = $"{Const.BaseUrl}/Address";
            _httpClient = httpClient;
            _authService = authService;
        }


        #region Governorate
        public async Task<ResponseModel<Governorate>> GetGovernorateListAsync()
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Get, $"{_baseUrl}/Governorate");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<Governorate>>(content, options)
                       ?? new ResponseModel<Governorate> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<Governorate> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<ResponseModel<Governorate>> AddGovernorateAsync(string GovernorateName)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Post, $"{_baseUrl}/Governorate/?GovernorateName={GovernorateName}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<Governorate>>(content, options)
                       ?? new ResponseModel<Governorate> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<Governorate> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task DeleteGovernorateAsync(int id)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Delete, $"{_baseUrl}/Governorate/{id}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete governorate: {ex.Message}");
            }
        }


        #endregion


        #region City
        public async Task<ResponseModel<City>> GetCitiesListAsync()
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Get, $"{_baseUrl}/City");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<City>>(content, options)
                       ?? new ResponseModel<City> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<City> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<ResponseModel<City>> GetCitiesInGovernorateListAsync(int governorateId)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Get, $"{_baseUrl}/City-in-Governorate?governorateId={governorateId}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<City>>(content, options)
                       ?? new ResponseModel<City> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<City> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<ResponseModel<City>> AddCityAsync(AddCityDto model)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Post, $"{_baseUrl}/City", model);
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<City>>(content, options)
                       ?? new ResponseModel<City> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<City> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task DeleteCityAsync(int id)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Delete, $"{_baseUrl}/City/{id}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete City: {ex.Message}");
            }
        }

        #endregion

        #region Area
        public async Task<ResponseModel<Area>> GetAreasListAsync()
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Get, $"{_baseUrl}/Area");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<Area>>(content, options)
                       ?? new ResponseModel<Area> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<Area> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<ResponseModel<Area>> GetAreasInCityListAsync(int cityId)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Get, $"{_baseUrl}/Area-in-City?cityId={cityId}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<Area>>(content, options)
                       ?? new ResponseModel<Area> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<Area> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<ResponseModel<Area>> AddAreaAsync(AddAreaDto model)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Post, $"{_baseUrl}/Area", model);
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<ResponseModel<Area>>(content, options)
                       ?? new ResponseModel<Area> { Message = "Unexpected null response!" };
            }
            catch (Exception ex)
            {
                return new ResponseModel<Area> { Message = $"Error: {ex.Message}" };
            }
        }

        public async Task DeleteAreaAsync(int id)
        {
            try
            {
                var request = await _authService.CreateRequestMessage(HttpMethod.Delete, $"{_baseUrl}/Area/{id}");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete City: {ex.Message}");
            }
        }

        #endregion
    }
}


