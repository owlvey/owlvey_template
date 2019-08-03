using FizzWare.NBuilder;
using ProjectPS.ServicePS.Component.Models;
using System;
using Xunit;

namespace ProjectPS.ServicePS.ComponentTests
{
    public class AppSettingComponentTest
    {
        public AppSettingComponentTest()
        {

        }

        [Fact]
        public void CreateAppSettingSuccess()
        {
           string createdBy = Guid.NewGuid().ToString("n");

           var appSettingModel = Builder<AppSettingPostRp>.CreateNew()
                                .With(x => x.Key = Guid.NewGuid().ToString("n"))
                                .With(x => x.Value = Guid.NewGuid().ToString("n"))
                                .Build();

        }

        [Fact]
        public void CreateAppSettingFail()
        {
            string createdBy = Guid.NewGuid().ToString("n");

            var appSettingModel = Builder<AppSettingPostRp>.CreateNew()
                                 .With(x => x.Key = string.Empty)
                                 .With(x => x.Value = Guid.NewGuid().ToString("n"))
                                 .Build();

        }
    }
}
