using Chat.DAL.Entities;

namespace Chat.Api.DataSeed;

public static class TestData
{
    public static List<User> GetUsers()
    {
        return new List<User>()
        {
            new User()
            {
                UserName = "Kate"
            },
            new User()
            {
                UserName = "Vera"
            }
        };
    }

    public static List<Message> GetMessages()
    {
        return new List<Message>()
        {
            new Message()
            {
                Text = "Hello!",
                CreatedAtUtc = DateTime.UtcNow,
                UserId = 1
            },
            new Message()
            {
                Text = "How are you?",
                CreatedAtUtc = DateTime.UtcNow,
                UserId = 1
            },
            new Message()
            {
                Text = "Fine",
                CreatedAtUtc = DateTime.UtcNow,
                UserId = 2
            },
            new Message()
            {
                Text = "And you?",
                CreatedAtUtc = DateTime.UtcNow,
                UserId = 2
            },
            new Message()
            {
                Text = "Too",
                CreatedAtUtc = DateTime.UtcNow,
                UserId = 1
            },
            new Message()
            {
                Text = "What's new?",
                CreatedAtUtc = DateTime.UtcNow,
                UserId = 2
            },
            new Message()
            {
                Text = "Trying to complete chat project....",
                CreatedAtUtc = DateTime.UtcNow,
                UserId = 1
            },
            new Message()
            {
                Text = "Got it....",
                CreatedAtUtc = DateTime.UtcNow,
                UserId = 1
            }
        };
    }
}