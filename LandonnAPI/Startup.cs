using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandonnAPI.Filters;
using LandonnAPI.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LandonnAPI
{
    public class Startup
    {
        private readonly int? _httpsPort;
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).
                AddJsonFile("appsettings.json", optional: false, reloadOnChange:true).
                AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true).
                AddEnvironmentVariables();
            Configuration = builder.Build();
               
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc(
                opt => 
                {
                    
                    opt.Filters.Add(typeof(JsonExceptionFilter));
                    opt.Filters.Add(typeof(RequireHttpsAttribute));
                    var jsonFormatter = opt.OutputFormatters.OfType<JsonOutputFormatter>().Single();
                    opt.OutputFormatters.Remove(jsonFormatter);
                    opt.OutputFormatters.Add(new IosOutputFormatter(jsonFormatter));

                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddRouting(_ => _.LowercaseUrls = true);
            
            //services.AddApiVersioning(opt=> { 
            //    opt.ApiVersionReader = new HeaderApiVersionReader("x-api-version"); 
            //    opt.AssumeDefaultVersionWhenUnspecified = true;
            //    opt.ReportApiVersions = true;
            //    opt.DefaultApiVersion = new ApiVersion(1,0);
            //    opt.ApiVersionSelector = new CurrentImplementationApiVersionSelector(opt);
            //    });


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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
