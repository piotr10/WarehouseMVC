using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReflectionIT.Mvc.Paging;
using WarehouseMVC.Application;
using WarehouseMVC.Application.ViewModel.Customer;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Infrastructure;
using WarehouseMVC.Infrastructure.Repositories;

namespace WarehouseMVC.Web
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
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<Context>();
            
            services.AddApplication(); // For DependencyInjection Application Project
            services.AddInfrastructure(); // For DependencyInjection Infrastructure Project

            services.AddTransient<Context>();

            //services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddControllersWithViews();

            services.AddRazorPages();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true; //czy jest wymaga liczba?
                options.Password.RequiredLength = 8; //czy bêdzie wymagana okreœlona d³ugoœæ
                options.Password.RequireLowercase = true; //czy bêdzie wymagana ma³a litera
                options.Password.RequireUppercase = true; //czy bêdzie wymagana wielka litera
                options.Password.RequiredUniqueChars = 1; //ile jest wymaganych znaków specjalnych w haœle

                options.SignIn.RequireConfirmedEmail = false; //czy jest wymagane potwierdzenie email
            });
            
            //Wstêpnie wy³¹czone, ze wzglêdu na nieregularne korzystanie z aplikacji i generowanie tokena
            // Authentication - Google
            //services.AddAuthentication().AddGoogle(options =>
            //    {
            //        IConfigurationSection googleAuthNSection =
            //            Configuration.GetSection("Authentication:Google");
            //
            //        options.ClientId = googleAuthNSection["ClientId"];
            //        options.ClientSecret = googleAuthNSection["ClientSecret"];
            //    });

            // Authentication - Facebook
            //services.AddAuthentication().AddFacebook(facebookOptions =>
            //{
            //    facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
            //    facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            //});

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanAddNewEmployee", policy =>
                    policy.RequireClaim("AddNewEmployee"));
                options.AddPolicy("CanViewEmployee", policy =>
                    policy.RequireClaim("ViewEmployee"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env ,ILoggerFactory loggerFactory)
        {
            //Rejestracja Logów
            loggerFactory.AddFile("Logs/myLog-{Date}.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
