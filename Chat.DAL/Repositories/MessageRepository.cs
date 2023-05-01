using Chat.DAL.Contracts;
using Chat.DAL.Entities;

namespace Chat.DAL.Repositories;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    public MessageRepository(ChatAppDbContext applicationContext) : base(applicationContext)
    {
    }
}