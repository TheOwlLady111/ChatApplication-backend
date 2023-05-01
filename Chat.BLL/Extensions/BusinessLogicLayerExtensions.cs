using Chat.BLL.Contracts;
using Chat.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.BLL.Extensions;

public static class BusinessLogicLayerExtensions
{
    public static IServiceCollection AddAutomapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MessageService).Assembly);

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IMessageService, MessageService>();

        return services;
    }
}
