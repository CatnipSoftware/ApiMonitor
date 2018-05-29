using Monitor.Business.Contract;
using Monitor.Domain.Model;
using Monitor.Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Monitor.Business.Module
{
    public class ApiRepository : IApiRepository
    {
        private readonly MonitorContext _context;

        public ApiRepository(MonitorContext context)
        {
            _context = context;
        }

        public List<ApiVm> List()
        {
            return _context.Set<Api>()
                .Select(x => new ApiVm
                {
                    Id = x.Id,
                    HttpMethod = x.HttpMethod,
                    Uri = x.Uri
                })
                .ToList();
        }

        public ApiVm FindByUriAndHttpMethod(string uri, string httpMethod)
        {
            return _context.Set<Api>()
                .Where(x => x.HttpMethod == httpMethod && x.Uri == uri)
                .Select(x => new ApiVm
                {
                    Id = x.Id,
                    HttpMethod = x.HttpMethod,
                    Uri = x.Uri
                })
                .FirstOrDefault();
        }

        public ApiVm Create(ApiVm apiVm)
        {
            var api = new Api
            {
                HttpMethod = apiVm.HttpMethod,
                Uri = apiVm.Uri
            };

            _context.Set<Api>().Add(api);
            _context.SaveChanges();

            apiVm.Id = api.Id;

            return apiVm;
        }
    }
}