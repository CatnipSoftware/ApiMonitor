using System;

namespace Monitor.Domain.Model
{
    public class Log
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int ApplicationId { get; set; }
        public Guid TransactionId { get; set; }
        public string AppUser { get; set; }
        public string Machine { get; set; }
        public string RequestIpAddress { get; set; }
        public string RequestContentType { get; set; }
        public string RequestUri { get; set; }
        public string RequestMethod { get; set; }
        public string RequestHeaders { get; set; }
        public DateTime RequestTimestamp { get; set; }
        public string ResponseContentType { get; set; }
        public string ResponseContentBody { get; set; }
        public short ResponseStatusCode { get; set; }
        public string ResponseHeaders { get; set; }
        public DateTime ResponseTimestamp { get; set; }

        public Application Application { get; set; }
        public Category Category { get; set; }
    }
}