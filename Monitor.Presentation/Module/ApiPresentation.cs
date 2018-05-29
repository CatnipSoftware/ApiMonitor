using Monitor.Business.Contract;
using Monitor.Domain.ViewModel;
using Monitor.Presentation.Contract;

namespace Monitor.Presentation.Module
{
    public class ApiPresentation : IApiPresentation
    {
        private readonly IApiRepository _apiRepository;

        public ApiPresentation(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        public ApiVm FindByUriAndHttpMethod(string uri, string httpMethod)
        {
            if (uri.IndexOf('?') != -1)
                uri = uri.Remove(uri.IndexOf('?'));

            var apiVm = _apiRepository.FindByUriAndHttpMethod(uri, httpMethod);

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