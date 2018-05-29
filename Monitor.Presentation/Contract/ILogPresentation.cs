using Monitor.Domain.ViewModel;

namespace Monitor.Presentation.Contract
{
    public interface ILogPresentation
    {
        void Create(LogVm logVm);
    }
}