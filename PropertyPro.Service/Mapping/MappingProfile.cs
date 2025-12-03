using AutoMapper;
using PropertyPro.Data.Models;
using PropertyPro.Service.Dto.Address;
using PropertyPro.Service.Dto.AppUser;
using PropertyPro.Service.Dto.Auth;
using PropertyPro.Service.Dto.Comments;
using PropertyPro.Service.Dto.Favorites;
using PropertyPro.Service.Dto.Ratings;
using PropertyPro.Service.Dto.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            unitMapping();
            CommentMapping();
            FavoriteMapping();
            RatingMapping();
            UserMapping();
            AddressMapping();

        }

        internal void unitMapping()
        {
            CreateMap<AddUnitDto, Unit>()
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Unit, GetUnitsForListingDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(
                    src => src.Category.CategoryName))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(
                    src => src.UnitType.TypeName))
                .ForMember(dest => dest.Sale, opt => opt.MapFrom(
                    src => src.SaleType.Name))
                .ForMember(dest => dest.User,
                    opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.UserPhone,
                    opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.Images,
                    opt => opt.MapFrom(src => src.Images.Select(i => i.ImagePath)))
                ;

            CreateMap<Unit, GetUnitByIdDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(
                    src => src.Category.CategoryName))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(
                    src => src.UnitType.TypeName))
                .ForMember(dest => dest.Sale, opt => opt.MapFrom(
                    src => src.SaleType.Name))
                .ForMember(dest => dest.User,
                    opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.UserPhone,
                    opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.RatedUsersCount,
                    opt => opt.MapFrom(src => src.Ratings.Count))
                .ForMember(dest => dest.RatingValue,
                    opt => opt.MapFrom(src => src.Ratings.Any() ? src.Ratings.Average(x => x.RatingValue) : 0))
                .ForMember(dest => dest.Comments,
                    opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.Images,
                    opt => opt.MapFrom(src => src.Images.Select(i => i.ImagePath)))
                ;
            
            CreateMap<UpdateUnitDto, Unit>()
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Unit, UserPostsDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(
                    src => src.Category.CategoryName))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(
                    src => src.UnitType.TypeName))
                .ForMember(dest => dest.Sale, opt => opt.MapFrom(
                    src => src.SaleType.Name))
                .ForMember(dest => dest.Images,
                    opt => opt.MapFrom(src => src.Images.Select(i => i.ImagePath)));


        }
        
        internal void CommentMapping()
        {
            CreateMap<Comment, CommentDetailsDto>()
                .ForMember(dest => dest.UserName, 
                    opt => opt.MapFrom(src => src.User.FullName));

            CreateMap<AddCommentDto, Comment>();

        }

        internal void FavoriteMapping()
        {
            CreateMap<Favorite, FavoriteDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Unit.Title))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Unit.Price))
                .ForMember(dest => dest.NumberOfBedrooms, opt => opt.MapFrom(src => src.Unit.NumberOfBedrooms))
                .ForMember(dest => dest.NumberOfBathrooms, opt => opt.MapFrom(src => src.Unit.NumberOfBathrooms))
                .ForMember(dest => dest.UnitType, opt => opt.MapFrom(src => src.Unit.UnitType.TypeName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Unit.Address))
                .ForMember(dest => dest.IsFeatured, opt => opt.MapFrom(src => src.Unit.IsFeatured))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Unit.Images.Select(i => i.ImagePath)))
                .ReverseMap();
            CreateMap<AddFavoriteDto, Favorite>();
            CreateMap<Favorite, UserFavoritsDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Unit.Category.CategoryName))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Unit.UnitType.TypeName))
                .ForMember(dest => dest.Sale, opt => opt.MapFrom(src => src.Unit.SaleType.Name))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Unit.Title))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Unit.Price))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Unit.Address))
                .ForMember(dest => dest.DatePosted, opt => opt.MapFrom(src => src.Unit.DatePosted))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Unit.User.FullName))
                .ForMember(dest => dest.UserPhone, opt => opt.MapFrom(src => src.Unit.User.PhoneNumber))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Unit.Images.Select(i => i.ImagePath)))
                ;
        }

        internal void RatingMapping()
        {
            CreateMap<RatingDto, Rating>();
        }

        internal void UserMapping()
        {
            CreateMap<User, GetUserByIdDto>()
                .ForMember(dest => dest.UserType,
                    opt => opt.MapFrom(src => src.UserType.Type));
        
            CreateMap<RegisterDto, User>()
                .ForMember(u => u.Photo, opt => opt.Ignore())
                .ReverseMap();
        }

        internal void AddressMapping()
        {
            CreateMap<Governorate, GovernorateDto>().ReverseMap();
            
            CreateMap<AddCityDto, City>();
            CreateMap<City, CityDto>().ReverseMap();
            
            CreateMap<AddAreaDto, Area>();
            CreateMap<Area, AreaDto>().ReverseMap();

        }
    }
}
