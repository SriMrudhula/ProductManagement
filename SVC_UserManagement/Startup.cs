using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserManagement.Helper;
//using UserService.Repository;
using Microsoft.OpenApi.Models;
using ProductManagementDBEntity.Models;
using ProductManagementDBEntity.Repository;
using UserManagement.Repository;
//using log4net.Repository.Hierarchy;
using log4net;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Reflection;
using UserManagement.Authentication;
using UserManagement.Extensions;

namespace UserManagement
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(
              config =>
              {
                  config.Filters.Add(typeof(CustomExceptionFilter));
              });
            //services.AddMvc();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserManagementHelper, UserManagementHelper>();
            services.AddTransient<ProductDBContext>();
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddAuthentication("Basic").AddScheme<BasicAuthenticationOptions,UserManagementAuthenticationHandler>("Basic", null);
            services.AddSingleton<IUserManagementAuthenticationManager, UserManagementAuthenticationManager>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserManagement API", Version = "v1", Description = "Provides User Functionalities ,\r\n Repository Url: https://github.com/SriMrudhula/ProductManagement/tree/Developer/4BB/ProductManagement" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddLog4Net();

        
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

        }
    }
}
