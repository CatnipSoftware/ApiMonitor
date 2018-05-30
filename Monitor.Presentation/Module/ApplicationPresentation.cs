using Monitor.Business.Contract;
using Monitor.Domain.ViewModel;
using Monitor.Presentation.Contract;
using System.Collections.Generic;

namespace Monitor.Presentation.Module
{
    public class ApplicationPresentation : IApplicationPresentation
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationPresentation(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public List<ApplicationVm> List() => _applicationRepository.List();

        public ApplicationVm FindByCode(string code)
        {
            var applicationVm = _applicationRepository.FindByCode(code);

            if (applicationVm == null)
            {
                applicationVm = _applicationRepository.Create(new ApplicationVm
                {
                    Code = code,
                    Name = code
                });
            }

            return applicationVm;
        }
    }
}