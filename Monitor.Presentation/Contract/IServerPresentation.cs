using Monitor.Domain.ViewModel;

namespace Monitor.Presentation.Contract
{
    public interface IServerPresentation
    {
        ServerVm FindByName(string name);
    }
}