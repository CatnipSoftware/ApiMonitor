using Monitor.Domain.ViewModel;
using System.Collections.Generic;

namespace Monitor.Business.Contract
{
    public interface IApiRepository
    {
        List<ApiVm> List();
        ApiVm FindByUriAndHttpMethod(string uri, string httpMethod);
        ApiVm Create(ApiVm apiVm);
    }
}