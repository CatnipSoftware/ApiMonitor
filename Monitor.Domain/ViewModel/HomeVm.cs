using System.Collections.Generic;

namespace Monitor.Domain.ViewModel
{
    public class HomeVm
    {
        public List<ApplicationVm> Applications { get; set; }
        public List<CategoryVm> Categories { get; set; }
        public List<TimeVm> Times { get; set; }
    }
}