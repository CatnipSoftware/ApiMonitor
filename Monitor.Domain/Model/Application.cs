using System.Collections.Generic;

namespace Monitor.Domain.Model
{
    public class Application
    {
        public Application()
        {
            this.Logs = new List<Log>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Log> Logs { get; set; }
    }
}