using CoolMessage.Consumer.Broker.Event;
using CoolMessage.Consumer.Domain.Entities;
using CoolMessage.Consumer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolMessage.Consumer.Domain.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<Message>> GetMessages()
        {
            return await _messageRepository.GetMessages();
        }

        public async Task RegisterMessage(MessageEvent messageEvent)
        {
            var message = new Message(messageEvent);
            await _messageRepository.CreateMessage(message);
        }

        public async Task<IEnumerable<Message>> GetMessageByContent(string content)
        {
            return await _messageRepository.GetMessageByContent(content);
        }
    }
}
