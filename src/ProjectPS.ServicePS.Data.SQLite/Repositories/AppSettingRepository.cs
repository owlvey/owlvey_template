using ProjectPS.ServicePS.Data.SQLite.Context;
using ProjectPS.ServicePS.Core.Models;
using ProjectPS.ServicePS.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPS.ServicePS.Data.SQLite.Repositories
{
    public class AppSettingRepository : Repository<AppSettingEntity>, IAppSettingRepository
    {
        public AppSettingRepository(ServicePSDbContext context) : base(context)
        {

        }

        public async Task<AppSettingEntity> GetAppSettingByKey(string key)
        {
            return await this.DbSet.FirstOrDefaultAsync(c => c.Key.Equals(key));
        }
    }
}
