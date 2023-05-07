using AutoMapper;
using Chat.BLL.Contracts;
using Chat.BLL.Exceptions;
using Chat.BLL.ViewModels;
using Chat.DAL.Contracts;
using Chat.DAL.Entities;

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

    public async Task<MessageViewModel> CreateMessagesAsync(CreateMessageViewModel createMessageViewModel)
    {
        if (createMessageViewModel == null)
        {
            throw new ArgumentNullException(nameof(createMessageViewModel));
        }

        var message = _mapper.Map<Message>(createMessageViewModel);

        var messageCreated = await _messageRepository.CreateAsync(message);
        await _messageRepository.SaveChanges();

        var messageModel = _mapper.Map<MessageViewModel>(messageCreated);

        return messageModel;
    }

    public async Task DeleteMessageAsync(int id)
    {
        var entity = await _messageRepository.GetAsync(id);

        if (entity == null)
        {
            throw new NonExistsEntityException("There is no such entity!");
        }

        _messageRepository.Delete(entity);
        await _messageRepository.SaveChanges();
    }

    public async Task<MessageViewModel> GetMessageAsync(int id)
    {
        var entity = await _messageRepository.GetAsync(id);

        var messageModel = _mapper.Map<MessageViewModel>(entity);

        return messageModel;
    }

    public async Task<PagedMessagesViewModel> GetMessagesAsync(int page, int rows)
    {
        var entities = await _messageRepository.GetPagedAsync(page, rows);

        var models = _mapper.Map<List<MessageViewModel>>(entities);

        return new PagedMessagesViewModel()
        {
            Page = page,
            Rows = rows,
            Messages = models
        };
    }

    public async Task UpdateMessageAsync(UpdateMessageViewModel updateMessage)
    {
        var entity = await _messageRepository.GetAsync(updateMessage.Id);

        if (entity == null)
        {
            throw new NonExistsEntityException("There is no such entity!");
        }

        var updatedEntity = _mapper.Map(updateMessage, entity);
        _messageRepository.Update(updatedEntity);
        await _messageRepository.SaveChanges();
    }
}