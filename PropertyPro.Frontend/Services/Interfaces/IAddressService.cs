using PropertyPro.Frontend.Models.Address.Area;
using PropertyPro.Frontend.Models.Address.City;
using PropertyPro.Frontend.Models.Address.Governorate;
using PropertyPro.Frontend.Models.Response;

namespace PropertyPro.Frontend.Services.Interfaces
{
    public interface IAddressService
    {
        #region Governorate
        Task<ResponseModel<Governorate>> GetGovernorateListAsync();
        Task<ResponseModel<Governorate>> AddGovernorateAsync(string GovernorateName);
        Task DeleteGovernorateAsync(int id);
        #endregion

        #region City
        Task<ResponseModel<City>> GetCitiesListAsync();
        Task<ResponseModel<City>> GetCitiesInGovernorateListAsync(int governorateId);
        Task<ResponseModel<City>> AddCityAsync(AddCityDto model);
        Task DeleteCityAsync(int id);
        #endregion

        #region Area
        Task<ResponseModel<Area>> GetAreasListAsync();
        Task<ResponseModel<Area>> GetAreasInCityListAsync(int cityId);
        Task<ResponseModel<Area>> AddAreaAsync(AddAreaDto addAreaDto);
        Task DeleteAreaAsync(int id);
        #endregion

    }
}
