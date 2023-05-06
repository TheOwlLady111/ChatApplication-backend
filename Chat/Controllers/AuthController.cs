using Chat.BLL.Contracts;
using Chat.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("registration")]
        public async Task<ActionResult<SuccessUserLoginViewModel>> RegisterAsync([FromBody] RegisterViewModel registerViewModel)
        {
            var result = await _authService.RegisterAsync(registerViewModel);

            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<SuccessUserLoginViewModel>> LoginAsync([FromBody] LoginViewModel loginViewModel)
        {
            var result = await _authService.LoginAsync(loginViewModel);

            return Ok(result);
        }
    }
}
