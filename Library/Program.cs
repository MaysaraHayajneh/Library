using Hangfire;
using Library.Data;
using Library.IRepository;
using Library.Models;
using Library.Repository;
using Library.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Formatting.Json;
using Library.Application.Services.HomeService;
using System.Globalization;


namespace Library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            // Add services to the container.
            

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<LibraryDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IShelfRepository, ShelfRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IHomeService,HomeService>();
            //adding hangfire services
            builder.Services.AddHangfire(x=>x.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddHangfireServer();

           

            //configure add service of signalR
            builder.Services.AddSignalR();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
				options.Password.RequiredUniqueChars = 0;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireLowercase = false;
				options.Password.RequiredLength = 9;
				options.Password.RequireUppercase = false;

			}).AddEntityFrameworkStores<LibraryDbContext>().AddDefaultTokenProviders();

            //localization and Globalization

            builder.Services.AddLocalization(op => op.ResourcesPath = "Resources");

            builder.Services.AddMvc(confiq =>
            {
                // i inforced that all users should be authintecated(loged in) to be able to access the applicartiion
                var policy=new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                confiq.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).
            AddDataAnnotationsLocalization();

            //create policy that contains claim and the user should be has this poliy to do the action

            builder.Services.AddAuthorization(policy => {

                policy.AddPolicy("DeletRolePolicy", policy => policy.RequireClaim("Delete Role","true"));

                policy.AddPolicy("EditRolePolicy", policy => policy.AddRequirements(new ManageAdminRolesAndClaimsRequirment()));


                policy.AddPolicy("AddRolePolicy", policy => policy.RequireClaim("Create Role","true"));

                //if i want a custom policy
                policy.AddPolicy("test", policy => policy.RequireAssertion(context =>
                
                    context.User.IsInRole("Admin") &&
                    context.User.HasClaim(claim => claim.Type == "test" && claim.Value == "true") ||
                    context.User.IsInRole("super Admin")

				));
               
            });
            //add service that creae instance for IAuthorizatonHandler

            builder.Services.AddSingleton<IAuthorizationHandler, CanEditOnlyOtherAdminRolesAndClaimsHandler>();
            builder.Services.AddSingleton<IAuthorizationHandler, SuperAdminHandler>();




            builder.Services.Configure<RequestLocalizationOptions>(option =>
            {
                var Cultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("fr-CA"),
                    new CultureInfo("ar-JO"),
                };
                option.DefaultRequestCulture= new RequestCulture("en-US");
                option.SupportedCultures = Cultures;
                option.SupportedUICultures = Cultures;
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

			
			app.UseRequestLocalization(app.Services.
            GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseAuthorization();
            app.UseHangfireDashboard("/dashbord");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );
			app.MapHub<ChatHub>("/chatHub");

            app.Run();
        }
    }
}
