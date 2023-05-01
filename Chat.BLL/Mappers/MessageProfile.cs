using AutoMapper;
using Chat.BLL.ViewModels;
using Chat.DAL.Entities;

namespace Chat.BLL.Mappers;

public class MessageProfile : Profile
{
    public MessageProfile()
    {
        CreateMap<Message, MessageViewModel>()
            .ForMember(x => x.UserName, opt => opt.MapFrom(m => m.User.UserName));

        CreateMap<CreateMessageViewModel, Message>()
            .ForMember(x => x.CreatedAtUtc, opt => opt.MapFrom(d => DateTime.UtcNow))
            .ForMember(x => x.User, opt => opt.Ignore())
            .ForMember(x => x.Id, opt => opt.Ignore());

    }
}