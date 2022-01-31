using CoolMessage.Consumer.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoolMessage.Consumer.Domain.Interfaces
{
    public interface IMessageRepository
    {
        Task CreateMessage(Message message);
        Task<IEnumerable<Message>> GetMessages();
        Task<IEnumerable<Message>> GetMessageByContent(string content);
    }
}
