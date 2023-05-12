using Chat.BLL.Contracts;
using Chat.BLL.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace Chat.BLL.Hubs;

public class ChatHub : Hub
{
    private readonly IMessageService _messageService;

    public ChatHub(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public async Task SendMessageAsync(CreateMessageViewModel message)
    {
        var createdMessage = await _messageService.CreateMessagesAsync(message);

        await Clients.All.SendAsync("ReceiveMessage", createdMessage);
    }

    public async Task UpdateMessageAsync(UpdateMessageViewModel message)
    {
        await _messageService.UpdateMessageAsync(message);
        var updatedMessage = await _messageService.GetMessageAsync(message.Id);

        await Clients.All.SendAsync("UpdateMessage", updatedMessage);
    }

    public async Task DeleteMessageAsync(int id)
    {
        await _messageService.DeleteMessageAsync(id);

        await Clients.All.SendAsync("DeleteMessage", id);
    }
}