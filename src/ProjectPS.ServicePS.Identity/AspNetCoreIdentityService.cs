using Microsoft.AspNetCore.Http;
using ProjectPS.ServicePS.Components.Gateways;
using System;
using System.Linq;

namespace ProjectPS.ServicePS.Identity
{
    public class AspNetCoreIdentityService : IUserIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AspNetCoreIdentityService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public string GetIdentity()
        {
            return "userId";
        }
    }
}
