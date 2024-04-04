using HastaneListesiApp.Core.Entities;
using HastaneListesiApp.Core.Repositories;
using HastaneListesiApp.Repository.Contexts;

namespace HastaneListesiApp.Repository.Repositories
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
