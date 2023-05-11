using Chat.BLL.Models;
using Chat.DAL;
using Chat.DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Chat.Api.Extensions;

public static class AppExtensions
{
    public static IServiceCollection AddAuth(this IServiceCollection services, AuthSettings authSettings)
    {
        services.AddIdentity<User, IdentityRole<int>>()
            .AddEntityFrameworkStores<ChatAppDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = authSettings.Issuer,

                    ValidateAudience = true,
                    ValidAudience = authSettings.Audience,

                    ValidateLifetime = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authSettings.SecurityKey)),
                    ValidateIssuerSigningKey = true,
                };
            });

        return services;
    }

    public static AuthSettings AddAuthSettings(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AuthSettings"));

        return builder.Configuration
            .GetRequiredSection("AuthSettings")
            .Get<AuthSettings>();
    }

    public static IServiceCollection AddCorsExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());

            options.AddPolicy("SignalRCorsPolicy",
                builder => builder..SetIsOriginAllowed((host) => true)()
                    .AllowAnyHeader()
                    .AllowCredentials());
        });

        return services;
    }

    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        services.AddSwaggerGen(setup =>
        {
            setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Azure Starter - API",
                Version = "v1",
                Description = "Documentation of API"
            });

            setup.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please, insert JWT. For example: Bearer ABC123...",
                Name = HeaderNames.Authorization,
                Type = SecuritySchemeType.ApiKey
            });

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}