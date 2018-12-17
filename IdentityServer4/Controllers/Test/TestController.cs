using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCTS.IdentityServer4.Data;
using SCTS.IdentityServer4.Models;

namespace SCTS.IdentityServer4.Controllers.Test
{
    public class TestController : Controller
    {

        private ApplicationDbContext _dbContext;
        private ConfigurationDbContext _cfg_ctx;
        private PersistedGrantDbContext _prst_cfg;
        private String MVCWebSite = "MVCWebSite";
        private IServiceProvider _serviceProvider;
        private IServiceCollection _services;
        private readonly UserManager<ApplicationUser> _userManager;


        public TestController(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            //_dbContext = dbContext;
            //_cfg_ctx = cfg_ctx;
            //_prst_cfg = prst_cfg;
            _serviceProvider = serviceProvider;
            _userManager = userManager;
        }

        public IActionResult Sample()
        {
            return View();
        }

        public IActionResult StartAction()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StartAction(string returnUrl = null)
        {

            using (var scope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                #region add client
                var cfg_context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                cfg_context.Clients.Add(new global::IdentityServer4.EntityFramework.Entities.Client()
                {
                    AccessTokenLifetime = 3600,
                    AllowRememberConsent = true,
                    AllowOfflineAccess = true,
                    ClientSecrets = new List<ClientSecret>
                {
                    new ClientSecret(){ Value = "secret".Sha256()},
                    new ClientSecret{ Value = "chatsecret".Sha256()}
                },
                    ClientName = "MVC Client",
                    ClientId = "mvc",
                    AllowedScopes = new List<ClientScope>
                {
                    new ClientScope(){ Scope = "openid" },
                    new ClientScope(){ Scope = "profile" },
                    new ClientScope(){ Scope = "roles" },
                    new ClientScope(){ Scope = "api1" }
                },
                    RedirectUris = new List<ClientRedirectUri>
                {
                    new ClientRedirectUri(){ RedirectUri=this.MVCWebSite}
                },
                    PostLogoutRedirectUris = new List<ClientPostLogoutRedirectUri>
                {
                    new ClientPostLogoutRedirectUri(){ PostLogoutRedirectUri = this.MVCWebSite }
                },
                    AllowedGrantTypes = new List<ClientGrantType>
                {
                   new ClientGrantType() { GrantType = GrantType.Hybrid},
                   new ClientGrantType() { GrantType = GrantType.ClientCredentials}
                }
                });
                cfg_context.SaveChanges();
                #endregion

                var app_context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var user = new ApplicationUser()
                {
                    UserName = "alice",
                    Email = "alice.rossi@pomiager.com",
                };

                var result = await _userManager.CreateAsync(user, "Pa$$w0rd");
                if (result.Succeeded)
                {
                    var newUser = await _userManager.FindByNameAsync("alice");
                    IdentityUserClaim <String> claim1 = new IdentityUserClaim<string>() { ClaimType = ClaimTypes.Name, ClaimValue = "alice", UserId = newUser.Id };
                    IdentityUserClaim<String> claim2 = new IdentityUserClaim<string>() { ClaimType = ClaimTypes.Webpage, ClaimValue = "http://www.alice.com/index", UserId = newUser.Id };

                   

                    app_context.UserClaims.Add(claim1);
                    app_context.UserClaims.Add(claim2);
                    app_context.SaveChanges();
                }
                    

               


            }

            return View();
        }
    }
}