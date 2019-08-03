﻿using FizzWare.NBuilder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjectPS.ServicePS.IntegrationTests.Setup;
using ProjectPS.ServicePS.Components.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TestStack.BDDfy;
using Xunit;

namespace ProjectPS.ServicePS.IntegrationTests.AppSetting.Scenarios
{
    public class AdminCanUpdateSettingScenario : IDisposable
    {
        private readonly HttpClient _client;
        public AdminCanUpdateSettingScenario(HttpClient client)
        {
            _client = client;
        }

        private AppSettingPostRp representation;
        private string NewValue = "New Value";

        [Given("Admin set information")]
        public void given_information()
        {
            representation = Builder<AppSettingPostRp>.CreateNew()
                                 .With(x => x.Key = $"{Guid.NewGuid()}")
                                 .With(x => x.Value = $"{Guid.NewGuid()}")
                                 .Build();
        }

        [When("Admin send the request")]
        public void when_send_request()
        {
            var jsonContent = HttpClientExtension.ParseModelToHttpContent(representation);
            var responsePost = _client.PostAsync($"/appsettings", jsonContent).Result;
            Console.WriteLine(responsePost.Content.ReadAsStringAsync().Result);
            Assert.True(responsePost.IsSuccessStatusCode);
        }

        [Then("The appsetting update info")]
        public void then_update()
        {
            var representationPut = new AppSettingPutRp();
            representationPut.Value = NewValue;
            
            var jsonContent = HttpClientExtension.ParseModelToHttpContent(representationPut);
            var responsePut = _client.PutAsync($"/appsettings/{representation.Key}", jsonContent).Result;
            Assert.True(responsePut.IsSuccessStatusCode);
        }

        [AndThen("Admin send the request for get new appsetting")]
        public void when_send_request_with_existing_key()
        {
            var responseGet = _client.GetAsync($"/appsettings/{representation.Key}").Result;
            Assert.Equal((int)responseGet.StatusCode, StatusCodes.Status200OK);

            var appSettingRepresentation = HttpClientExtension.ParseHttpContentToModel<AppSettingPostRp>(responseGet.Content);

            Assert.Equal(appSettingRepresentation.Key, representation.Key);
            Assert.Equal(appSettingRepresentation.Value, NewValue);
        }

        public void Dispose()
        {

        }
    }
}
