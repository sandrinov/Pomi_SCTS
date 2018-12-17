using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCTS.IdentityServer4.Controllers.ApiResources
{
    public class ApiResourceViewModel
    {
        public String Name { get; set; }
        public String Secrets { get; set; }
        public String Claims { get; set; }
        public String Scopes { get; set; }

        public ApiResourceViewModel()
        {

        }

    }
}
