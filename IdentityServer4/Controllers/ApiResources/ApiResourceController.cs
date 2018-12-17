using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;

using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SCTS.IdentityServer4.Controllers.ApiResources;
using SCTS.IdentityServer4.Models;

namespace SCTS.IdentityServer4.Controllers
{
    public class ApiResourceController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApiResourceController(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            _serviceProvider = serviceProvider;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(ApiResourceViewModel model)
        {
            if (model != null)
            {
                List<String> apiSecrets = new List<string>();
                String[] arrapiSecrets = model.Secrets.Split(new char[] { ',' });
                apiSecrets = arrapiSecrets.ToList<String>();
                var _ApiSecrets = new List<global::IdentityServer4.EntityFramework.Entities.ApiSecret>();
                foreach (var secret in apiSecrets)
                {
                    _ApiSecrets.Add(new global::IdentityServer4.EntityFramework.Entities.ApiSecret() { Value = secret.Sha256() });
                }

                List<String> claims = new List<string>();
                String[] arrClaims = model.Claims.Split(new char[] { ',' });
                claims = arrClaims.ToList<String>();
                var _Claims = new List<global::IdentityServer4.EntityFramework.Entities.ApiResourceClaim>();
                foreach (var claim in claims)
                {
                    switch (claim.ToLower())
                    {
                        case "name":
                            _Claims.Add(new global::IdentityServer4.EntityFramework.Entities.ApiResourceClaim() { Type = JwtClaimTypes.Name });
                            break;
                        case "email":
                            _Claims.Add(new global::IdentityServer4.EntityFramework.Entities.ApiResourceClaim() { Type = JwtClaimTypes.Email });
                            break;
                        case "role":
                            _Claims.Add(new global::IdentityServer4.EntityFramework.Entities.ApiResourceClaim() { Type = JwtClaimTypes.Role });
                            break;
                        case "id":
                            _Claims.Add(new global::IdentityServer4.EntityFramework.Entities.ApiResourceClaim() { Type = JwtClaimTypes.Id });
                            break;
                        default:
                            break;
                    }
                }

                List<String> allowedScopes = new List<string>();
                String[] arrAllowedScopes = model.Scopes.Split(new char[] { ',' });
                allowedScopes = arrAllowedScopes.ToList<String>();
                var _AllowedScopes = new List<global::IdentityServer4.EntityFramework.Entities.ApiScope>();
                foreach (var scope in allowedScopes)
                {
                    _AllowedScopes.Add(new global::IdentityServer4.EntityFramework.Entities.ApiScope() { Name = scope, DisplayName = scope });
                }

                using (var scope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var cfg_context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

                    var resource = new global::IdentityServer4.EntityFramework.Entities.ApiResource();
                    resource.Name = model.Name;
                    resource.DisplayName = model.Name;
                    resource.UserClaims = _Claims;
                    resource.Scopes = _AllowedScopes;
                    resource.Secrets = _ApiSecrets;
                    cfg_context.ApiResources.Add(resource);

                    cfg_context.SaveChanges();
                }
            }
            return View();
        }
    }
}