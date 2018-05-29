using Monitor.Domain.ViewModel;

namespace Monitor.Presentation.Contract
{
    public interface IApplicationPresentation
    {
        ApplicationVm FindByCode(string code);
    }
}