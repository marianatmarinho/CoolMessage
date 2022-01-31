using CoolMessage.Consumer.Domain.Entities;
using CoolMessage.Consumer.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolMessage.Consumer.Infra
{
    public class MessageContext : IMessageContext
    {
        public MessageContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>
                ("DatabaseSettings:ConnectionString"));

            var database = client.GetDatabase(configuration.GetValue<string>
                ("DatabaseSettings:DatabaseName"));

            Messages = database.GetCollection<Message>(configuration.GetValue<string>
                ("DatabaseSettings:CollectionName"));
        }
        public IMongoCollection<Message> Messages { get; }
    }
}
