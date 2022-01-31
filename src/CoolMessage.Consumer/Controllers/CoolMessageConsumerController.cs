using CoolMessage.Consumer.Domain.Entities;
using CoolMessage.Consumer.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolMessage.Consumer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoolMessageConsumerController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public CoolMessageConsumerController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Message>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            var messages = await _messageService.GetMessages();
            return Ok(messages);
        }

        [HttpGet("bycontent")]
        [ProducesResponseType(typeof(IEnumerable<Message>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesByContent([FromQuery] string content)
        {
            var messages = await _messageService.GetMessageByContent(content);
            return Ok(messages);
        }
    }
}
