using CoolMessage.Consumer.Domain.Entities;
using MongoDB.Driver;

namespace CoolMessage.Consumer.Domain.Interfaces
{
    public interface IMessageContext
    {
        IMongoCollection<Message> Messages { get; }
    }
}
