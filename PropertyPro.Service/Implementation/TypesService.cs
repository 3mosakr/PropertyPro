using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Reposatories.Abstraction;
using PropertyPro.Infrastructure.Responses;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Implementation
{
    public class TypesService : ITypesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region UserType

        public async Task<ResponseModel<UserType>> GetUserTypesListAsync()
        {
            try
            {
                var userTypes = await _unitOfWork.UserTypes.GetAllNoTrackingAsync();
                return new ResponseModel<UserType>(userTypes, "Get data Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<UserType>("Faild to retrive the data.", false, [ex.Message]);
            }
        }

        public async Task<ResponseModel<UserType>> AddUserTypeAsync(string userType)
        {
            try
            {
                // find if gov is exist before
                var userTypes = await _unitOfWork.UserTypes.GetAllNoTrackingAsync();
                if (userTypes is not null)
                {
                    var userTypesIsExist = userTypes.FirstOrDefault(u => u.Type.Equals(userType, StringComparison.OrdinalIgnoreCase));
                    if (userTypesIsExist is not null) return new ResponseModel<UserType>("this Type is Already Exist.", false);
                }

                var Type = await _unitOfWork.UserTypes.AddAsync(new UserType { Type = userType });
                return new ResponseModel<UserType>([Type], "Get governorate Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<UserType>("Faild adding operation.", false, [ex.Message]);
            }
        }

        public async Task<ResponseModel<UserType>> DeleteUserTypeAsync(int id)
        {
            try
            {
                // find if gov is exist
                var userType = await _unitOfWork.UserTypes.GetByIdAsync(id);
                if (userType is null) return new ResponseModel<UserType>("Not Found.", false);

                await _unitOfWork.UserTypes.DeleteAsync(userType);
                return new ResponseModel<UserType>([userType], "governorate deleted Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<UserType>("Faild operation.", false, [ex.Message]);
            }
        }

        #endregion

        #region UserType

        public async Task<ResponseModel<SaleType>> GetSaleTypesListAsync()
        {
            try
            {
                var saleTypes = await _unitOfWork.SaleTypes.GetAllNoTrackingAsync();
                return new ResponseModel<SaleType>(saleTypes, "Get data Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<SaleType>("Faild to retrive the data.", false, [ex.Message]);
            }
        }

        public async Task<ResponseModel<SaleType>> AddSaleTypeAsync(string userType)
        {
            try
            {
                // find if gov is exist before
                var saleTypes = await _unitOfWork.SaleTypes.GetAllNoTrackingAsync();
                if (saleTypes is not null)
                {
                    var saleTypesIsExist = saleTypes.FirstOrDefault(u => u.Name.Equals(userType, StringComparison.OrdinalIgnoreCase));
                    if (saleTypesIsExist is not null) return new ResponseModel<SaleType>("this Type is Already Exist.", false);
                }

                var Type = await _unitOfWork.SaleTypes.AddAsync(new SaleType { Name = userType });
                return new ResponseModel<SaleType>([Type], "Get governorate Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<SaleType>("Faild adding operation.", false, [ex.Message]);
            }
        }

        public async Task<ResponseModel<SaleType>> DeleteSaleTypeAsync(int id)
        {
            try
            {
                // find if gov is exist
                var saleType = await _unitOfWork.SaleTypes.GetByIdAsync(id);
                if (saleType is null) return new ResponseModel<SaleType>("Not Found.", false);

                await _unitOfWork.SaleTypes.DeleteAsync(saleType);
                return new ResponseModel<SaleType>([saleType], "governorate deleted Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<SaleType>("Faild operation.", false, [ex.Message]);
            }
        }

        #endregion
        
        #region UnitType

        public async Task<ResponseModel<UnitType>> GetUnitTypesListAsync()
        {
            try
            {
                var unitType = await _unitOfWork.UnitTypes.GetAllNoTrackingAsync();
                return new ResponseModel<UnitType>(unitType, "Get data Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<UnitType>("Faild to retrive the data.", false, [ex.Message]);
            }
        }

        public async Task<ResponseModel<UnitType>> AddUnitTypeAsync(string userType)
        {
            try
            {
                // find if gov is exist before
                var unitTypes = await _unitOfWork.UnitTypes.GetAllNoTrackingAsync();
                if (unitTypes is not null)
                {
                    var unitTypesIsExist = unitTypes.FirstOrDefault(u => u.TypeName.Equals(userType, StringComparison.OrdinalIgnoreCase));
                    if (unitTypesIsExist is not null) return new ResponseModel<UnitType>("this Type is Already Exist.", false);
                }

                var Type = await _unitOfWork.UnitTypes.AddAsync(new UnitType { TypeName = userType });
                return new ResponseModel<UnitType>([Type], "Get governorate Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<UnitType>("Faild adding operation.", false, [ex.Message]);
            }
        }

        public async Task<ResponseModel<UnitType>> DeleteUnitTypeAsync(int id)
        {
            try
            {
                // find if gov is exist
                var unitType = await _unitOfWork.UnitTypes.GetByIdAsync(id);
                if (unitType is null) return new ResponseModel<UnitType>("Not Found.", false);

                await _unitOfWork.UnitTypes.DeleteAsync(unitType);
                return new ResponseModel<UnitType>([unitType], "governorate deleted Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<UnitType>("Faild operation.", false, [ex.Message]);
            }
        }

        #endregion



    }
}
