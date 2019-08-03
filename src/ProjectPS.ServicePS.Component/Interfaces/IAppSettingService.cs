using ProjectPS.ServicePS.Component.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPS.ServicePS.Component.Interfaces
{
    public interface IAppSettingService
    {
        Task<BaseComponentResultRp> CreateAppSetting(AppSettingPostRp model);
        Task<BaseComponentResultRp> UpdateAppSetting(AppSettingPutRp model);
        Task<BaseComponentResultRp> DeleteAppSetting(string key);
    }
}
