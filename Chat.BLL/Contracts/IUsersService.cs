using Chat.BLL.ViewModels;

namespace Chat.BLL.Contracts;

public interface IUsersService
{
    Task<UserViewModel> GetCurrentUserAsync();
}