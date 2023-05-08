using Chat.BLL.Contracts;
using Chat.BLL.Services;
using Chat.BLL.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.BLL.Extensions;

public static class BusinessLogicLayerExtensions
{
    public static IServiceCollection AddAutomapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MessageService).Assembly);

        return services;
    }

    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(CreateMessageValidator).Assembly);

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IUsersService, UsersService>();

        return services;
    }
}
