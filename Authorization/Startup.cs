using Authorization.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Authorization
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

            services.AddControllers(options =>
            {
                // options.Filters.Add()  //global filter
                options.OutputFormatters.RemoveType(typeof(SystemTextJsonOutputFormatter));
            })
             .AddXmlSerializerFormatters()
            //.AddXmlDataContractSerializerFormatters()
            .AddJsonOptions(option =>
            {
                option.JsonSerializerOptions.PropertyNamingPolicy = null; //removes default camel case and enbale pascal case
                

            });

            services.AddAuthentication("MyScheme")
                .AddScheme<AuthenticationSchemeOptions, CookieHandler>("MyScheme", o => { });
               // .AddCookie("MyScheme", option =>
               //{
               //    option.Cookie.Name = "auth_cookie";
               //    option.Cookie.HttpOnly = false;
               //    option.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
               //    option.LoginPath = "/account/login";
               //    option.AccessDeniedPath = "/account/denied";
               //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Authorization", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Authorization v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

           // app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
