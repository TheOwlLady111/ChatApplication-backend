using Chat.BLL.ViewModels;
using Chat.DAL;
using Chat.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Chat.Api.DataSeed;

public static class SeedData
{
    public static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;

        var contextApp = services.GetService<ChatAppDbContext>();
        var userContext = scope.ServiceProvider.GetService<UserManager<User>>();

        contextApp.Database.Migrate();
        await SeedAsync(contextApp, userContext);

        return app;
    }

    private static async Task SeedAsync(ChatAppDbContext context, UserManager<User> userManager)
    {
        if (!context.Set<User>().Any())
        {
            foreach (var user in TestData.GetUsers())
            {
                await userManager.CreateAsync(user, "Passw0rd!");
            }
            await context.SaveChangesAsync();
        }

        if (!context.Set<Message>().Any())
        {
            foreach (var message in TestData.GetMessages())
            {
                context.Set<Message>().Add(message);
            }
            await context.SaveChangesAsync();
        }
    }
}