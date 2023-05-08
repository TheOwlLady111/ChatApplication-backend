﻿using Chat.BLL.Models;
using Chat.DAL;
using Chat.DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
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
                builder => builder
                    .WithOrigins(configuration["Client"])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
        });

        return services;
    }

}