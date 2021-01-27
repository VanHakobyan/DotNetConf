using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DotNetConf.Api.Common;
using DotNetConf.Api.Entity;
using DotNetConf.Api.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace DotNetConf.Api.Extension
{
    public static class ContextExtension
    {
        private static ILogger _logger;
        private static IConfiguration _configuration;
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
