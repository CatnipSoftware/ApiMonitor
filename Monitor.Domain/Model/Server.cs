using System.Collections.Generic;

namespace Monitor.Domain.Model
{
    public class Server
    {
        public Server()
        {
            this.Logs = new List<Log>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }
}