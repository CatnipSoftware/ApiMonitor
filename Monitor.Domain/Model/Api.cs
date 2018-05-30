using System.Collections.Generic;

namespace Monitor.Domain.Model
{
    public class Api
    {
        public Api()
        {
            this.Logs = new List<Log>();
        }

        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string HttpMethod { get; set; }
        public string Uri { get; set; }

        public virtual Application Application { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}