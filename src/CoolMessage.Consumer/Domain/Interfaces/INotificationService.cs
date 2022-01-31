using CoolMessage.Consumer.Broker.Event;

namespace CoolMessage.Consumer.Domain.Interfaces
{
    public interface INotificationService
    {
        void NotifyUser(int fromId, int toId, string content);
        void NotifyUser(MessageEvent messageEvent);
    }
}
