// <copyright file="Startup.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using HelloWorldWeb.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HelloWorldWeb.Data;
using HelloWorldWeb.Controllers;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;
using HelloWorldWebApp.Services;
using System.Threading.Tasks;

namespace HelloWorldWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public static string ConvertHerokuStringToAspNetString(string herokuConnectionString)
        {
            var databaseUri = new Uri(herokuConnectionString);
            string[] databaseUriUsername = databaseUri.UserInfo.Split(":");

            return $"Host={databaseUri.Host};Port={databaseUri.Port};Database={databaseUri.LocalPath[1..]};User Id={databaseUriUsername[0]};Password={databaseUriUsername[1]};Pooling=true;SSL Mode=Require;TrustServerCertificate=True;";
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Services for interfaces
            services.AddControllersWithViews();
            services.AddSingleton<IWeatherControllerSettings, WeatherControllerSettings>();
            services.AddSingleton<IBroadcastService, BroadcastService>();
            services.AddScoped<ITeamService, DbTeamService>();
            services.AddSingleton<ITimeService, TimeService>();
            services.AddSignalR();

            //add swagger for API documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hello World API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });

            //Extracting proper connection
            string databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

            databaseUrl = databaseUrl != null ? ConvertHerokuStringToAspNetString(databaseUrl) : 
                Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(databaseUrl));
            services.AddDatabaseDeveloperPageExceptionFilter();

            //Required confirmed account for users
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            //Assigning roles
            AssignRoleProgramaticaly(services.BuildServiceProvider());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));

                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

                endpoints.MapHub<MessageHub>("/messagehub");
            });            
        }

        private static async void AssignRoleProgramaticaly(IServiceProvider services)
        {

            //Adding roles automatically
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            bool x = await roleManager.RoleExistsAsync("User");
            if (!x)
            {
                var roleUser = new IdentityRole
                {
                    Name = "User"
                };
                await roleManager.CreateAsync(roleUser);
            }
            bool y = await roleManager.RoleExistsAsync("Administrator");
            if (!y)
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "Administrator"
                };
                await roleManager.CreateAsync(roleAdmin);
            }

            //Adding Admin role automatically to the name 
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var user = await userManager.FindByNameAsync("patrickpacurar@yahoo.com");
            await userManager.AddToRoleAsync(user, "Administrator");
        }
    }
}