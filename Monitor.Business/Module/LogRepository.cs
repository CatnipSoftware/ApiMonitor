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

        public List<LogGridVm> List(LogGridInputVm logGridInputVm)
        {
            var query = _context.Set<Log>()
                .Include(x => x.Category)
                .Include(x => x.Application)
                .Where(x => !logGridInputVm.ApplicationId.HasValue || x.ApplicationId == logGridInputVm.ApplicationId.Value)
                .Where(x => !logGridInputVm.ApiId.HasValue || x.ApiId == logGridInputVm.ApiId.Value)
                .Where(x => !logGridInputVm.ServerId.HasValue || x.ServerId == logGridInputVm.ServerId.Value);

            if (logGridInputVm.TimeId.HasValue)
            {
                var time = _timeRepository.Get(logGridInputVm.TimeId.Value);
                var date = DateTime.UtcNow.AddMinutes(time.Duration * -1);

                query = query.Where(x => x.RequestTimestamp > date);
            }

            return query.OrderByDescending(x => x.RequestTimestamp)
                .Select(x => new LogGridVm
                {
                    Id = x.Id,
                    //Application = new ApplicationVm
                    //{
                    //    Id = x.Application.Id,
                    //    Name = x.Application.Name
                    //},
                    //Api = new ApiVm
                    //{
                    //    Id = x.Api.Id,
                    //    HttpMethod = x.Api.HttpMethod,
                    //    Uri = x.Api.Uri
                    //},
                    //Server = new ServerVm
                    //{
                    //    Id = x.Server.Id,
                    //    Name = x.Server.Name
                    //},
                    RequestUri = x.RequestUri,
                    RequestTimestamp = x.RequestTimestamp,
                    ResponseCode = x.ResponseStatusCode,
                    Duration = x.Duration
                })
                .ToList();
        }

        public LogDetailVm Get(int id)
        {
            return _context.Set<Log>()
                .Where(x => x.Id == id)
                .Include(x => x.Application)
                .Include(x => x.Api)
                .Include(x => x.Server)
                .Include(x => x.Transaction.Logs).ThenInclude(x => x.Api)
                .Select(x => new LogDetailVm
                {
                    Id = x.Id,
                    Application = new ApplicationVm
                    {
                        Id = x.Application.Id,
                        Code = x.Application.Code,
                        Name = x.Application.Name
                    },
                    Api = new ApiVm
                    {
                        Id = x.Api.Id,
                        HttpMethod = x.Api.HttpMethod,
                        Uri = x.Api.Uri
                    },
                    Server = new ServerVm
                    {
                        Id = x.Server.Id,
                        Name = x.Server.Name
                    },
                    AppUser = x.AppUser,
                    RequestIpAddress = x.RequestIpAddress,
                    RequestContentType = x.RequestContentType,
                    RequestContentBody = x.RequestContentBody,
                    RequestHeaders = x.RequestHeaders,
                    RequestUri = x.RequestUri,
                    RequestTimestamp = x.RequestTimestamp,
                    ResponseContentType = x.ResponseContentType,
                    ResponseContentBody = x.ResponseContentBody,
                    ResponseHeaders = x.ResponseHeaders,
                    ResponseStatusCode = x.ResponseStatusCode,
                    Duration = x.Duration,
                    RelatedLogs = x.Transaction
                                   .Logs
                                   .Select(y => new LogDetailVm
                                   {
                                       Id = y.Id,
                                       Api = new ApiVm
                                       {
                                           Id = y.Api.Id,
                                           HttpMethod = y.Api.HttpMethod,
                                           Uri = y.Api.Uri
                                       },
                                       RequestUri = y.RequestUri
                                   })
                                   .ToList()
                })
                .FirstOrDefault();
        }

        public void Create(Log log)
        {
            _context.Set<Log>().Add(log);
            _context.SaveChanges();
        }
    }
}