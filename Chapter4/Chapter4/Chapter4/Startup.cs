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
using System.IO;
using Chapter4.Services;
using Chapter4.Controllers;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Routing;
using Chapter4.Data;
using Microsoft.EntityFrameworkCore;

namespace Chapter4
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true);

            if (env.IsDevelopment())
                builder.AddUserSecrets<Startup>();

            Configuration = builder.Build();

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var conn = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<VideoDbContext>(options =>
            options.UseSqlServer(conn));

            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IMessageService, ConfigurationMessageService>(); // gets data for "msg"
            services.AddMvc(); // enable MVC services
            services.AddSingleton<IVideoData, SqlVideoData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IMessageService msg)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // middleware
            }

            // load the default index.html file in the wwwroot folder
            app.UseFileServer();

            // if there is no defaul index.html in the wwwroot use the Index() class in the ConfigureRoutes folder
            //app.UseMvc(ConfigureRoutes);

            // another way of msapping routes (no addtional method needed)
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(async (context) =>
            {

                await context.Response.WriteAsync(msg.GetMessage());
            });
        }

        
    }
}
