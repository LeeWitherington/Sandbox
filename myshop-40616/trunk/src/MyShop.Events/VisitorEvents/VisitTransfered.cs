using System;

namespace MyShop.Events.VisitorEvents
{
    public class VisitTransfered : IEvent
    {
        public Guid VisitorId
        {
            get; private set;
        }

        public DateTime TimeStamp
        {
            get;
            private set;
        }

        public string Url { get; private set; }

        public string IpAddress { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisitTransfered"/> class.
        /// </summary>
        public VisitTransfered(Guid visitorId, DateTime timeStamp, string url, string ipAddress)
        {
            VisitorId = visitorId;
            TimeStamp = timeStamp;
            Url = url;
            IpAddress = ipAddress;
        }
    }
}
