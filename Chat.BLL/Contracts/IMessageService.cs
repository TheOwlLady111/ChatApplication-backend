using Chat.BLL.ViewModels;

namespace Chat.BLL.Contracts;

public interface IMessageService
{
    Task<List<MessageViewModel>> GetMessagesAsync();
}