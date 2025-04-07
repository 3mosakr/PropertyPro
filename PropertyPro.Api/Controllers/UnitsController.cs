using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Units;

namespace PropertyPro.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin, User")]

    public class UnitsController : AppControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitsController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet]
        [Route("Get-All-Units")]
        public async Task<IActionResult> GetUnitsFilteredAsync([FromQuery] string search = "", int page = 1, int pageSize = 10,
                                                        int unitType = 0,
                                                        int userType = 0,
                                                        int minPrice = 0,
                                                        int maxPrice = 0,
                                                        int NumOfRooms = 0,
                                                        int NumOfBathrooms =0 )
        {
            var response = await _unitService.GetUnitsPaginatedListFilteredAsync(search, page, pageSize, unitType, userType, minPrice, maxPrice, NumOfRooms, NumOfBathrooms);
            return NewResult(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUnitByIdAsync(int id)
        {
            var response = await _unitService.GetUnitByIdAsync(id);
            return NewResult(response);
        }

        [HttpPost]
        [Route("Add-Unit")]
        public async Task<IActionResult> AddUnitAsync(AddUnitDto unit)
        {
            var response = await _unitService.AddUnitAsync(unit);
            return NewResult(response);
        }

        [HttpPut]
        [Route("Upate-Unit")]
        public async Task<IActionResult> UpdateUnitAsync(UpdateUnitDto unit)
        {
            var response = await _unitService.UpdateUnitAsync(unit);
            return NewResult(response);
        }

        [HttpDelete]
        [Route("Delete-Unit")]
        public async Task<IActionResult> DeleteUnitByIdAsync(int id)
        {
            var response = await _unitService.DeleteUnitByIdAsync(id);
            return NewResult(response);
        }

    }
}
