using System;
using DotNetConf.Api.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace DotNetConf.Api.Extension
{
    /// <summary>
    /// Swagger extensions
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// Configure swagger
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Literal.SwaggerVersion, new OpenApiInfo
                {
                    Title = Literal.SwaggerTitle,
                    Version = Literal.SwaggerVersion,
                    Contact = new OpenApiContact
                    {
                        Url = new Uri(Literal.ProductionHost)
                    }
                });
                c.AddSecurityDefinition(Literal.Bearer, new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = Literal.SwaggerJwtDescription,
                    Name = Literal.Authorization,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = Literal.Bearer
                            },
                            In = ParameterLocation.Header,
                            Name = Literal.Bearer
                        },
                        Array.Empty<string>()
                    }
                });

                c.OrderActionsBy(apiDesc => $"{apiDesc.GroupName}_{apiDesc.RelativePath}");
                c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\{Literal.SwaggerTitle}.XML");
            });

            return services;
        }

    }
}
