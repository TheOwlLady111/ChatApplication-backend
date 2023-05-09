using Chat.BLL.ViewModels;

namespace Chat.BLL.Contracts;

public interface IMessageService
{
    Task<PagedMessagesViewModel> GetMessagesAsync(int skipAmount, int takeAmount);
    Task<MessageViewModel> GetMessageAsync(int id);
    Task<MessageViewModel> CreateMessagesAsync(CreateMessageViewModel createMessageViewModel);
    Task UpdateMessageAsync(UpdateMessageViewModel updateMessage);
    Task DeleteMessageAsync(int id);
}