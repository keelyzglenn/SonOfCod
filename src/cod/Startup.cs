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
                Title = "PACIFIC SEAFOOD HIRES NEW DIRECTOR OF MARKETING",
                Text = "Lorin will focus on the top strategic marketing initiatives for the company, including innovation, Go - to - Market strategy, and awareness for Pacific Seafood. Lorin will also manage the marketing services team which develops all packaging and sales materials.",
                AdditionalInfo = "PORTLAND, Ore. -- April, 16. 2017",
                ImagePath = "http://presidiosports.com/wp-content/uploads/2013/12/Crab-Fishing.jpg",
                MarketingId = 1,

            };
            context.Posts.Add(autoPost1);

            var autoPost2 = new Models.Post
            {
                Title = "PACIFIC SEAFOOD ASKED TO BUY TRIDENT SURIMI PLANT",
                Text = "Trident Seafoods Corporation has approached Pacific Seafood Group about buying its surimi processing plant on Newport’s famed “working waterfront.” The Trident facility has been financially unprofitable since 2011.",
                AdditionalInfo = "NEWPORT, Ore. – April 10, 2017",
                ImagePath = "https://www.pacseafood.com/images/default-source/default-album/shutterstock_43587886.jpg",
                MarketingId = 1,

            };
            context.Posts.Add(autoPost2);

            var autoPost3 = new Models.Post
            {
                Title = "PACIFIC SEAFOOD HIRES FISHERIES POLICY ANALYST",
                Text = "Pacific Seafood Group, a vertically integrated seafood harvesting, processing and distribution company headquartered in Clackamas, Oregon, recently hired former Ventura County Commercial Fishermen’s Association President, Jon Gonzalez, to handle national fisheries policy advocacy for the company.",
                AdditionalInfo = "Portland, Ore. – March 28, 2017",
                ImagePath = "http://www.returnofkings.com/wp-content/uploads/2016/03/commercial-fisherman-on-boat.jpg",
                MarketingId = 1,

            };
            context.Posts.Add(autoPost3);

            context.SaveChanges();
        }
    }
}