using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SCTS.IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SCTS.IdentityServer
{
    public class SCTSProfileService : IProfileService
    {
        protected UserManager<ApplicationUser> _userManager;

        private ILogger Log { get; }

        public SCTSProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.LogProfileRequest(Log);
            //>Processing
            var user = _userManager.GetUserAsync(context.Subject).Result;

            var claims = new List<Claim>
            {
            new Claim("BC_Address", user.BC_Address),
            };

            context.IssuedClaims.AddRange(claims);
            context.LogIssuedClaims(Log);

            //>Return
            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            //>Processing
            var user = _userManager.GetUserAsync(context.Subject).Result;

            context.IsActive = (user != null);

            //>Return
            return Task.FromResult(0);
        }
    }
}
