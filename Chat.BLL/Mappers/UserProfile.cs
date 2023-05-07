using AutoMapper;
using Chat.BLL.ViewModels;
using Chat.DAL.Entities;

namespace Chat.BLL.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserViewModel>();
        CreateMap<RegisterViewModel, User>()
            .ForMember(x => x.CreatedAtUtc, opt => opt.MapFrom(d => DateTime.UtcNow))
            .ForMember(x => x.Messages, opt => opt.Ignore())
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.AccessFailedCount, opt => opt.Ignore())
            .ForMember(x => x.ConcurrencyStamp, opt => opt.Ignore())
            .ForMember(x => x.Email, opt => opt.Ignore())
            .ForMember(x => x.EmailConfirmed, opt => opt.Ignore())
            .ForMember(x => x.LockoutEnabled, opt => opt.Ignore())
            .ForMember(x => x.LockoutEnd, opt => opt.Ignore())
            .ForMember(x => x.NormalizedEmail, opt => opt.Ignore())
            .ForMember(x => x.NormalizedUserName, opt => opt.Ignore())
            .ForMember(x => x.PasswordHash, opt => opt.Ignore())
            .ForMember(x => x.PhoneNumber, opt => opt.Ignore())
            .ForMember(x => x.PhoneNumberConfirmed, opt => opt.Ignore())
            .ForMember(x => x.TwoFactorEnabled, opt => opt.Ignore())
            .ForMember(x => x.SecurityStamp, opt => opt.Ignore());

    }
}