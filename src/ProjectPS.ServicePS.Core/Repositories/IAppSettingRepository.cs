using ProjectPS.ServicePS.Core.Models;
using ProjectPS.ServicePS.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPS.ServicePS.Core.Repositories
{
    public interface IAppSettingRepository : IRepository<AppSettingEntity>
    {
        Task<AppSettingEntity> GetAppSettingByKey(string key);
    }
}
