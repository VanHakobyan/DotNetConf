using DotNetConf.Api.Common;
using DotNetConf.Api.Model;
using Microsoft.Extensions.DependencyInjection;

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
        /// <param name="services"></param>
        /// <param name="connectionStringConfig"></param>
        /// <param name="healthChecksConfig"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureHealthChecks(this IServiceCollection services,
            ConnectionStringsConfigModel connectionStringConfig, HealthChecksConfigModel healthChecksConfig)
        {
            services.AddHealthChecks().AddApplicationInsightsPublisher()
                .AddSqlServer(connectionStringConfig.Test, name: Literal.Master)
                .AddSqlServer(connectionStringConfig.TestReadOnly, name: Literal.ReadOnly);

            services.AddHealthChecksUI(opt =>
                {
                    opt.SetEvaluationTimeInSeconds(healthChecksConfig.EvaluationTimeOnSeconds); //time in seconds between check
                    opt.SetMinimumSecondsBetweenFailureNotifications(healthChecksConfig.MinimumSecondsBetweenFailureNotifications); //maximum history of checks
                    opt.AddHealthCheckEndpoint(Literal.SwaggerTitle, Literal.Health); //map health check api
                })
                .AddInMemoryStorage(); //Storing in memory 

            return services;
        }
    }
}
