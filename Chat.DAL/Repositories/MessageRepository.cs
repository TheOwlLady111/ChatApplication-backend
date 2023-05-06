using Chat.DAL.Contracts;
using Chat.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.DAL.Repositories;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    public MessageRepository(ChatAppDbContext applicationContext) : base(applicationContext)
    {
    }

    public async Task<List<Message>> GetPagedAsync(int page, int rows)
    {
        return await DbSet.OrderBy(x => x.Id)
            .Skip(page * rows - 1)
            .Take(rows)
            .ToListAsync();
    }
}