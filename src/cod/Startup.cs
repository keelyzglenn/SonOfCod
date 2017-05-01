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
            var post1 = new Models.Post
            {
                Title = "PACIFIC SEAFOOD HIRES NEW DIRECTOR OF MARKETING",
                Text = "Lorin will focus on the top strategic marketing initiatives for the company, including innovation, Go - to - Market strategy, and awareness for Pacific Seafood. Lorin will also manage the marketing services team which develops all packaging and sales materials.",
                AdditionalInfo = "PORTLAND, Ore. -- April, 16. 2017",
                ImagePath = "http://presidiosports.com/wp-content/uploads/2013/12/Crab-Fishing.jpg",
                MarketingPageId = 1,

            };
            context.Posts.Add(post1);

            var post2 = new Models.Post
            {
                Title = "PACIFIC SEAFOOD ASKED TO BUY TRIDENT SURIMI PLANT",
                Text = "Trident Seafoods Corporation has approached Pacific Seafood Group about buying its surimi processing plant on Newport’s famed “working waterfront.” The Trident facility has been financially unprofitable since 2011.",
                AdditionalInfo = "NEWPORT, Ore. – April 10, 2017",
                ImagePath = "https://www.pacseafood.com/images/default-source/default-album/shutterstock_43587886.jpg",
                MarketingPageId = 1,

            };
            context.Posts.Add(post2);

            var post3 = new Models.Post
            {
                Title = "PACIFIC SEAFOOD HIRES FISHERIES POLICY ANALYST",
                Text = "Pacific Seafood Group, a vertically integrated seafood harvesting, processing and distribution company headquartered in Clackamas, Oregon, recently hired former Ventura County Commercial Fishermen’s Association President, Jon Gonzalez, to handle national fisheries policy advocacy for the company.",
                AdditionalInfo = "Portland, Ore. – March 28, 2017",
                ImagePath = "http://www.returnofkings.com/wp-content/uploads/2016/03/commercial-fisherman-on-boat.jpg",
                MarketingPageId = 1,

            };
            context.Posts.Add(post3);

            var marketingPage = new Models.MarketingPage
            {
                
                Head = "Son of Cod Seafood",
                HeadImage = "https://www.foxrc.com/frcwp/wp-content/uploads/2012/04/oyster-bar-925x522.jpg",
                AboutTitle = "-Our Story-",
                About = "We expect ourselves to do business right, to lead by example and to help out when we are needed. It is our company philosophy that guides our everyday decisions. It is good to be responsible, not just because it is the right thing to do, but because it also sets the bar for our company’s commitment to ensure that the communities in which we work and live will continue to prosper.",
                FeatureOneTitle = "Serve it your Way.",
                FeatureOneImage = "https://cdn.pixabay.com/photo/2016/02/19/11/32/oysters-1209767_960_720.jpg",
                FeatureOneText = "We provide you with the best ingrediates, you cook it up how you like it! Check out our recipe book for news ways to intigrate the freshest ingrediates into your diet!",
                FeatureTwoTitle = "Check Us Out at the Local Fish Market",
                FeatureTwoImage = "https://cdn.pixabay.com/photo/2016/11/19/21/05/fish-1841183_960_720.jpg",
                FeatureTwoText = "We are a local, hard working group of fishermen and chefs who love to share our hard work with you! Our products are always available at your local market.",
                ColumnOneTitle = "Fish",
                ColumnOneImage = "https://maxcdn.icons8.com/iOS7/PNG/512/Food/whole_fish-512.png",
                ColumnOneText = "Always Fresh",
                ColumnTwoTitle = "Local",
                ColumnTwoImage = "https://d30y9cdsu7xlg0.cloudfront.net/png/79193-200.png",
                ColumnTwoText = "Locally caught",
                ColumnThreeTitle = "Jobs",
                ColumnThreeImage = "https://d30y9cdsu7xlg0.cloudfront.net/png/2554-200.png",
                ColumnThreeText = "Check out oppurtunities",
                PostTitle = "News",


            };
            context.MarketingPage.Add(marketingPage);

            context.SaveChanges();
        }
    }
}