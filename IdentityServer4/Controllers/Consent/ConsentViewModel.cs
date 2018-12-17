// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections.Generic;

namespace SCTS.IdentityServer4.UI
{
    public class ConsentViewModel : ConsentInputModel
    {
        public string ClientName { get; set; }
        public string ClientUrl { get; set; }
        public string ClientLogoUrl { get; set; }
        public bool AllowRememberConsent { get; set; }

        public IEnumerable<SCTS.IdentityServer4.UI.ScopeViewModel> IdentityScopes { get; set; }
        public IEnumerable<SCTS.IdentityServer4.UI.ScopeViewModel> ResourceScopes { get; set; }
    }
}
