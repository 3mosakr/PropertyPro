using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Responses;
using PropertyPro.Service.Dto.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Abstract
{
    public interface IAddressService
    {

        #region Governorate
        // get list, add, delete 
        Task<ResponseModel<GovernorateDto>> GetGovernorateListAsync();
        Task<ResponseModel<Governorate>> AddGovernorateAsync(string GovernorateName);
        Task<ResponseModel<Governorate>> DeleteGovernorateAsync(int id);

        #endregion
        #region City
        Task<ResponseModel<CityDto>> GetCitiesListAsync();
        Task<ResponseModel<CityDto>> GetCitiesInGovernorateListAsync(int governorateId);
        Task<ResponseModel<CityDto>> AddCityAsync(AddCityDto addCityDto);
        Task<ResponseModel<City>> DeleteCityAsync(int id);

        #endregion
        #region Area
        Task<ResponseModel<AreaDto>> GetAreasListAsync();
        Task<ResponseModel<AreaDto>> GetAreasInCityListAsync(int cityId);
        Task<ResponseModel<AreaDto>> AddAreaAsync(AddAreaDto addAreaDto);
        Task<ResponseModel<Area>> DeleteAreaAsync(int id);
        #endregion
    }
}
