using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        #region Governorate

        public async Task<ResponseModel<GovernorateDto>> GetGovernorateListAsync()
        {
            try
            {
                var governorates = await _unitOfWork.Governorates.GetAllNoTrackingAsync();
                // mapping
                var mappingGovs = _mapper.Map<List<GovernorateDto>>(governorates);
                return new ResponseModel<GovernorateDto>(mappingGovs, "Get data Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<GovernorateDto>("Faild to retrive the data.", false, [ex.Message]);
            }
        }

        public async Task<ResponseModel<Governorate>> AddGovernorateAsync(string governorateName)
        {
            if (string.IsNullOrEmpty(governorateName))
                return new ResponseModel<Governorate>("Governorate name is required.", false);
            try
            {
                // find if gov is exist before
                var governorates = await _unitOfWork.Governorates.GetAllNoTrackingAsync();
                if (governorates is not null)
                {
                    var govIsExist = governorates.FirstOrDefault(g => g.GovernorateName.Equals(governorateName,StringComparison.OrdinalIgnoreCase));
                    if (govIsExist is not null) return new ResponseModel<Governorate>("Governorate Already Exist.", false);
                }

                var governorate = await _unitOfWork.Governorates.AddAsync(new Governorate{GovernorateName = governorateName});
                return new ResponseModel<Governorate>([governorate], "Get governorate Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<Governorate>("Faild adding operation.", false, [ex.Message]);
            }
        }

        public async Task<ResponseModel<Governorate>> DeleteGovernorateAsync(int id)
        {
            try
            {
                // find if gov is exist
                var governorate = await _unitOfWork.Governorates.GetByIdAsync(id);
                if (governorate is null) return new ResponseModel<Governorate>("Not Found.", false);

                await _unitOfWork.Governorates.DeleteAsync(governorate);
                return new ResponseModel<Governorate>([governorate], "governorate deleted Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<Governorate>("Faild operation.", false, [ex.Message]);
            }
        }

        #endregion

        #region City

        public async Task<ResponseModel<CityDto>> GetCitiesListAsync()
        {
            try
            {
                var cities = await _unitOfWork.Cities.GetAllNoTrackingAsync();
                // mapping
                var mappingCities = _mapper.Map<List<CityDto>>(cities);
                mappingCities = mappingCities.OrderBy(c => c.GovernorateId).ToList();
                return new ResponseModel<CityDto>(mappingCities, "Get data Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<CityDto>("Faild to retrive the data.", false, [ex.Message]);
            }
        }

        public async Task<ResponseModel<CityDto>> GetCitiesInGovernorateListAsync(int governorateId)
        {
            try
            {
                var cities = await _unitOfWork.Cities.GetTableNoTracking()
                                    .Where(c => c.GovernorateId == governorateId)
                                    .ToListAsync();
                if (!cities.Any()) return new ResponseModel<CityDto>("There is no cities in this Governorate added.");

                // mapping
                var mappingCities = _mapper.Map<List<CityDto>>(cities);
                return new ResponseModel<CityDto>(mappingCities, "Get data Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<CityDto>("Faild to retrive the data.", false, [ex.Message]);
            }
        }

        public async Task<ResponseModel<CityDto>> AddCityAsync(AddCityDto addCityDto)
        {
            try
            {
                // find if city is exist before
                var isCityExist = _unitOfWork.Cities.GetTableNoTracking()
                                    .Where(c => c.GovernorateId == addCityDto.GovernorateId)
                                    .ToList()
                                    .FirstOrDefault(c => c.CityName.Equals(addCityDto.CityName, StringComparison.OrdinalIgnoreCase));

                if (isCityExist is not null)
                    return new ResponseModel<CityDto>("City Already Exist.", false);

                // mapping 
                var city = _mapper.Map<City>(addCityDto);

                var result = await _unitOfWork.Cities.AddAsync(city);
                return new ResponseModel<CityDto>([_mapper.Map<CityDto>(result)], "Get City Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<CityDto>("Faild adding operation.", false, [ex.Message]);
            }
        }

        public async Task<ResponseModel<City>> DeleteCityAsync(int id)
        {
            try
            {
                // find if gov is exist
                var city = await _unitOfWork.Cities.GetByIdAsync(id);
                if (city is null) return new ResponseModel<City>("Not Found.", false);

                await _unitOfWork.Cities.DeleteAsync(city);
                return new ResponseModel<City>([city], "City deleted Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<City>("Faild operation.", false, [ex.Message]);
            }
        }


        #endregion

        #region Area

        public async Task<ResponseModel<AreaDto>> GetAreasListAsync()
        {
            try
            {
                var areas = await _unitOfWork.Areas.GetAllNoTrackingAsync();
                // mapping
                var mappingAreas = _mapper.Map<List<AreaDto>>(areas);
                mappingAreas = mappingAreas.OrderBy(c => c.CityId).ToList();
                return new ResponseModel<AreaDto>(mappingAreas, "Get data Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<AreaDto>("Faild to retrive the data.", false, [ex.Message]);
            }
        }

        public async Task<ResponseModel<AreaDto>> GetAreasInCityListAsync(int cityId)
        {
            try
            {
                var areas = await _unitOfWork.Areas.GetTableNoTracking()
                                    .Where(c => c.CityId == cityId)
                                    .ToListAsync();
                if (!areas.Any()) return new ResponseModel<AreaDto>("There is no Areas in this City added.");

                // mapping
                var mappingAreas = _mapper.Map<List<AreaDto>>(areas);
                return new ResponseModel<AreaDto>(mappingAreas, "Get data Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<AreaDto>("Faild to retrive the data.", false, [ex.Message]);
            }
        }

        public async Task<ResponseModel<AreaDto>> AddAreaAsync(AddAreaDto addAreaDto)
        {
            try
            {
                // find if gov is exist before
                var isAreaExist = _unitOfWork.Areas.GetTableNoTracking()
                                    .Where(a => a.CityId == addAreaDto.CityId)
                                    .ToList()
                                    .FirstOrDefault(a => a.AreaName.Equals(addAreaDto.AreaName, StringComparison.OrdinalIgnoreCase));

                if (isAreaExist is not null)
                    return new ResponseModel<AreaDto>("AreaDto Already Exist.", false);

                // mapping 
                var area = _mapper.Map<Area>(addAreaDto);

                var result = await _unitOfWork.Areas.AddAsync(area);
                return new ResponseModel<AreaDto>([_mapper.Map<AreaDto>(result)], "Get Area Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<AreaDto>("Faild adding operation.", false, [ex.Message]);
            }
        }

        public async Task<ResponseModel<Area>> DeleteAreaAsync(int id)
        {
            try
            {
                // find if gov is exist
                var Area = await _unitOfWork.Areas.GetByIdAsync(id);
                if (Area is null) return new ResponseModel<Area>("Not Found.", false);

                await _unitOfWork.Areas.DeleteAsync(Area);
                return new ResponseModel<Area>([Area], "City deleted Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<Area>("Faild operation.", false, [ex.Message]);
            }
        }

        #endregion
    }
}
