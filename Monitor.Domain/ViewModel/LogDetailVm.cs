using System;
using System.Collections.Generic;

namespace Monitor.Domain.ViewModel
{
    public class LogDetailVm
    {
        public int Id { get; set; }
        public ApplicationVm Application { get; set; }
        public ApiVm Api { get; set; }
        public ServerVm Server { get; set; }
        public string AppUser { get; set; }
        public string RequestIpAddress { get; set; }
        public string RequestContentType { get; set; }
        public string RequestContentBody { get; set; }
        public string RequestUri { get; set; }
        public string RequestHeaders { get; set; }
        public DateTime RequestTimestamp { get; set; }
        public string ResponseContentType { get; set; }
        public string ResponseContentBody { get; set; }
        public string ResponseHeaders { get; set; }
        public short ResponseStatusCode { get; set; }
        public long Duration { get; set; }

        public List<LogDetailVm> RelatedLogs { get; set; }
    }
}