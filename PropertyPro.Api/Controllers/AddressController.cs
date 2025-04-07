using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Address;

namespace PropertyPro.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : AppControllerBase
    {

        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }


        #region Governorate
        [HttpGet("Governorate")]
        public async Task<IActionResult> GetGovernorateListAsync()
        {
            var response = await _addressService.GetGovernorateListAsync();
            return NewResult(response);
        }

        [HttpPost("Governorate")]
        public async Task<IActionResult> AddGovernorateAsync(string GovernorateName)
        {
            var response = await _addressService.AddGovernorateAsync(GovernorateName);
            return NewResult(response);
        }

        [HttpDelete("Governorate")]
        public async Task<IActionResult> DeleteGovernorateAsync(int id)
        {
            var response = await _addressService.DeleteGovernorateAsync(id);
            return NewResult(response);
        }

        #endregion

        #region City
        [HttpGet("City")]
        public async Task<IActionResult> GetCitiesListAsync()
        {
            var response = await _addressService.GetCitiesListAsync();
            return NewResult(response);
        }

        [HttpGet("City-in-Governorate")]
        public async Task<IActionResult> GetCitiesInGovernorateListAsync(int governorateId)
        {
            var response = await _addressService.GetCitiesInGovernorateListAsync(governorateId);
            return NewResult(response);
        }

        [HttpPost("City")]
        public async Task<IActionResult> AddCityAsync(AddCityDto model)
        {
            var response = await _addressService.AddCityAsync(model);
            return NewResult(response);
        }

        [HttpDelete("City")]
        public async Task<IActionResult> DeleteCityAsync(int id)
        {
            var response = await _addressService.DeleteCityAsync(id);
            return NewResult(response);
        }
        #endregion

        #region Area
        [HttpGet("Area")]
        public async Task<IActionResult> GetAreasListAsync()
        {
            var response = await _addressService.GetAreasListAsync();
            return NewResult(response);
        }

        [HttpGet("Area-in-City")]
        public async Task<IActionResult> GetAreasInCitiesListAsync(int CityId)
        {
            var response = await _addressService.GetAreasInCityListAsync(CityId);
            return NewResult(response);
        }

        [HttpPost("Area")]
        public async Task<IActionResult> AddAreaAsync(AddAreaDto model)
        {
            var response = await _addressService.AddAreaAsync(model);
            return NewResult(response);
        }

        [HttpDelete("Area")]
        public async Task<IActionResult> DeleteAreaAsync(int id)
        {
            var response = await _addressService.DeleteAreaAsync(id);
            return NewResult(response);
        }
        #endregion
    }
}
