using Monitor.Domain.ViewModel;
using System.Collections.Generic;

namespace Monitor.Business.Contract
{
    public interface IServerRepository
    {
        List<ServerVm> List();
        ServerVm FindByName(string name);
        ServerVm Create(ServerVm serverVm);
    }
}