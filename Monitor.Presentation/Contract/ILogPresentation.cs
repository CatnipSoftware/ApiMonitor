using Monitor.Domain.ViewModel;
using System.Collections.Generic;

namespace Monitor.Presentation.Contract
{
    public interface ILogPresentation
    {
        void Create(LogVm logVm);
    }
}