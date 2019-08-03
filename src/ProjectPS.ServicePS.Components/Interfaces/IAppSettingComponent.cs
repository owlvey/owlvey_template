using ProjectPS.ServicePS.Components.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPS.ServicePS.Components.Interfaces
{
    public interface IAppSettingComponent
    {
        Task<BaseComponentResultRp> CreateAppSetting(AppSettingPostRp model);
        Task<BaseComponentResultRp> UpdateAppSetting(string key, AppSettingPutRp model);
        Task<BaseComponentResultRp> DeleteAppSetting(string key);
    }
}
