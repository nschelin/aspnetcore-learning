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
using AspNetCore.services;

namespace AspNetCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            builder.AddEnvironmentVariables(prefix: "ASPNETCORE_");
            Configuration = builder.Build();
            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IGreeter, Greeting>();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IGreeter greeter, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var greeting = greeter.GetGreeting();
            loggerFactory.AddConsole();
            Console.WriteLine(env.IsDevelopment());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.Run(async (context) => {
                    await context.Response.WriteAsync("In Production");
                });
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}
