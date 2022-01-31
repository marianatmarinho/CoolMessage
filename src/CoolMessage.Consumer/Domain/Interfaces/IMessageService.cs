using CoolMessage.Consumer.Broker.Event;
using CoolMessage.Consumer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolMessage.Consumer.Domain.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetMessages();

        Task RegisterMessage(MessageEvent messageEvent);

        Task<IEnumerable<Message>> GetMessageByContent(string content);
    }
}
