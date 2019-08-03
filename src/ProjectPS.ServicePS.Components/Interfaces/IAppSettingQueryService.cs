using ProjectPS.ServicePS.Components.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPS.ServicePS.Components.Interfaces
{
    public interface IAppSettingQueryService
    {
        Task<IEnumerable<AppSettingGetListRp>> GetSettings();
        Task<AppSettingGetRp> GetAppSettingById(string key);
    }
}
