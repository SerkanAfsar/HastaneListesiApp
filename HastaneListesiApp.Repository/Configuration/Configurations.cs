using HastaneListesiApp.Core.Repositories;
using HastaneListesiApp.Core.UnitOfWorks;
using HastaneListesiApp.Repository.Contexts;
using HastaneListesiApp.Repository.Repositories;
using HastaneListesiApp.Repository.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace HastaneListesiApp.Repository.Configuration
{
    public static class Configurations
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddDbContext<AppDbContext>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
