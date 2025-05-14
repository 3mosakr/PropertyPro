using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Responses;
using PropertyPro.Service.Dto.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Abstract
{
    public interface IUnitService
    {
        public Task<ResponseModel<GetUnitsForListingDto>> GetUnitsPaginatedListFilteredAsync(string search, int page, int pageSize,
                                                                            int unitType,
                                                                            int userType,
                                                                            int minPrice,
                                                                            int maxPrice,
                                                                            int NumOfRooms,
                                                                            int NumOfBathrooms,
                                                                            int hotDeals);
        public Task<ResponseModel<GetUnitsForListingDto>> GetUnitsPaginatedListHotDealsAsync(string search, int page, int pageSize, int minPrice, int maxPrice);
        public Task<ResponseModel<GetUnitByIdDto>> GetUnitByIdAsync(int id);
        public Task<ResponseModel<AddUnitDto>> AddUnitAsync(AddUnitDto addUnit);
        public Task<ResponseModel<UpdateUnitDto>> UpdateUnitAsync(UpdateUnitDto UpdatedUnit);
        public Task<ResponseModel<bool>> DeleteUnitByIdAsync(int id);

        public Task<ResponseModel<GetUnitsForListingDto>> GetUnitsForUserPaginatedListAsync(int userId);
    }
}
