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
using Microsoft.AspNetCore.Hosting;
using FavourPal.Profiles;

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

            //move out to config function
            services.AddAutoMapper(c => c.AddProfile<DomainToViewMapperProfile>(), typeof(Startup));
            services.AddDbContext<FavourPalDbContext>(option => option.UseSqlServer("DefaultConnection", b => b.MigrationsAssembly("FavourPal.Api")));
            services.AddScoped<IFavourPalDbContext>(sp => sp.GetRequiredService<FavourPalDbContext>());

            //move out to config function
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<FavourPalDbContext>()
                .AddDefaultTokenProviders();

            MvcOptions options = new MvcOptions();
            options.EnableEndpointRouting = false;

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
