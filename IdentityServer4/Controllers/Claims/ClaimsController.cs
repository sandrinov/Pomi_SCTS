using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SCTS.IdentityServer4.Data;
using SCTS.IdentityServer4.Models;

namespace SCTS.IdentityServer4.Controllers.Claims
{
    public class ClaimsController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClaimsController(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            _serviceProvider = serviceProvider;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            using (var scope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var cfg_context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var users = cfg_context.Users.ToList();
                ViewBag.UserList = users;
                return View();
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult>  Index(FormClaimsModel model)
        {
            using (var scope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var cfg_context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var users = cfg_context.Users.ToList();
                ViewBag.UserList = users;
            }

            if (ModelState.IsValid)
            {
                using (var scope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var app_context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var newUser = await _userManager.FindByIdAsync(model.Id);

                    if (model.ClaimType1 != null)
                    {
                        IdentityUserClaim<String> claim = new IdentityUserClaim<string>() { ClaimType = model.ClaimType1, ClaimValue = model.ClaimValue1, UserId = model.Id };
                        app_context.UserClaims.Add(claim);
                    }
                    if (model.ClaimType2 != null)
                    {
                        IdentityUserClaim<String> claim = new IdentityUserClaim<string>() { ClaimType = model.ClaimType2, ClaimValue = model.ClaimValue2, UserId = model.Id };
                        app_context.UserClaims.Add(claim);
                    }
                    if (model.ClaimType3 != null)
                    {
                        IdentityUserClaim<String> claim = new IdentityUserClaim<string>() { ClaimType = model.ClaimType3, ClaimValue = model.ClaimValue3, UserId = model.Id };
                        app_context.UserClaims.Add(claim);
                    }
                    if (model.ClaimType4 != null)
                    {
                        IdentityUserClaim<String> claim = new IdentityUserClaim<string>() { ClaimType = model.ClaimType4, ClaimValue = model.ClaimValue4, UserId = model.Id };
                        app_context.UserClaims.Add(claim);
                    }
                    if (model.ClaimType5 != null)
                    {
                        IdentityUserClaim<String> claim = new IdentityUserClaim<string>() { ClaimType = model.ClaimType5, ClaimValue = model.ClaimValue5, UserId = model.Id };
                        app_context.UserClaims.Add(claim);
                    }
                    if (model.ClaimType6 != null)
                    {
                        IdentityUserClaim<String> claim = new IdentityUserClaim<string>() { ClaimType = model.ClaimType6, ClaimValue = model.ClaimValue6, UserId = model.Id };
                        app_context.UserClaims.Add(claim);
                    }
                    if (model.ClaimType7 != null)
                    {
                        IdentityUserClaim<String> claim = new IdentityUserClaim<string>() { ClaimType = model.ClaimType7, ClaimValue = model.ClaimValue7, UserId = model.Id };
                        app_context.UserClaims.Add(claim);
                    }
                    if (model.ClaimType8 != null)
                    {
                        IdentityUserClaim<String> claim = new IdentityUserClaim<string>() { ClaimType = model.ClaimType8, ClaimValue = model.ClaimValue8, UserId = model.Id };
                        app_context.UserClaims.Add(claim);
                    }
                    if (model.ClaimType9 != null)
                    {
                        IdentityUserClaim<String> claim = new IdentityUserClaim<string>() { ClaimType = model.ClaimType9, ClaimValue = model.ClaimValue9, UserId = model.Id };
                        app_context.UserClaims.Add(claim);
                    }
                    if (model.ClaimType10 != null)
                    {
                        IdentityUserClaim<String> claim = new IdentityUserClaim<string>() { ClaimType = model.ClaimType10, ClaimValue = model.ClaimValue10, UserId = model.Id };
                        app_context.UserClaims.Add(claim);
                    }

                    app_context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                } 
            }

            return View(model);
        }

        public IActionResult ClientClaims()
        {
            return View();
        }
    }
}