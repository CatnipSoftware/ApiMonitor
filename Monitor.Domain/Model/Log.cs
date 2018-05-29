using System;

namespace Monitor.Domain.Model
{
    public class Log
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int ApplicationId { get; set; }
        public int ServerId { get; set; }
        public int ApiId { get; set; }
        public int TransactionId { get; set; }
        public string AppUser { get; set; }
        public string RequestIpAddress { get; set; }
        public string RequestContentType { get; set; }
        public string RequestUri { get; set; }
        public string RequestHeaders { get; set; }
        public DateTime RequestTimestamp { get; set; }
        public string ResponseContentType { get; set; }
        public string ResponseContentBody { get; set; }
        public short ResponseStatusCode { get; set; }
        public string ResponseHeaders { get; set; }
        public long Duration { get; set; }

        public virtual Api Api { get; set; }
        public virtual Application Application { get; set; }
        public virtual Category Category { get; set; }
        public virtual Server Server { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}