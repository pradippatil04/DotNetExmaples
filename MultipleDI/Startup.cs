using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MultipleDI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDI
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

            services.AddControllers();

            // type 1,2

            //services.AddScoped<IService, ServiceA>();
            //services.AddScoped<IService, ServiceB>();
            //services.AddScoped<IService, ServiceC>();

            ////type 3
            services.AddScoped<ServiceA>();
            services.AddScoped<ServiceB>();
            services.AddScoped<ServiceC>();

            services.AddScoped<ServcieResolver>(serviceProvider => serviceType =>
            {
                return serviceType switch
                {
                    ServiceType.A => serviceProvider.GetService<ServiceA>(),
                    ServiceType.B => serviceProvider.GetService<ServiceB>(),
                    ServiceType.C => serviceProvider.GetService<ServiceC>(),
                    _ => null

                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MultipleDI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MultipleDI v1"));
            }

            app.UseHttpsRedirection();
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from 1st delegate.");
                await next();
            });
            app.Use(async (context, next) =>
            {
                var ip = context.Connection.RemoteIpAddress;
               await next();
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
