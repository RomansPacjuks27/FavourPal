using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FavourPal.Api.Models;
using System.Globalization;
using FavourPal.Api.Interfaces;
using FavourPal.Api.Services;

namespace FavourPal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            System.Globalization.CultureInfo customCulture = new CultureInfo("en-US");
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            CultureInfo.DefaultThreadCurrentCulture = customCulture;
            CultureInfo.DefaultThreadCurrentUICulture = customCulture;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(option =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                option.CheckConsentNeeded = context => true;
                option.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<FavourPalDbContext>(option => option.UseSqlServer("DefaultConnection"));
            services.AddScoped<IFavourPalDbContext>(sp => sp.GetRequiredService<FavourPalDbContext>());

            services.AddScoped<IAccountService, AccountService>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<FavourPalDbContext>();
            //services.AddControllersWithViews().AddRazorRuntimeCompilation();

            MvcOptions options = new MvcOptions();
            options.EnableEndpointRouting = false;

            services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "Request",
                //    template: "Request/{action}/{id?}",
                //    defaults: new { controller = "Home" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
