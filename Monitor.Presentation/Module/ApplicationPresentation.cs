using Monitor.Business.Contract;
using Monitor.Domain.ViewModel;
using Monitor.Presentation.Contract;

namespace Monitor.Presentation.Module
{
    public class ApplicationPresentation : IApplicationPresentation
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationPresentation(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

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