using CoolMessage.Consumer.Broker.Event;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CoolMessage.Consumer.Domain.Entities
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public int FromId { get; private set; }
        public int ToId { get; private set; }
        public string Content { get; private set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAT { get; private set; } = DateTime.UtcNow;

        public Message(MessageEvent messageEvent)
        {
            FromId = messageEvent.FromId;
            ToId = messageEvent.ToId;
            Content = messageEvent.Content;
            CreatedAT = messageEvent.CreatedAT;
        }
    }
}
