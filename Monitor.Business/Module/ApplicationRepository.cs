using Monitor.Business.Contract;
using Monitor.Domain.Model;
using Monitor.Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Monitor.Business.Module
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly MonitorContext _context;

        public ApplicationRepository(MonitorContext context)
        {
            _context = context;
        }

        public List<ApplicationVm> List()
        {
            return _context.Set<Application>()
                .Select(x => new ApplicationVm
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .OrderBy(x => x.Name)
                .ToList();
        }

        public ApplicationVm FindByCode(string code)
        {
            return _context.Set<Application>()
                .Where(x => x.Code == code)
                .Select(x => new ApplicationVm
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .FirstOrDefault();
        }

        public ApplicationVm Create(ApplicationVm applicationVm)
        {
            var application = new Application
            {
                Code = applicationVm.Code,
                Name = applicationVm.Name
            };

            _context.Set<Application>().Add(application);
            _context.SaveChanges();

            applicationVm.Id = application.Id;

            return applicationVm;
        }
    }
}