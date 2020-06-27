using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrunchBaseAPITest.Controllers;
using CrunchBaseAPITest.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace CrunchBaseAPITest
{
    public class Startup
    {
        private readonly string CorsAllowedPolicy = "_myAllowedPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1",new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CrunchBaseAPI",
                    Description = "Swagger for CrunchBase Project"
                });
            });
            services.AddControllers();
            services.AddCors(options => 
            {
                options.AddPolicy(name: CorsAllowedPolicy,
                    builder =>
                    {
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.AllowAnyOrigin();
                    });
            });
            
            services.AddDbContext<CrunchBaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataContext")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","CrunchBase");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(CorsAllowedPolicy);
      
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
