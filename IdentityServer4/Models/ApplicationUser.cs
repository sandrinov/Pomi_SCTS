using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SCTS.IdentityServer4.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string BC_Address { get; set; }
    }
}
