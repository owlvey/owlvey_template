﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectPS.ServicePS.Component.Interfaces;
using ProjectPS.ServicePS.Component.Models;

namespace ProjectPS.ServicePS.API.Controllers
{
    [Route("appsettings")]
    public class AppSettingController : BaseController
    {
        private readonly IAppSettingQueryService _appSettingQueryService;
        private readonly IAppSettingService _appSettingService;
        
        public AppSettingController(IAppSettingQueryService appSettingQueryService,
                                    IAppSettingService appSettingService) : base()
        {
            this._appSettingQueryService = appSettingQueryService;
            this._appSettingService = appSettingService;
        }

        /// <summary>
        /// Get appsettings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(AppSettingPostRp), 200)]
        public async Task<IActionResult> Get()
        {
            var model = await this._appSettingQueryService.GetSettings();
            return this.Ok(model);
        }

        /// <summary>
        /// Get appsetting by id 
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AppSettingGetRp), 200)]
        public async Task<IActionResult> GetById(string id)
        {
            var model = await this._appSettingQueryService.GetAppSettingById(id);
            return this.Ok(model);
        }

        /// <summary>
        /// Create a new appsetting
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /appsettings
        ///     {
        ///        "id": "key1",
        ///        "value": "Value1"
        ///     }
        ///
        /// </remarks>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AppSettingPostRp resource)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._appSettingService.CreateAppSetting(resource);
            
            return this.Ok();
        }

        /// <summary>
        /// Update an appsetting
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]AppSettingPutRp resource)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._appSettingService.UpdateAppSetting(resource);
            
            return this.Ok();
        }

        /// <summary>
        /// Delete an appsetting
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(string id)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var response = await this._appSettingService.DeleteAppSetting(id);
            
            return this.NoContent();
        }


    }
}