using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using stellar_dotnet_sdk;
using VueCliMiddleware;
using Wagering.Models;
using Wagering.Services;
#nullable disable

namespace Wagering
{
    public class Startup
    {
        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;
        }

        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("Application"));
            });
            services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("Identity"));
            });

            services.AddDefaultIdentity<ApplicationUser>(x =>
            {
                x.User.RequireUniqueEmail = true;
                x.SignIn.RequireConfirmedAccount = true;
            }).AddEntityFrameworkStores<IdentityDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, IdentityDbContext>()
                .AddProfileService<ProfileService>();

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    IConfigurationSection section =
                        _config.GetSection("Authentication:Google");

                    options.ClientId = section["ClientId"];
                    options.ClientSecret = section["ClientSecret"];
                })
                .AddFacebook(options =>
                {
                    IConfigurationSection section =
                        _config.GetSection("Authentication:Facebook");

                    options.AppId = section["ClientId"];
                    options.AppSecret = section["ClientSecret"];
                    options.AccessDeniedPath = "/Error";
                })
                .AddTwitter(options =>
                {
                    IConfigurationSection section =
                        _config.GetSection("Authentication:Twitter");

                    options.ConsumerKey = section["ClientId"];
                    options.ConsumerSecret = section["ClientSecret"];
                })
                .AddIdentityServerJwt();

            services.Configure<JwtBearerOptions>(
                IdentityServerJwtConstants.IdentityServerJwtBearerScheme,
                options =>
                {
                    var received = options.Events.OnMessageReceived;
                    options.Events.OnMessageReceived = async context =>
                    {
                        await received(context);
                        var accessToken = context.Request.Query["access_token"];

                        // If the request is for our hub...
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) &&
                            (path.StartsWithSegments("/group-hub")))
                        {
                            // Read the token out of the query string
                            context.Token = accessToken;
                        }
                    };
                });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddMvc()
               .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSignalR();

            string network = _env.IsDevelopment() ? "https://horizon-testnet.stellar.org/" : "https://horizon.stellar.org/";
            services.AddSingleton(new Server(network));
            services.AddScoped<IEmailSender, EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<Hubs.GroupHub>("/group-hub");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapToVueCliProxy(
                    "{*path}",
                    new SpaOptions { SourcePath = "ClientApp" },
                    npmScript: (System.Diagnostics.Debugger.IsAttached) ? "serve" : null,
                    regex: "Compiled successfully",
                    forceKill: true
                    );
            });
        }
    }
}
