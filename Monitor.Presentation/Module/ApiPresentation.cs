using Monitor.Business.Contract;
using Monitor.Domain.ViewModel;
using Monitor.Presentation.Contract;
using System.Collections.Generic;

namespace Monitor.Presentation.Module
{
    public class ApiPresentation : IApiPresentation
    {
        private readonly IApiRepository _apiRepository;

        public ApiPresentation(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        public List<ApiVm> List(int applicationId) => _apiRepository.List(applicationId);

        public ApiVm FindByUriAndHttpMethod(int applicationId, string uri, string httpMethod)
        {
            if (uri.IndexOf('?') != -1)
                uri = uri.Remove(uri.IndexOf('?'));

            var apiVm = _apiRepository.FindByUriAndHttpMethod(applicationId, uri, httpMethod);

            if (apiVm == null)
            {
                apiVm = _apiRepository.Create(new ApiVm
                {
                    Uri = uri,
                    HttpMethod = httpMethod
                });
            }

            return apiVm;
        }
    }
}