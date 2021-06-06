using MediatR;
using System;

namespace MED.Core.Messages
{
    public class Event : INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}