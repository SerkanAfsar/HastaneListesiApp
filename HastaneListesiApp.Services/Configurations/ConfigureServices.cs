using FluentValidation.AspNetCore;
using HastaneListesiApp.Core.Services;
using HastaneListesiApp.Services.Mappers;
using HastaneListesiApp.Services.Services;
using HastaneListesiApp.Services.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace HastaneListesiApp.Services.Configurations
{
    public static class ConfigureServices
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddAutoMapper(typeof(ProfileMapper).Assembly);
            return services;
        }

        public static IServiceCollection RegisterValidations(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddFluentValidation(options =>
            {
                options.DisableDataAnnotationsValidation = true;
                options.RegisterValidatorsFromAssembly(typeof(CityRequestDtoValidator).Assembly);
            });
            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddScoped(typeof(IServiceBase<,,>), typeof(ServiceBase<,,>));
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IHospitalService, HospitalService>();
            return services;
        }
    }
}
