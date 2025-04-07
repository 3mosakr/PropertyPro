using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Implementation;
using System.Reflection;

namespace PropertyPro.Service
{
    public static class ModuleServiceDependecies
    {
        public static IServiceCollection AddServiceDependecies(this IServiceCollection services)
        {
            // AutoMapper Configurations
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddSingleton<IImageManagementService, ImageManagementService>();
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(
                                               Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ITypesService, TypesService>();


            services.AddHttpContextAccessor();


            return services;
        }
    }
}
