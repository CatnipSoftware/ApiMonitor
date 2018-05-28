using Monitor.Domain.ViewModel;
using System.Collections.Generic;

namespace Monitor.Business.Contract
{
    public interface ITimeRepository
    {
        List<TimeVm> List();
        TimeVm Get(int id);
    }
}