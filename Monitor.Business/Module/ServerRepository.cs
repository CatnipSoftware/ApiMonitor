using Monitor.Business.Contract;
using Monitor.Domain.Model;
using Monitor.Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Monitor.Business.Module
{
    public class ServerRepository : IServerRepository
    {
        private readonly MonitorContext _context;

        public ServerRepository(MonitorContext context)
        {
            _context = context;
        }

        public List<ServerVm> List()
        {
            return _context.Set<Server>()
                .Select(x => new ServerVm
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .OrderBy(x => x.Name)
                .ToList();
        }

        public ServerVm FindByName(string name)
        {
            return _context.Set<Server>()
                .Where(x => x.Name == name)
                .Select(x => new ServerVm
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .FirstOrDefault();
        }

        public ServerVm Create(ServerVm serverVm)
        {
            var server = new Server
            {
                Name = serverVm.Name
            };

            _context.Set<Server>().Add(server);
            _context.SaveChanges();

            serverVm.Id = server.Id;

            return serverVm;
        }
    }
}