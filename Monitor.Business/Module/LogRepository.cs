using Microsoft.EntityFrameworkCore;
using Monitor.Business.Contract;
using Monitor.Domain.Model;
using Monitor.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monitor.Business.Module
{
    public class LogRepository : ILogRepository
    {
        private readonly MonitorContext _context;
        private readonly ITimeRepository _timeRepository;
        private readonly IApplicationRepository _applicationRepository;

        public LogRepository(MonitorContext context, ITimeRepository timeRepository, IApplicationRepository applicationRepository)
        {
            _context = context;
            _timeRepository = timeRepository;
            _applicationRepository = applicationRepository;
        }

        public List<LogGridVm> List(int? applicationId, int? categoryId, int? timeId)
        {
            var query = _context.Set<Log>()
                .Include(x => x.Category)
                .Include(x => x.Application)
                .Where(x => !applicationId.HasValue || x.ApplicationId == applicationId.Value)
                .Where(x => !categoryId.HasValue || x.CategoryId == categoryId.Value);

            if (timeId.HasValue)
            {
                var time = _timeRepository.Get(timeId.Value);
                var date = DateTime.UtcNow.AddMinutes(time.Duration * -1);

                query = query.Where(x => x.RequestTimestamp > date);
            }

            return query.OrderByDescending(x => x.RequestTimestamp)
                .Select(x => new LogGridVm
                {
                    Id = x.Id,
                    Category = !x.CategoryId.HasValue
                             ? null
                             : new CategoryVm
                             {
                                 Id = x.Category.Id,
                                 Name = x.Category.Name
                             },
                    Application = new ApplicationVm
                    {
                        Id = x.Application.Id,
                        Name = x.Application.Name
                    },
                    RequestUri = x.RequestUri,
                    RequestTimestamp = x.RequestTimestamp,
                    ResponseCode = x.ResponseStatusCode,
                    Duration = x.Duration
                })
                .ToList();
        }
        public void Create(Log log)
        {
            _context.Set<Log>().Add(log);
            _context.SaveChanges();
        }
    }
}