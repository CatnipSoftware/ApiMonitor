using Monitor.Domain.ViewModel;
using System.Collections.Generic;

namespace Monitor.Presentation.Contract
{
    public interface IApiPresentation
    {
        List<ApiVm> List(int applicationId);
        ApiVm FindByUriAndHttpMethod(int applicationId, string uri, string httpMethod);
    }
}