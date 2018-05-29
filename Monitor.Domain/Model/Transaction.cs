using System;
using System.Collections.Generic;

namespace Monitor.Domain.Model
{
    public class Transaction
    {
        public Transaction()
        {
            this.Logs = new List<Log>();
        }

        public int Id { get; set; }
        public Guid TransactionId { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }
}