using Chat.BLL.Contracts;
using Chat.BLL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        [Route("current")]
        public async Task<ActionResult<UserViewModel>> GetCurrentUserAsync()
        {
            var user = await _usersService.GetCurrentUserAsync();

            return user;
        }
    }
}
