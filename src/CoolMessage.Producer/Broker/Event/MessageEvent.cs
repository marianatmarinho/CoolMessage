using System;

namespace CoolMessage.Producer.Broker.Event
{
    public class MessageEvent
    {
        public int FromId { get; set; }
        public int ToId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAT { get; set; } = DateTime.Now;
    }
}
