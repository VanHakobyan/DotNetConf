using System.Linq;
using System.Text.Json;
using DotNetConf.Api.Common;
using DotNetConf.Api.Model.HealthCheck;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;

namespace DotNetConf.Api.Extension
{
    /// <summary>
    /// Health check extensions
    /// </summary>
    public static class HealthCheckExtension
    {
        /// <summary>
        /// UseHealthChecks
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseHealthChecks(this IApplicationBuilder app)
        {
            app.UseHealthChecks(PathString.FromUriComponent(Literal.Health), new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = Literal.ContentType;

                    var response = new HealthCheckResponse
                    {
                        Status = report.Status.ToString(),
                        Checks = report.Entries.Select(x => new HealthCheck
                        {
                            Component = x.Key,
                            Status = x.Value.Status.ToString(),
                            Description = x.Value.Description
                        }),
                        Duration = report.TotalDuration
                    };
                    

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response,new JsonSerializerOptions{}));
                }
            });

            return app;
        }
    }
}
