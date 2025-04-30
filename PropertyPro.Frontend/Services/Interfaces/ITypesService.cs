using PropertyPro.Frontend.Models.Response;
using PropertyPro.Frontend.Models.Types;

namespace PropertyPro.Frontend.Services.Interfaces
{
    public interface ITypesService
    {
        #region UserType
        Task<ResponseModel<UserType>> GetUserTypesListAsync();
        Task<ResponseModel<UserType>> AddUserTypeAsync(string type);
        Task DeleteUserTypeAsync(int id);
        #endregion

        #region UnitType
        Task<ResponseModel<UnitType>> GetUnitTypesListAsync();
        Task<ResponseModel<UnitType>> AddUnitTypeAsync(string type);
        Task DeleteUnitTypeAsync(int id);

        #endregion

        #region SaleType
        Task<ResponseModel<SaleType>> GetSaleTypesListAsync();
        Task<ResponseModel<SaleType>> AddSaleTypeAsync(string Type);
        Task DeleteSaleTypeAsync(int id);

        #endregion
    }
}
