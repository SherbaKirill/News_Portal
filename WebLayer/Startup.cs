using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataLayer;
using DataLayer.Models;
using BusinessLayer.Interfaces;
using BusinessLayer.Service;
using DataLayer.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebLayer.Models;

namespace WebLayer
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
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<DBContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<UserViewModel, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient<IRepository<News>, NewsRepository>();
            services.AddTransient<IRepository<Category>, CategoryRepository>();
            services.AddTransient<ISearchNewsService, SearchNewsService>();
            services.AddTransient<IManageNewsService, ManageNewsService>();
            services.AddTransient<ISearchCategoryService, SearchCategoryService>();
            services.AddTransient<IManageCategoryService, ManageCategoryService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/News/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            using (var score = app.ApplicationServices.CreateScope())
            {
                DBContext context = score.ServiceProvider.GetRequiredService<DBContext>();
                DBObject.Initial(context);
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=News}/{action=Index}");
                endpoints.MapControllerRoute(
                    name: "categoryFilter",
                    pattern: "News/List/{category?}", defaults: new { Controller = "News", action = "Index" });
                endpoints.MapRazorPages();
            });
        }
    }
}
