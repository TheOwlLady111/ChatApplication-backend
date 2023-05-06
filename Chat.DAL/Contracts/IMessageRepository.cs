using Chat.DAL.Entities;

namespace Chat.DAL.Contracts;

public interface IMessageRepository : IBaseRepository<Message>
{
    Task<List<Message>> GetPagedAsync(int page, int rows);
}