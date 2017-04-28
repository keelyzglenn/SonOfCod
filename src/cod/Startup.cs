using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using cod.Models;

namespace cod
{

    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SonOfCodSeafoodContext>(opt => opt.UseInMemoryDatabase());
            services.AddMvc();
            services.AddEntityFramework()
                .AddDbContext<SonOfCodSeafoodContext>(options =>
                    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SonOfCodSeafoodContext>()
                .AddDefaultTokenProviders();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseIdentity();
            app.UseStaticFiles();
            var newContext = app.ApplicationServices.GetService<SonOfCodSeafoodContext>();
            AddTestData(newContext);


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("error");
            });
        }

        private static void AddTestData(SonOfCodSeafoodContext context)
        {
            var autoPost1 = new Models.Post
            {
                Title = "Tes1",
                Text = "test text",
                AdditionalInfo = "text date",
                ImagePath = "http://www.photographyblogger.net/wp-content/uploads/2013/07/16-fisherman.jpg",

            };
            context.Posts.Add(autoPost1);

            var autoPost2 = new Models.Post
            {
                Title = "Tes2",
                Text = "test text",
                AdditionalInfo = "text date",
                ImagePath = "http://www.photographyblogger.net/wp-content/uploads/2013/07/16-fisherman.jpg",

            };
            context.Posts.Add(autoPost2);

            var autoPost3 = new Models.Post
            {
                Title = "Tes3",
                Text = "test text",
                AdditionalInfo = "text date",
                ImagePath = "http://www.photographyblogger.net/wp-content/uploads/2013/07/16-fisherman.jpg",

            };
            context.Posts.Add(autoPost3);

            context.SaveChanges();
        }
    }
}