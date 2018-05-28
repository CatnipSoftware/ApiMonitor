using Monitor.Domain.ViewModel;
using System.Collections.Generic;

namespace Monitor.Business.Contract
{
    public interface ILogRepository
    {
        List<LogGridVm> List(int? applicationId, int? categoryId, int? timeId);
    }
}