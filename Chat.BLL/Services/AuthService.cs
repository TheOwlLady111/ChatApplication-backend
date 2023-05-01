using System.Globalization;
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

        var viewModel = CreateSuccessUserLoginViewModel(loginViewModel.UserName);

        return viewModel;
    }

    public async Task<SuccessUserLoginViewModel> RegisterAsync(RegisterViewModel registerViewModel)
    {
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