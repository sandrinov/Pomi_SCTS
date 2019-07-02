using IdentityModel.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;

namespace IQC_Dapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            Uri endPointA = new Uri((Configuration.GetSection("Endpoints")["ApiServerBaseAddress"]).ToString()); // this is the endpoint HttpClient will hit
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = endPointA,
            };

            ServicePointManager.FindServicePoint(endPointA).ConnectionLeaseTimeout = 60000; // sixty seconds

            //services.AddSingleton<HttpClient>(httpClient);
            services.AddMvc();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
               .AddCookie("Cookies")
               .AddOpenIdConnect("oidc", options =>
               {
                   options.SignInScheme = "Cookies";

                   options.Authority = (Configuration.GetSection("Endpoints")["Authority"]).ToString();
                   options.RequireHttpsMetadata = false;

                   options.ClientId = "mvc";
                   options.ClientSecret = "secret";
                   options.ResponseType = "code id_token token";

                   options.SaveTokens = true;
                   options.GetClaimsFromUserInfoEndpoint = true;

                   options.Scope.Add("api1");
                   options.Scope.Add("offline_access");

                   options.Events = new Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents()
                   {

                       OnTokenResponseReceived = async x =>
                       {
                           var accessToken = x.TokenEndpointResponse.AccessToken;
                           var user = x.Principal.Identity.AuthenticationType;



                           var id = x.Principal.Identity;

                           var nid = new ClaimsIdentity(
                               id.AuthenticationType,
                               ClaimTypes.GivenName,
                               ClaimTypes.Role);

                           var authority = (Configuration.GetSection("Endpoints")["Authority"]).ToString();
                           var userinfo = (Configuration.GetSection("Endpoints")["UserInfo"]).ToString();
                           var userinfoEndpoint = authority + userinfo;

                           var userInfoClient = new UserInfoClient(userinfoEndpoint);
                           var userInfo = await userInfoClient.GetAsync(accessToken);

                           IEnumerable<Claim> claims = userInfo.Claims;
                           foreach (var c in claims)
                           {
                               nid.AddClaim(c);
                           }
                           // keep the id_token for logout
                           nid.AddClaim(new Claim("id_token", x.TokenEndpointResponse.IdToken));

                           // add access token for sample API
                           nid.AddClaim(new Claim("access_token", x.TokenEndpointResponse.AccessToken));

                           x.Principal.AddIdentity(nid);
                       }
                   };
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
