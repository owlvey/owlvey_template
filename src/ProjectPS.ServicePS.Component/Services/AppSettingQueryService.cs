using ProjectPS.ServicePS.Component.Interfaces;
using ProjectPS.ServicePS.Component.Models;
using ProjectPS.ServicePS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPS.ServicePS.Component.Services
{
    public class AppSettingQueryService : IAppSettingQueryService
    {
        private readonly IAppSettingRepository _appSettingRepository;
        public AppSettingQueryService(IAppSettingRepository appSettingRepository)
        {
            this._appSettingRepository = appSettingRepository;
        }

        /// <summary>
        /// Get setting by key
        /// </summary>
        /// <param name="key">App Setting key</param>
        /// <returns></returns>
        public async Task<AppSettingGetRp> GetAppSettingById(string key)
        {
            var entity = await this._appSettingRepository.FindFirst(c => c.Key.Equals(key, StringComparison.OrdinalIgnoreCase));

            return new AppSettingGetRp {
                Key = entity.Key,
                Value = entity.Value,
                CreatedBy = entity.CreatedBy,
                CreatedOn = entity.CreatedOn
            };
        }

        /// <summary>
        /// Get All settings
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AppSettingGetListRp>> GetSettings()
        {
            var entities = await this._appSettingRepository.GetAll();

            return entities.Select(entity => new AppSettingGetListRp {
                Key = entity.Key,
                Value = entity.Value,
                CreatedBy = entity.CreatedBy,
                CreatedOn = entity.CreatedOn
            });
        }
    }
}
