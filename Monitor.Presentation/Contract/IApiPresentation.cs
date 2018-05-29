using Monitor.Domain.ViewModel;

namespace Monitor.Presentation.Contract
{
    public interface IApiPresentation
    {
        ApiVm FindByUriAndHttpMethod(string uri, string httpMethod);
    }
}