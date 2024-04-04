using HastaneListesiApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HastaneListesiApp.Repository.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("SqlConnection"), options =>
            {
                options.EnableRetryOnFailure(2);
            });
        }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
