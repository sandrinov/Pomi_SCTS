using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCTS.IdentityServer4.Controllers.Clients
{
    public class ClientViewModel
    {
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string ClientId { get; set; }
        public int AccessTokenLifetime { get; set; }
        public bool AllowOfflineAccess { get; set; }
        public bool AllowRememberConsent { get; set; }
        public String ClientSecrets { get; set; }
        [Required]
        public String AllowedScopes { get; set; }
        [Required]
        public string RedirectUris { get; set; }
        [Required]
        public string PostLogoutRedirectUris { get; set; }
        [Required]
        public string AllowedGrantTypes { get; set; }


        
    }
}
