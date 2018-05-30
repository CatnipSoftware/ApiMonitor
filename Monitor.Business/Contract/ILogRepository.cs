using Monitor.Domain.Model;
using Monitor.Domain.ViewModel;
using System.Collections.Generic;

namespace Monitor.Business.Contract
{
    public interface ILogRepository
    {
        List<LogGridVm> List(LogGridInputVm logGridInputVm);
        LogDetailVm Get(int id);
        void Create(Log log);
    }
}