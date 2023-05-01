using Chat.BLL.Contracts;
using Chat.BLL.ViewModels;
using Chat.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Npgsql.TypeMapping;

namespace Chat.BLL.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public Task<SuccessUserLoginViewModel> LoginAsync(LoginViewModel loginViewModel)
    {
        throw new NotImplementedException();
    }

    public Task<SuccessUserLoginViewModel> RegisterAsync(RegisterViewModel registerViewModel)
    {
        throw new NotImplementedException();
    }
}