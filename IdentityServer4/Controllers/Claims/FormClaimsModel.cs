using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCTS.IdentityServer4.Controllers.Claims
{
    public class FormClaimsModel
    {
        public String Id { get; set; }
        [DefaultClaimType]
        public String ClaimType1 { get; set; }
        public String ClaimValue1 { get; set; }
        [DefaultClaimType]
        public String ClaimType2 { get; set; }
        public String ClaimValue2 { get; set; }
        [DefaultClaimType]
        public String ClaimType3 { get; set; }
        public String ClaimValue3 { get; set; }
        public String ClaimType4 { get; set; }
        public String ClaimValue4 { get; set; }
        public String ClaimType5 { get; set; }
        public String ClaimValue5 { get; set; }
        public String ClaimType6 { get; set; }
        public String ClaimValue6 { get; set; }
        public String ClaimType7 { get; set; }
        public String ClaimValue7 { get; set; }
        public String ClaimType8 { get; set; }
        public String ClaimValue8 { get; set; }
        public String ClaimType9 { get; set; }
        public String ClaimValue9 { get; set; }
        public String ClaimType10 { get; set; }
        public String ClaimValue10 { get; set; }
    }
}
