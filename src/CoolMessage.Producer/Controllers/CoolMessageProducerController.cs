using CoolMessage.Producer.Broker.Event;
using CoolMessage.Producer.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMessage.Producer.Controllers
{
    [Route("api/[controller]")]
    public class CoolMessageProducerController : ControllerBase
    {
        private readonly IMessageService _messageService; 

        public CoolMessageProducerController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<IActionResult> PostMessage([FromBody] MessageEvent message)
        {
            await _messageService.PostMessage(message);

            return Accepted();
        }
    }
}
