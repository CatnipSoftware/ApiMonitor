using Monitor.Business.Contract;
using Monitor.Domain.ViewModel;
using Monitor.Presentation.Contract;

namespace Monitor.Presentation.Module
{
    public class ServerPresentation : IServerPresentation
    {
        private readonly IServerRepository _serverRepository;

        public ServerPresentation(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public ServerVm FindByName(string name)
        {
            var serverVm = _serverRepository.FindByName(name);

            if (serverVm == null)
            {
                serverVm = _serverRepository.Create(new ServerVm
                {
                    Name = name
                });
            }

            return serverVm;
        }
    }
}