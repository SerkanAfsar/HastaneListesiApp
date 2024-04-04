using HastaneListesiApp.Core.Entities;
using HastaneListesiApp.Core.Repositories;
using HastaneListesiApp.Repository.Contexts;

namespace HastaneListesiApp.Repository.Repositories
{
    public class HospitalRepository : RepositoryBase<Hospital>, IHospitalRepository
    {
        public HospitalRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
