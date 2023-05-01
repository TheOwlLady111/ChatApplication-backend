using Chat.BLL.ViewModels;

namespace Chat.BLL.Contracts;

public interface IAuthService
{
    Task<SuccessUserLoginViewModel> RegisterAsync(RegisterViewModel registerViewModel);
    Task<SuccessUserLoginViewModel> LoginAsync(LoginViewModel loginViewModel);
}