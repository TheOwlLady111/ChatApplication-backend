using AutoMapper;
using Chat.BLL.Contracts;
using Chat.BLL.Exceptions;
using Chat.BLL.ViewModels;
using Chat.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Chat.BLL.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, IMessageService messageservice, IMapper mapper)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _tokenService = tokenService;
        _messageService = messageservice;
        _mapper = mapper;
    }

    public async Task<SuccessUserLoginViewModel> LoginAsync(LoginViewModel loginViewModel)
    {
        if (loginViewModel == null)
        {
            throw new ArgumentNullException(nameof(loginViewModel));
        }

        var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);

        if (!result.Succeeded)
        {
            throw new LoginException("Login failure!");
        }

        var viewModel = CreateSuccessUserLoginViewModel(loginViewModel.UserName);

        var create = new CreateMessageViewModel
        {
            UserId = viewModel.User.Id,
            Text = "hhhhhhh"
        };

        var mes = await _messageService.CreateMessagesAsync(create);

        return viewModel;
    }

    public async Task<SuccessUserLoginViewModel> RegisterAsync(RegisterViewModel registerViewModel)
    {
        if (registerViewModel == null)
        {
            throw new ArgumentNullException(nameof(registerViewModel));
        }

        if (registerViewModel.ConfirmPassword != registerViewModel.ConfirmPassword)
        {
            throw new RegisterException("Password and confirmPassword are not the same!");
        }

        var user = _mapper.Map<User>(registerViewModel);
        var result = await _userManager.CreateAsync(user, registerViewModel.Password);

        if (!result.Succeeded)
        {
            throw new RegisterException("Register failure!");
        }

        var viewModel = CreateSuccessUserLoginViewModel(registerViewModel.UserName);

        return viewModel;
    }

    private SuccessUserLoginViewModel CreateSuccessUserLoginViewModel(string userName)
    {
        var user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);

        var token = _tokenService.GenerateToken(user.Id);
        var userViewModel = _mapper.Map<UserViewModel>(user);

        return new SuccessUserLoginViewModel
        {
            Token = token,
            User = userViewModel
        };
    }
}