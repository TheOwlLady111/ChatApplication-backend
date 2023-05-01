using Chat.BLL.ViewModels;

namespace Chat.BLL.Contracts;

public interface IMessageService
{
    List<MessageViewModel> GetMessagesAsync();
}