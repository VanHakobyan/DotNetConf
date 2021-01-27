using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DotNetConf.Api.Common;
using Swashbuckle.AspNetCore.SwaggerUI;
using DotNetConf.Api.Entity;
using DotNetConf.Api.Extension;
using DotNetConf.Api.Service.Implementation;
using DotNetConf.Api.Service.Interface;

namespace DotNetConf.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwagger();
            services.AddContext(Configuration);
            services.AddHealthChecks()
                .AddDbContextCheck<DotNetConfContext>()
                .AddDbContextCheck<ReadOnlyDbContext>();// comment this 
            //.AddSqlServer(config.Test, name: Literal.Master)
            //.AddSqlServer(config.TestReadOnly, name: Literal.ReadOnly);// uncomment this


            //for reference loop handling 
            //services.AddControllersWithViews().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            //});

            services.AddTransient<IPersonService, PersonService>();
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

            app.UseHealthChecks();

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
