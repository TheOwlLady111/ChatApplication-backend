using Chat.BLL.Contracts;
using Chat.BLL.Services;
using Chat.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedMessagesViewModel>> GetPagedMessages([FromQuery] int page,
            [FromQuery] int rows)
        {
            var result = await _messageService.GetMessagesAsync(page, rows);

            return Ok(result);
        }
    }
}
