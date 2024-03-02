using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBuilder.Models;
using WebsiteBuilder.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebsiteBuilder.Servicesx;
using WebsiteBuilder.Helpers;
using Microsoft.AspNetCore.Authorization;
using WebsiteBuilder.Handler;
using WebsiteBuilder.Data;
using Microsoft.Extensions.DependencyInjection;
namespace WebsiteBuilder
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAntiforgery(options => options.HeaderName = "XSRF-TOKEN");
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            services.Configure<TwilioSettings>(Configuration.GetSection("Twilio"));
            services.AddScoped<SmsService>();
            services.AddScoped<OtpService>();

            services.AddControllersWithViews();

            services.AddScoped<WebsiteConstraintService>();

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            // services.AddTransient<LeftSideBarViewComponent>();
            services.AddSingleton<IAuthorizationHandler, EmailRequirementHandler>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("EmailPolicy", policy =>
                {
                    policy.Requirements.Add(new EmailRequirement("contactmaitraentertainment@gmail.com"));
                });
            });

           

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               

        .AddCookie(options =>
        {
            options.LoginPath = "/User/Login"; // Specify your login page
            options.LogoutPath = "/Account/Logout";
            options.AccessDeniedPath = "/User/AccessDenied"; // Optional
        });




            // Configure authentication and authorization policies as needed.

            // Inside the Configure method
            services.AddHealthChecks();

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {

            RolesSeeder.Initialize(serviceProvider).Wait();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
           
            app.UseEndpoints(endpoints =>
            {
                


               

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=HomePage}/{id?}");


               
            });

         

        }
    }
}
