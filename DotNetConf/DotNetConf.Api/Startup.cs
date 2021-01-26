using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DotNetConf.Api.Common;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using DotNetConf.Api.Extension;

namespace DotNetConf.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwagger();
        }

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
                endpoints.MapControllers();
            });
        }
    }
}
