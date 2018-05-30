using Monitor.Domain.ViewModel;
using System.Collections.Generic;

namespace Monitor.Business.Contract
{
    public interface IApiRepository
    {
        List<ApiVm> List(int applicationId);
        ApiVm FindByUriAndHttpMethod(int applicationId, string uri, string httpMethod);
        ApiVm Create(ApiVm apiVm);
    }
}