﻿using System;
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
using AspNetCoreVideo.Services;
using Microsoft.AspNetCore.StaticFiles;

namespace AspNetCoreVideo
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IMessageService, ConfigurationMessageService>(); // gets data for "msg"
            services.AddMvc(); // enable MVC services
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

            // if there is no defaul index.html in the wwwroot use the Index() class in the Controllers folder
            app.UseMvcWithDefaultRoute(); 

            app.Run(async (context) =>
            {
                
                 await context.Response.WriteAsync(msg.GetMessage());
            });
        }
    }
}
