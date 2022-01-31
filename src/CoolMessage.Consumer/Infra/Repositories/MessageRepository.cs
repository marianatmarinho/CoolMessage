using CoolMessage.Consumer.Domain.Entities;
using CoolMessage.Consumer.Domain.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolMessage.Consumer.Infra.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IMessageContext _context;

        public MessageRepository(IMessageContext context)
        {
            _context = context;
        }

        public async Task CreateMessage(Message message)
        {
            await _context.Messages.InsertOneAsync(message);
        }

        public async Task<IEnumerable<Message>> GetMessageByContent(string content)
        {
            FilterDefinition<Message> filter = Builders<Message>.Filter.Regex("Content", new MongoDB.Bson.BsonRegularExpression(content));
            return await _context.Messages.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetMessages()
        {
            return await _context.Messages.Find(x => true).ToListAsync();
        }
    }
}
