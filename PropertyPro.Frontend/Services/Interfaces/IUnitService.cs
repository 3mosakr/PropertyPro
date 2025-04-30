using PropertyPro.Frontend.Models.Response;
using PropertyPro.Frontend.Models.Unit;

namespace PropertyPro.Frontend.Services.Interfaces
{
    public interface IUnitService
    {
         Task<PaginatedResult<GetUnitsForListingDto>> GetUnitsPaginatedListFilteredAsync(
                                                                            string search = "",
                                                                            int page = 1,
                                                                            int pageSize = 10,
                                                                            int unitType = 0,
                                                                            int userType = 0,
                                                                            int minPrice = 0,
                                                                            int maxPrice = 0,
                                                                            int NumOfRooms = 0,
                                                                            int NumOfBathrooms = 0);
         Task<ResponseModel<GetUnitByIdDto>> GetUnitByIdAsync(int id);
         Task<ResponseModel<AddUnitDto>> AddUnitAsync(AddUnitDto addUnit);
         Task<ResponseModel<AddUnitDto>> AddUnitFormAsync(MultipartFormDataContent formContent);
         Task<ResponseModel<UpdateUnitDto>> UpdateUnitAsync(MultipartFormDataContent formContent);
         Task DeleteUnitByIdAsync(int id);

        //Task<ResponseModel<GetUnitsForListingDto>> GetUnitsForUserPaginatedListAsync(int userId);
    }
}
