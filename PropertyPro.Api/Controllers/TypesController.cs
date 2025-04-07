using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Implementation;

namespace PropertyPro.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TypesController : AppControllerBase
    {
        private readonly ITypesService _typesService;

        public TypesController(ITypesService typesService)
        {
            _typesService = typesService;
        }


        #region UserType

        [HttpGet("UserType")]
        public async Task<IActionResult> GetUserTypesListAsync()
        {
            var response = await _typesService.GetUserTypesListAsync();
            return NewResult(response);
        }

        [HttpPost("UserType")]
        public async Task<IActionResult> AddUserTypesAsync(string Type)
        {
            var response = await _typesService.AddUserTypeAsync(Type);
            return NewResult(response);
        }

        [HttpDelete("UserType")]
        public async Task<IActionResult> DeleteUserTypesAsync(int id)
        {
            var response = await _typesService.DeleteUserTypeAsync(id);
            return NewResult(response);
        }

        #endregion

        #region SaleType

        [HttpGet("SaleType")]
        public async Task<IActionResult> GetSaleTypesListAsync()
        {
            var response = await _typesService.GetSaleTypesListAsync();
            return NewResult(response);
        }

        [HttpPost("SaleType")]
        public async Task<IActionResult> AddSaleTypeAsync(string Type)
        {
            var response = await _typesService.AddSaleTypeAsync(Type);
            return NewResult(response);
        }

        [HttpDelete("SaleType")]
        public async Task<IActionResult> DeleteSaleTypeAsync(int id)
        {
            var response = await _typesService.DeleteSaleTypeAsync(id);
            return NewResult(response);
        }

        #endregion

        #region UnitType

        [HttpGet("UnitType")]
        public async Task<IActionResult> GetUnitTypesListAsync()
        {
            var response = await _typesService.GetUnitTypesListAsync();
            return NewResult(response);
        }

        [HttpPost("UnitType")]
        public async Task<IActionResult> AddUnitTypeAsync(string Type)
        {
            var response = await _typesService.AddUnitTypeAsync(Type);
            return NewResult(response);
        }

        [HttpDelete("UnitType")]
        public async Task<IActionResult> DeleteUnitTypeAsync(int id)
        {
            var response = await _typesService.DeleteUnitTypeAsync(id);
            return NewResult(response);
        }

        #endregion
    }
}
