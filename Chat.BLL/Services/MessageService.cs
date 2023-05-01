using AutoMapper;
using Chat.BLL.Contracts;
using Chat.BLL.ViewModels;
using Chat.DAL.Contracts;

namespace Chat.BLL.Services;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;

    public MessageService(IMessageRepository messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }

    public async Task<List<MessageViewModel>> GetMessagesAsync()
    {
        var entities = await _messageRepository.GetAllAsync();

        var models = _mapper.Map<List<MessageViewModel>>(entities);

        return models;
    }
}