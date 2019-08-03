using ProjectPS.ServicePS.Component.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPS.ServicePS.Component.Interfaces
{
    public interface IAppSettingService
    {
        Task<ApplicationResultRp> CreateAppSetting(AppSettingPostRp model);
        Task<ApplicationResultRp> UpdateAppSetting(AppSettingPutRp model);
        Task<ApplicationResultRp> DeleteAppSetting(string key);
    }
}
