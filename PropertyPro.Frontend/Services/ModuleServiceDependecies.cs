using PropertyPro.Frontend.Services.Implementations;
using PropertyPro.Frontend.Services.Interfaces;

namespace PropertyPro.Frontend.Services
{
    public static class ModuleServiceDependecies
    {
        public static IServiceCollection AddServiceDependecies(this IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITypesService, TypesService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategotyService, CategotyService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IUserService, UserService>();



            return services;
        }
    }
}
