using Chat.DAL;
using Chat.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Chat.Api.DataSeed;

public static  class TestData
{
    public static async Task AddUsersAsync(UserManager<User> userManager)
    {
        if (await userManager.FindByNameAsync("Kate") == null)
        {
            var kate = new User
            {
                UserName = "Kate"
            };

            await userManager.CreateAsync(kate, "Passw0rd!");
        }

        if (await userManager.FindByNameAsync("Vera") == null)
        {
            var vera = new User
            {
                UserName = "Vera"
            };

            await userManager.CreateAsync(vera, "Passw0rd!");
        }
    }

    public static List<Message> GetMessages()
    {
        return new List<Message>()
        {
            new Message()
            {
                Text = "Hello!",
                CreatedAtUtc = DateTime.Now,
                UserId = 1
            },
            new Message()
            {
                Text = "How are you?",
                CreatedAtUtc = DateTime.Now,
                UserId = 1
            },
            new Message()
            {
                Text = "Fine",
                CreatedAtUtc = DateTime.Now,
                UserId = 2
            },
            new Message()
            {
                Text = "And you?",
                CreatedAtUtc = DateTime.Now,
                UserId = 2
            },
            new Message()
            {
                Text = "Too",
                CreatedAtUtc = DateTime.Now,
                UserId = 1
            },
            new Message()
            {
                Text = "What's new?",
                CreatedAtUtc = DateTime.Now,
                UserId = 2
            },
            new Message()
            {
                Text = "Trying to complete chat project....",
                CreatedAtUtc = DateTime.Now,
                UserId = 1
            },
            new Message()
            {
                Text = "Got it....",
                CreatedAtUtc = DateTime.Now,
                UserId = 1
            }
        };
    }
}