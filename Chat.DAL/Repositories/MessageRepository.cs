using Chat.DAL.Contracts;
using Chat.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.DAL.Repositories;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    public MessageRepository(ChatAppDbContext applicationContext) : base(applicationContext)
    {
    }

    public async Task<List<Message>> GetPagedAsync(int skipAmount, int takeAmount)
    {
        return await DbSet.Include(x => x.User)
            .OrderByDescending(x => x.CreatedAtUtc)
            .Skip(skipAmount)
            .Take(takeAmount)
            .Reverse()
            .ToListAsync();
    }

    public async override Task<Message> GetAsync(int id)
    {
        return await DbSet.Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}