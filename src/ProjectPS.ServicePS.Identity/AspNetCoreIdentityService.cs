using ProjectPS.ServicePS.Components.Gateways;
using System;
using System.Linq;

namespace ProjectPS.ServicePS.Identity
{
    public class AspNetCoreIdentityService : IUserIdentityService
    {
        public string GetIdentity()
        {
            return "userId";
        }
    }
}
