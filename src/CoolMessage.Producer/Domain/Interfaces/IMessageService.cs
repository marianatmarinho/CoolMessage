using CoolMessage.Producer.Broker.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolMessage.Producer.Domain.Interfaces
{
    public interface IMessageService
    {
        Task PostMessage(MessageEvent message);
    }
}
