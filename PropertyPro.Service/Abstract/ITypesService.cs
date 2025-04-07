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
    public interface ITypesService
    {
        #region UserType
        Task<ResponseModel<UserType>> GetUserTypesListAsync();
        Task<ResponseModel<UserType>> AddUserTypeAsync(string Type);
        Task<ResponseModel<UserType>> DeleteUserTypeAsync(int id);

        #endregion

        #region UserType
        Task<ResponseModel<SaleType>> GetSaleTypesListAsync();
        Task<ResponseModel<SaleType>> AddSaleTypeAsync(string Type);
        Task<ResponseModel<SaleType>> DeleteSaleTypeAsync(int id);

        #endregion

        #region UnitType
        Task<ResponseModel<UnitType>> GetUnitTypesListAsync();
        Task<ResponseModel<UnitType>> AddUnitTypeAsync(string Type);
        Task<ResponseModel<UnitType>> DeleteUnitTypeAsync(int id);

        #endregion
    }
}
