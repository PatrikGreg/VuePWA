using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using cr_api_service.Data;
using Microsoft.EntityFrameworkCore;
using cr_api_service.DbModels;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

namespace cr_api_service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            /*services.AddCors(options =>
                options.AddPolicy("default", policy =>
                    policy.WithOrigins("http://localhost:5001/#/")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                )
            );*/

			services.AddCors(options =>
                options.AddPolicy("MyCustomPolicy", policy =>
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                )
            );
            // services.AddCors(options =>
            // {
                // options.AddPolicy(MyAllowSpecificOrigins,
                // builder =>
                // {
                    // builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                // });
            // });
			// services.AddCors(crs => {
				// crs.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()); 
			// });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // requires using cr_api_service.Data;
            services.AddScoped<IReviewsRepository, ReviewsRepository>();
            // requires using Microsoft.EntityFrameworkCore;
            // and using cr_api_service.Data;
            //services.AddDbContext<cr_api_context>(opt => opt.UseInMemoryDatabase("cr_api_context"));
            services.Configure<Settings>(o =>
            {
                o.iConfigurationRoot = (Microsoft.Extensions.Configuration.IConfigurationRoot)Configuration;
            });
            services.AddTransient<IBoatsRepository, BoatsRepository>();
            services.AddTransient<IReviewsRepository, ReviewsRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            // app.UseCors("AllowOrigin");
			app.UseCors("MyCustomPolicy");
            app.UseMvc(routes =>
            {   
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
