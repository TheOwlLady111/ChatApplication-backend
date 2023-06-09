﻿using Chat.BLL.Contracts;
using Chat.BLL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedMessagesViewModel>> GetPagedMessages([FromQuery] int skipAmount,
            [FromQuery] int takeAmount)
        {
            var result = await _messageService.GetMessagesAsync(skipAmount, takeAmount);

            return Ok(result);
        }
    }
}
