using AutoMapper;
using Chat.BLL.Contracts;
using Chat.BLL.Exceptions;
using Chat.BLL.ViewModels;
using Chat.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Npgsql.TypeMapping;

namespace Chat.BLL.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, IMapper mapper)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public async Task<SuccessUserLoginViewModel> LoginAsync(LoginViewModel loginViewModel)
    {
        var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);

        if (!result.Succeeded)
        {
            throw new LoginException("Login failure!");
        }

        var token = _tokenService.GenerateToken();


    }

    public Task<SuccessUserLoginViewModel> RegisterAsync(RegisterViewModel registerViewModel)
    {
        throw new NotImplementedException();
    }
}