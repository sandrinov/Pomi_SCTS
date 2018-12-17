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

namespace SCTS.IdentityServer4.Controllers.Clients
{
    public class ClientsController : Controller
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClientsController(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            _serviceProvider = serviceProvider;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            using (var scope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var cfg_context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                var clients = cfg_context.Clients.ToList();
                ViewBag.ClientList = clients;
                return View();
            }                
        }

        [HttpGet]
        public IActionResult NewClient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewClient(ClientViewModel newClient)
        {
            List<String> clientSecrets = new List<string>();
            String[] arrClientSecrets = newClient.ClientSecrets.Split(new char[] { ',' });
            clientSecrets = arrClientSecrets.ToList<String>();
            var _ClientSecrets = new List<ClientSecret>();
            foreach (var secret in clientSecrets)
            {
                _ClientSecrets.Add(new ClientSecret() { Value = secret.Sha256() });
            }

            List<String> allowedScopes = new List<string>();
            String[] arrAllowedScopes = newClient.AllowedScopes.Split(new char[] { ',' });
            allowedScopes = arrAllowedScopes.ToList<String>();
            var _AllowedScopes = new List<ClientScope>();
            foreach (var scope in allowedScopes)
            {
                _AllowedScopes.Add(new ClientScope() { Scope = scope });
            }

            List<String> allowedGrantTypes = new List<string>();
            String[] arrAllowedGrantTypess = newClient.AllowedGrantTypes.Split(new char[] { ',' });
            allowedGrantTypes = arrAllowedGrantTypess.ToList<String>();
            var _AllowedGrantTypes = new List<ClientGrantType>();
            foreach (var grantType in allowedGrantTypes)
            {
                switch (grantType.ToLower())  
                {
                    case "hybrid":
                        _AllowedGrantTypes.Add(new ClientGrantType() { GrantType = GrantType.Hybrid });
                        break;
                    case "client_credentials":
                        _AllowedGrantTypes.Add(new ClientGrantType() { GrantType = GrantType.ClientCredentials });
                        break;
                    case "authorization_code":
                        _AllowedGrantTypes.Add(new ClientGrantType() { GrantType = GrantType.AuthorizationCode });
                        break;
                    case "implicit":
                        _AllowedGrantTypes.Add(new ClientGrantType() { GrantType = GrantType.Implicit });
                        break;
                    case "resourceownerpassword":
                        _AllowedGrantTypes.Add(new ClientGrantType() { GrantType = GrantType.ResourceOwnerPassword });
                        break;
                    default:
                        break;
                }   
            }

            #region add client

            using (var scope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var cfg_context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                cfg_context.Clients.Add(new global::IdentityServer4.EntityFramework.Entities.Client()
                {
                    AccessTokenLifetime = newClient.AccessTokenLifetime,
                    AllowRememberConsent = newClient.AllowRememberConsent,
                    AllowOfflineAccess = newClient.AllowOfflineAccess,
                    ClientSecrets = _ClientSecrets,
                    ClientName = newClient.ClientName,
                    ClientId = newClient.ClientId,
                    AllowedScopes = _AllowedScopes,
                    RedirectUris = new List<ClientRedirectUri>
                    {
                        new ClientRedirectUri(){ RedirectUri=newClient.RedirectUris}
                    },
                    PostLogoutRedirectUris = new List<ClientPostLogoutRedirectUri>
                    {
                        new ClientPostLogoutRedirectUri(){ PostLogoutRedirectUri = newClient.PostLogoutRedirectUris }
                    },
                    AllowedGrantTypes = _AllowedGrantTypes
                });
                cfg_context.SaveChanges();
            }
            #endregion

            return RedirectToAction("Index"); 
        }
    }
}