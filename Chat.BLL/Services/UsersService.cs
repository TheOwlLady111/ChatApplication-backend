using AutoMapper;
using Chat.BLL.Contracts;
using Chat.BLL.ViewModels;
using Chat.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Chat.BLL.Services;

public class UsersService : IUsersService
{
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IMapper _mapper;

    public UsersService(UserManager<User> userManager, IHttpContextAccessor contextAccessor, IMapper mapper)
    {
        _userManager = userManager;
        _contextAccessor = contextAccessor;
        _mapper = mapper;
    }

    public async Task<UserViewModel> GetCurrentUserAsync()
    {
        var claimId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var userId = Convert.ToInt32(claimId);

        var user = await _userManager.FindByIdAsync(userId.ToString());

        var model = _mapper.Map<UserViewModel>(user);

        return model;
    }
}