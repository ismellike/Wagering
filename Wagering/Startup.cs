using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VueCliMiddleware;
using Wagering.Models;

namespace Wagering
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
      services.AddDbContext<ApplicationDbContext>(options =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
      });

      services.AddDefaultIdentity<ApplicationUser>()
          .AddEntityFrameworkStores<ApplicationDbContext>();

      services.AddIdentityServer()
          .AddApiAuthorization<ApplicationUser, ApplicationDbContext>()
          .AddProfileService<ProfileService>();

      services.AddAuthentication()
          .AddGoogle(options =>
          {
            IConfigurationSection section =
                      Configuration.GetSection("Authentication:Google");

            options.ClientId = section["ClientId"];
            options.ClientSecret = section["ClientSecret"];
          })
          .AddTwitter(options =>
          {
            IConfigurationSection section =
                      Configuration.GetSection("Authentication:Twitter");

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
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
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
