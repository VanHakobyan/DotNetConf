using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DotNetConf.Api.Common;
using Swashbuckle.AspNetCore.SwaggerUI;
using DotNetConf.Api.Extension;
using DotNetConf.Api.Model;
using DotNetConf.Api.Service.Implementation;
using DotNetConf.Api.Service.Interface;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace DotNetConf.Api
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStringsConfigModel = new ConnectionStringsConfigModel();
            Configuration.GetSection(Literal.ConnectionStrings).Bind(connectionStringsConfigModel);


            var healthChecksConfigModel = new HealthChecksConfigModel();
            Configuration.GetSection(Literal.HealthChecksUI).Bind(healthChecksConfigModel);

            services.AddControllers();
            services.AddSwagger();
            services.AddContext(Configuration, connectionStringsConfigModel);
            services.ConfigureHealthChecks(connectionStringsConfigModel, healthChecksConfigModel);

            //for reference loop handling 
            //services.AddControllersWithViews().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            //});

            services.AddTransient<IPersonService, PersonService>();
        }

        /// <summary>
        /// Configure pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(Literal.SwaggerUrl, $"{Literal.SwaggerTitle} {Literal.SwaggerVersion}");
                    c.DocExpansion(DocExpansion.None);
                    c.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Delete, SubmitMethod.Post, SubmitMethod.Put, SubmitMethod.Patch, SubmitMethod.Options);
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks(Literal.Health, new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                endpoints.MapHealthChecksUI();
                endpoints.MapControllers();
            });
        }
    }
}
