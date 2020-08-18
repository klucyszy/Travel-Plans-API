using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using TravelPlans.API.Common.Settings;

namespace TravelPlans.API
{
    public static class DependencyInjectionExtensions
    {
        #region Swagger

        public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
        {
            //Add swagger document generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Travel Plans API", Version = "v1.0" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
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
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocs(this IApplicationBuilder app)
        {
            app.UseSwagger();   
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Travel Plans v1.0 API");
            });

            return app;
        }

        #endregion

        #region CORS

        public static string TravelPlansCorsPolicy = "TravelPlansCorsPolicy";

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                            .WithOrigins("http://localhost:8081")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            return services;
        }

        public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app)
        {
            app.UseCors();

            return app;
        }

        #endregion

        #region Authentication and Authorization

        public static IServiceCollection AddAuthenticationAndAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
                .AddJwtBearer("AzureAD", options =>
                {
                    options.Audience = configuration.GetValue<string>("AzureAd:Audience");
                    options.Authority = configuration.GetValue<string>("AzureAd:Instance") + configuration.GetValue<string>("AzureAd:TenantId");

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = configuration.GetValue<string>("AzureAd:Issuer"),
                        ValidAudience = configuration.GetValue<string>("AzureAd:Audience")
                    };
                }
            );

            services.Configure<AzureAdSettings>(configuration.GetSection("AzureAd"));

            return services;
        }

        #endregion
    }
}
