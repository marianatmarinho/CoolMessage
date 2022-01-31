using CoolMessage.Consumer.Broker.Event;
using CoolMessage.Consumer.Domain.Entities;
using CoolMessage.Consumer.Domain.Interfaces;

namespace CoolMessage.Consumer.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IMessageService _messageService;

        public NotificationService(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void NotifyUser(int fromId, int toId, string content)
        {

        }

        public async void NotifyUser(MessageEvent messageEvent)
        {
           await _messageService.RegisterMessage(messageEvent);
        }
    }
}
