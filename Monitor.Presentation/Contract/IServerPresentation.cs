using Monitor.Domain.ViewModel;
using System.Collections.Generic;

namespace Monitor.Presentation.Contract
{
    public interface IServerPresentation
    {
        List<ServerVm> List();
        ServerVm FindByName(string name);
    }
}