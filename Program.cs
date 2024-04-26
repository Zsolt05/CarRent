using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using CarRent.Data;
using CarRent.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using CarRent.Models.Entities;



namespace CarRent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            /*ilder.Services.AddDbContext<ApplicationDbContext>(
                options=>options.UseSqlServer(connectionString)
                );*/

            builder.Services.AddSqlite<ApplicationDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

            /*builder.Services.AddIdentity<Models.Entities.User, IdentityRole>(
                options =>
                {
                    options.Password.RequiredUniqueChars = 1;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase= false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();*/
            //auth. service hozzaadasa
            //builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                // Identity beállítások
            })
            .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                {
                    policy.RequireAuthenticatedUser();
                });
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
