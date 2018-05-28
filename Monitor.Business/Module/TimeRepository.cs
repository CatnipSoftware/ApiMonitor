using Monitor.Business.Contract;
using Monitor.Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Monitor.Business.Module
{
    public class TimeRepository : ITimeRepository
    {
        public List<TimeVm> List()
        {
            return new List<TimeVm>
            {
                new TimeVm { Id = 1, Name = "Last 30 minutes", Duration = 30 },
                new TimeVm { Id = 2, Name = "Last hour", Duration = 60 },
                new TimeVm { Id = 3, Name = "Last 4 hours", Duration = 60 * 4 },
                new TimeVm { Id = 4, Name = "Last 12 hours", Duration = 60 * 12 },
                new TimeVm { Id = 5, Name = "Last 24 hours", Duration = 60 * 24 },
                new TimeVm { Id = 6, Name = "Last 48 hours", Duration = 60 * 48 },
                new TimeVm { Id = 7, Name = "Last 3 days", Duration = 60 * 24 * 3 },
                new TimeVm { Id = 8, Name = "Last 7 days", Duration = 60 * 24 * 7 },
                new TimeVm { Id = 9, Name = "Last 30 days", Duration = 60 * 24 * 30 }
            };
        }
        public TimeVm Get(int id)
        {
            return this.List()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}