using AutoMapper;
using Azure;
using Azure.Core;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PropertyPro.Data.Models;
using PropertyPro.Infrastructure.Reposatories.Abstraction;
using PropertyPro.Infrastructure.Responses;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Implementation
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<AddUnitDto> _validator;
        private readonly IImageManagementService _imageManagementService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UnitService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<AddUnitDto> validator, IImageManagementService imageManagementService, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
            _imageManagementService = imageManagementService;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<ResponseModel<GetUnitsForListingDto>> GetUnitsPaginatedListFilteredAsync(string search, int page, int pageSize,
                                                                            int unitType,
                                                                            int userType,
                                                                            int minPrice,
                                                                            int maxPrice,
                                                                            int NumOfRooms,
                                                                            int NumOfBathrooms,
                                                                            int hotDeals)
        {
            try
            {
                // retrieve data filtered
                var filterQuery = await _unitOfWork.Units.GetUnitsQuerableFilteredAsync(search, unitType, userType, minPrice, maxPrice, NumOfRooms, NumOfBathrooms, hotDeals);
                // mapping
                var paginatedList = await _mapper
                .ProjectTo<GetUnitsForListingDto>(filterQuery)
                .ToPaginatedListAsync(page, pageSize);
                // response
                return paginatedList;
                
            }
            catch (Exception ex)
            {
                return new ResponseModel<GetUnitsForListingDto>
                {
                    StatusCode = HttpStatusCode.BadGateway,
                    Status = false,
                    Message = ex.Message,
                    Data = null,
                    Errors = [ex.ToString()]
                };
            }
        }

        public async Task<ResponseModel<GetUnitsForListingDto>> GetUnitsPaginatedListHotDealsAsync(string search, int page, int pageSize, int minPrice, int maxPrice)
        {
            try
            {
                // retrieve data filtered
                var filterQuery = await _unitOfWork.Units.GetUnitsQuerableHotDealsAsync(search, minPrice, maxPrice);
                // mapping
                var paginatedList = await _mapper
                .ProjectTo<GetUnitsForListingDto>(filterQuery)
                .ToPaginatedListAsync(page, pageSize);
                // response
                return paginatedList;
            }
            catch (Exception ex)
            {
                return new ResponseModel<GetUnitsForListingDto>
                {
                    StatusCode = HttpStatusCode.BadGateway,
                    Status = false,
                    Message = ex.Message,
                    Data = null,
                    Errors = [ex.ToString()]
                };
            }

        }

        public async Task<ResponseModel<GetUnitByIdDto>> GetUnitByIdAsync(int id)
        {   
            // Validate id
            if (id <= 0)
            {
                return new ResponseModel<GetUnitByIdDto>($"Bad Request.", false);
            }
            try
            {
                // Get data from Database
                var data = await _unitOfWork.Units.GetUnitByIdAsync(id);
                if (data == null)
                {
                    // not found
                    return new ResponseModel<GetUnitByIdDto> { Status =false, StatusCode = HttpStatusCode.NotFound, Message ="Not Found"};
                }

                // Mapping
                var mapped = _mapper.Map<GetUnitByIdDto>(data);

                // Return Data
                return new ResponseModel<GetUnitByIdDto>()
                {
                    Message = "Get Unit data successfully",
                    Data = [mapped]
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<GetUnitByIdDto>
                {
                    StatusCode = HttpStatusCode.BadGateway,
                    Status = false,
                    Message = ex.Message,
                    Data = null,
                    Errors = [ex.ToString()]
                };
            }
        }

        public async Task<ResponseModel<AddUnitDto>> AddUnitAsync(AddUnitDto addUnit)
        {
            //// Fetch the Governorate, City, and Area based on the provided IDs
            //var governorate = await _unitOfWork.Governorates.FindAsync(addUnit.GovernorateId);
            //var city = await _unitOfWork.Cities.FindAsync(addUnit.CityId);
            //var area = await _unitOfWork.Areas.FindAsync(addUnit.AreaId);

            //// Check if all entities were found
            //if (governorate == null || city == null || area == null)
            //{
            //    throw new Exception("Invalid Governorate, City, or Area ID.");
            //}

            try
            {
                

                // validate input
                // Mapping
                var mapped = _mapper.Map<Unit>(addUnit);

                if (mapped.UserId == 0)
                {
                    // user Id
                    int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                    mapped.UserId = userId;
                }

                // set Dateposted
                mapped.DatePosted = DateTime.Now;

                // Add operation
                var unit = await _unitOfWork.Units.AddAsync(mapped);

                // Add Images to server and DB
                var ImagePath = await _imageManagementService.AddImagesAsync(addUnit.Image, unit.Id.ToString());

                var Images = ImagePath.Select(path => new Image
                {
                    ImagePath = path,
                    UnitId = unit.Id
                }).ToList();

                //save images in DB
                await _unitOfWork.Images.AddRangeAsync(Images);

                // return response
                return new ResponseModel<AddUnitDto>("Unit Added successfully");
            }
            catch (Exception ex)
            {
                return new ResponseModel<AddUnitDto>
                {
                    StatusCode = HttpStatusCode.BadGateway,
                    Status = false,
                    Message = ex.Message,
                    Data = null,
                    Errors = [ex.ToString()]
                };
            }
        }

        public async Task<ResponseModel<UpdateUnitDto>> UpdateUnitAsync(UpdateUnitDto updatedUnitDto)
        {
            try
            {
                // get old Unit and validate it
                var unitExist = await _unitOfWork.Units.GetUnitByIdWithImagesAsync(updatedUnitDto.Id);
                if (unitExist == null)
                {
                    // not found
                    return new ResponseModel<UpdateUnitDto> { Status = false, StatusCode = HttpStatusCode.NotFound, Message = "Not Found" };
                }
                // mapping
                var UnitMapper = _mapper.Map(updatedUnitDto, unitExist);

                // Handle Images 
                if (updatedUnitDto.Image != null)
                {
                    // Delete old images
                    var findImage = await _unitOfWork.Images
                                                    .GetTableAsTracking()
                                                    .Where(i => i.UnitId == unitExist.Id)
                                                    .ToListAsync();

                    foreach (var image in findImage)
                    {
                        _imageManagementService.DeleteImageAsync(image.ImagePath);
                    }
                    // delete old images from data base
                    await _unitOfWork.Images.DeleteRangeAsync(findImage);

                    // Add new Images
                    // Add Images to server and DB
                    var ImagePath = await _imageManagementService.AddImagesAsync(updatedUnitDto.Image, UnitMapper.Id.ToString());

                    var photos = ImagePath.Select(path => new Image
                    {
                        ImagePath = path,
                        UnitId = UnitMapper.Id
                    }).ToList();
                    //save images in DB
                    await _unitOfWork.Images.AddRangeAsync(photos);
                }
                
                // execute update
                var result = await _unitOfWork.Units.UpdateAsync(UnitMapper);
                // response
                return new ResponseModel<UpdateUnitDto>("Unit Updated Successfully");
            }
            catch (Exception ex)
            {
                return new ResponseModel<UpdateUnitDto>
                {
                    StatusCode = HttpStatusCode.BadGateway,
                    Status = false,
                    Message = ex.Message,
                    Data = null,
                    Errors = [ex.ToString()]
                };
            }
        }

        public async Task<ResponseModel<bool>> DeleteUnitByIdAsync(int id)
        {
            try
            {
                // get old Unit and validate it
                var unit = await _unitOfWork.Units.GetUnitByIdWithImagesAsync(id);
                if (unit == null)
                {
                    // not found
                    return new ResponseModel<bool> { Status = false, StatusCode = HttpStatusCode.NotFound, Message = "Not Found" };
                }

                // Delete images from server
                var findImage = await _unitOfWork.Images
                                                .GetTableNoTracking()
                                                .Where(i => i.UnitId == unit.Id)
                                                .ToListAsync();

                foreach (var image in findImage)
                {
                    _imageManagementService.DeleteImageAsync(image.ImagePath);
                }

                // delete images from data base by default when delete unit (Cascade delete)
                await _unitOfWork.Units.DeleteAsync(unit);
                return new ResponseModel<bool>("Unit Deleted Successfully.");
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>
                {
                    StatusCode = HttpStatusCode.BadGateway,
                    Status = false,
                    Message = ex.Message,
                    Data = null,
                    Errors = [ex.ToString()]
                };
            }
        }

        public async Task<ResponseModel<GetUnitsForListingDto>> GetUnitsForUserPaginatedListAsync(int userId)
        {
            try
            {
                // retrieve data 
                var filterQuery = await _unitOfWork.Units.GetUnitsQuerableAsync();
                // filter
                filterQuery.Where(u => u.UserId == userId);
                // mapping
                var paginatedList = await _mapper
                .ProjectTo<GetUnitsForListingDto>(filterQuery)
                .ToPaginatedListAsync(1, 10);
                // response
                return paginatedList;

            }
            catch (Exception ex)
            {
                return new ResponseModel<GetUnitsForListingDto>
                {
                    StatusCode = HttpStatusCode.BadGateway,
                    Status = false,
                    Message = ex.Message,
                    Data = null,
                    Errors = [ex.ToString()]
                };
            }
        }

        
    }
}
