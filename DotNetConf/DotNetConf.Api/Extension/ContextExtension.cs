using System.Reflection;
using DotNetConf.Api.Common;
using DotNetConf.Api.Entity;
using DotNetConf.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace DotNetConf.Api.Extension
{
    /// <summary>
    /// Context extension
    /// </summary>
    public static class ContextExtension
    {
        private static ILogger _logger;
        private static IConfiguration _configuration;

        /// <summary>
        /// Added contexts and sql data log
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            NLogLoggerProvider provider = new();
            _logger = provider.CreateLogger(Literal.SqlLog);
            _configuration = configuration;
            var config = new ConnectionStringsConfigModel();
            configuration.GetSection(Literal.ConnectionStrings).Bind(config);

            services.AddDbContext<DotNetConfContext>(options =>
                {
                    options.UseSqlServer(config.Test, sqlOptions => sqlOptions.MigrationsAssembly(typeof(DotNetConfContext).GetTypeInfo().Assembly.GetName().Name))
                        .LogTo(Log, new[] { RelationalEventId.CommandExecuted })
                        .EnableSensitiveDataLogging();
                }, ServiceLifetime.Transient
            );

            services.AddDbContext<ReadOnlyDbContext>(options =>
                {
                    options.UseSqlServer(config.TestReadOnly, sqlOptions => sqlOptions.MigrationsAssembly(typeof(ReadOnlyDbContext).GetTypeInfo().Assembly.GetName().Name))
                        .LogTo(Log, new[] { RelationalEventId.CommandExecuted })
                        .EnableSensitiveDataLogging();
                }, ServiceLifetime.Transient
            );

            return services;
        }

        private static void Log(string s)
        {
            if (_configuration.GetValue<bool>(Literal.EnableSqlQueryLog))
            {
                _logger.LogDebug(s);
            }
            else
            {
                //Console.WriteLine(s);//Uncomment for console logging
            }
        }
    }
}
