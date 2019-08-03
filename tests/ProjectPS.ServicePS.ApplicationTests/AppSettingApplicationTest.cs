using FizzWare.NBuilder;
using ProjectPS.ServicePS.Component.Models;
using System;
using Xunit;

namespace ProjectPS.ServicePS.UnitTests
{
    public class AppSettingUnitTest
    {
        public AppSettingUnitTest()
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

            //var appSettingEntity = AppSetting.Factory.Create(appSettingModel.Id,
            //                                                 appSettingModel.Value,
            //                                                 createdBy);

            //Assert.Equal(appSettingModel.Id, appSettingEntity.Id);
            //Assert.Equal(appSettingModel.Value, appSettingEntity.Value);
            //Assert.Equal(createdBy, appSettingEntity.CreatedBy);
        }

        [Fact]
        public void CreateAppSettingFail()
        {
            string createdBy = Guid.NewGuid().ToString("n");

            var appSettingModel = Builder<AppSettingPostRp>.CreateNew()
                                 .With(x => x.Key = string.Empty)
                                 .With(x => x.Value = Guid.NewGuid().ToString("n"))
                                 .Build();

            //Assert.Throws<InvalidDomainModelException>(() => {
            //    AppSetting.Factory.Create(appSettingModel.Id,
            //                                                appSettingModel.Value,
            //                                                createdBy);
            //                                                });

        }
    }
}
