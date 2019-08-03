using FizzWare.NBuilder;
using ProjectPS.ServicePS.Core.Models;
using System;
using Xunit;

namespace ProjectPS.ServicePS.UnitTests
{
    public class AppSettingApplicationTest
    {
        public AppSettingApplicationTest()
        {

        }

        [Fact]
        public void CreateAppSettingSuccess()
        {
            var createdBy = Guid.NewGuid().ToString("n");
            var id = Guid.NewGuid().ToString("n");
            var value = Faker.RandomNumber.Next().ToString();
            var isReadOnly = true;

            var appSettingEntity = AppSettingEntity.Factory.Create(id, value, isReadOnly, createdBy);

            Assert.Equal(id, appSettingEntity.Key);
            Assert.Equal(value, appSettingEntity.Value);
            Assert.Equal(isReadOnly, appSettingEntity.IsReadOnly);
            Assert.Equal(createdBy, appSettingEntity.CreatedBy);
        }

        [Fact]
        public void CreateAppSettingFail()
        {
            var createdBy = Guid.NewGuid().ToString("n");
            var id = Guid.NewGuid().ToString("n");
            var value = Faker.RandomNumber.Next().ToString();
            var isReadOnly = true;

            var appSettingEntity = AppSettingEntity.Factory.Create(id, value, isReadOnly, createdBy);

            //Assert.Throws<InvalidDomainModelException>(() => {
            //    AppSetting.Factory.Create(id, value, isReadOnly, createdBy);
            //});

        }
    }
}
