using System;

namespace Monitor.Domain.ViewModel
{
    public class LogGridVm
    {
        public int Id { get; set; }
        public CategoryVm Category { get; set; }
        public ApplicationVm Application { get; set; }
        public string RequestUri { get; set; }
        public DateTime RequestTimestamp { get; set; }
        public int ResponseCode { get; set; }
        public long Duration { get; set; }
    }
}