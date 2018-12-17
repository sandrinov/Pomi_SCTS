using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCTS.IdentityServer4.Data;
using SCTS.IdentityServer4.Models;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using IdentityServer4;
using IdentityServer4.Services;
using IdentityServer4.AspNetIdentity;
using SCTS.IdentityServer;
using IdentityServer4.EntityFramework.DbContexts;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityServerWithAspNetIdentitySqlite;

namespace SCTS.IdentityServer4
{

    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //TODO Connection string da aggiornare in ogni progetto!
            string connectionString = Configuration.GetConnectionString("SCTSConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IISOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
            });
            services.Configure<IdentityOptions>(options =>
            {
                var scheme = options.ClaimsIdentity;
            });

            services.AddTransient<IProfileService, IdentityWithAdditionalClaimsProfileService>();


            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
                .AddAspNetIdentity<ApplicationUser>()
                // this adds the config data from DB (clients, resources)
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b =>
                        b.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                // this adds the operational data from DB (codes, tokens, consents)
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b =>
                        b.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly(migrationsAssembly));

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30; // frequency in seconds to cleanup stale grants. 15 is useful during debugging
                })
                .AddProfileService<IdentityWithAdditionalClaimsProfileService>();

            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                //builder.AddSigningCredential()
                throw new Exception("need to configure key material");
            }

            services.AddAuthentication()
                    .AddOpenIdConnect("oidc", "OpenID Connect", options =>
                {

                    options.Events = new Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents {

                        OnTokenValidated = async ctx =>
                        {
                            var db = ctx.HttpContext.RequestServices.GetRequiredService<ConfigurationDbContext>();

                            var db2 = ctx.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
                            //var u = await db2.Users.FirstOrDefaultAsync(u=>u.UserName == ctx.Princip)


                            var claims = new List<Claim>
                            {
                                new Claim ("BC_Address", "1234")
                            };
                            var appIdentity = new ClaimsIdentity(claims);

                            ctx.Principal.AddIdentity(appIdentity);
                        }
                    };
                    options.Authority = (Configuration.GetSection("Endpoints")["Authority"]).ToString();
                    options.ClientId = "hybrid";
                    options.SaveTokens = true;
                    

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "role",
                    };
                });

           

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
        }
    }

}
