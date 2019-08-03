using ProjectPS.ServicePS.Data.SQLite.Extensions;
using ProjectPS.ServicePS.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectPS.ServicePS.Data.SQLite.Context
{
    public class ServicePSDbContext : DbContext
    {
        public ServicePSDbContext(DbContextOptions options) :
           base(options)
        {

        }
        
        public DbSet<AppSettingEntity> AppSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();

            base.OnModelCreating(modelBuilder);
        }
    }
}
