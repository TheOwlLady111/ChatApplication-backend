using System.Reflection;
using Chat.DAL.Contracts;
using Chat.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.DAL.Extensions;

public static class DataLayerExtensions
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ChatAppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("ChatDb"),
                b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMessageRepository, MessageRepository>();

        return services;
    }
}