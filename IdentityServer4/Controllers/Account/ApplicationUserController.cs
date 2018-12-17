using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SCTS.IdentityServer4.Data;
using SCTS.IdentityServer4.Models;

namespace IdentityServer.Controllers.Account
{
    public class ApplicationUserController : Controller
    {
        ApplicationDbContext _ctx;

        public ApplicationUserController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        //[Authorize]
        public IActionResult GetResult(string bc_address)
        {
            var user = _ctx.Users.Where(u => u.BC_Address == bc_address).FirstOrDefault();
            if (user != null)
                return Json(new { BC_Address = bc_address, user.UserName });
            else
                return Json(new { BC_Address = bc_address, UserName = "User Not Found" });

        }
    }
}