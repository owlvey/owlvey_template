﻿using FizzWare.NBuilder;
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
    public class AdminCanCreateSettingScenario : IDisposable
    {
        private readonly HttpClient _client;
        public AdminCanCreateSettingScenario(HttpClient client)
        {
            _client = client;
            
        }


        private AppSettingPostRp representation;

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

        [Then("The appsetting was created")]
        public void then_created()
        {
            var responseGet = _client.GetAsync($"/appsettings/{representation.Key}").Result;
            Assert.True(responseGet.IsSuccessStatusCode);

            var appSettingRepresentation = HttpClientExtension.ParseHttpContentToModel<AppSettingPostRp>(responseGet.Content);

            Assert.Equal(appSettingRepresentation.Key, representation.Key);
            Assert.Equal(appSettingRepresentation.Value, representation.Value);
        }

        public void Dispose()
        {

        }
    }
}
