using Monitor.Domain.ViewModel;
using System.Collections.Generic;

namespace Monitor.Presentation.Contract
{
    public interface IApplicationPresentation
    {
        List<ApplicationVm> List();
        ApplicationVm FindByCode(string code);
    }
}