using Chat.BLL.ViewModels;

namespace Chat.BLL.Contracts;

public interface IMessageService
{
    Task<List<MessageViewModel>> GetMessagesAsync();
    Task<MessageViewModel> GetMessageAsync(int id);
    Task<MessageViewModel> CreateMessagesAsync(CreateMessageViewModel createMessageViewModel);
    Task UpdateMessageAsync(UpdateMessageViewModel updateMessage);
    Task DeleteMessageAsync(int id);
}