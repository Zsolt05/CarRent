using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using CarRent.Data;
using CarRent.Models;
using Microsoft.EntityFrameworkCore;

using CarRent.Services.Init;
using CarRent.Services;



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

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<CarInit>();
            builder.Services.AddScoped<ICarService, CarService>();


            var app = builder.Build();

           

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                ctx.Database.Migrate();
                scope.ServiceProvider.GetRequiredService<CarInit>().Init().Wait();
            }
            using (var scope = app.Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                ctx.Database.Migrate();
                scope.ServiceProvider.GetRequiredService<UserInit>().Init().Wait();
            }
            app.UseCors(x => x
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

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
