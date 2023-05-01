using Chat.DAL;

namespace Chat.Api.Extensions;

public static class AppExtensions
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