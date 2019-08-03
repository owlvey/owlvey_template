using ProjectPS.ServicePS.IntegrationTests.Setup;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProjectPS.ServicePS.IntegrationTests.Setup
{
    [CollectionDefinition("API Test Collection")]
    public class IntegrationTestCollection : ICollectionFixture<TestSetup>
    {

    }
}
