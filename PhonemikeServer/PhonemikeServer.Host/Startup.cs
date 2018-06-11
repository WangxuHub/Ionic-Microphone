using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhonemikeServer.WebApi.Hubs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhonemikeServer.Host
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
            services.AddMvc(opt=> {
              //  opt.Filters.Add();
                
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddRouting(opt=> {
                opt.ConstraintMap.Add("NamespaceConstraint", typeof(Core.NamespaceConstraint));
            });

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //cors 允许全部
            //app.UseCors(builder => builder.WithOrigins("*").AllowAnyHeader());
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chathub");
            });

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "Default",
                //    template: "api/{controller}/{action}/{id?}",
                //    defaults: new { controller = "Home", action = "Index" }
                //);

                routes.MapRoute(
                    "webapi",
                    "api/{controller=Home}/{action=Index}",
                    null,
                    null,
                    new { Namespace = "PhonemikeServer.WebApi.Controllers" }
                );

                routes.MapRoute(
                    "Default",
                    "{controller}/{action}",
                    new { controller = "Home", action = "Index" },
                    null,
                    new { Namespace = "PhonemikeServer.Host.Controllers" }
                );
                
                //routes.MapRoute("default", "{controller}/{action}", null, null,
                //new { Namespace = "WebApplication.Controllers.HomeController" }));

            });

        }
    }
}
