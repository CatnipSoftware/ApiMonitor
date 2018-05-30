using System.Collections.Generic;
using Monitor.Business.Contract;
using Monitor.Domain.Model;
using Monitor.Domain.ViewModel;
using Monitor.Presentation.Contract;

namespace Monitor.Presentation.Module
{
    public class LogPresentation : ILogPresentation
    {
        private readonly IApiPresentation _apiPresentation;
        private readonly IApplicationPresentation _applicationPresentation;
        private readonly IServerPresentation _serverPresentation;
        private readonly ITransactionPresentation _transactionPresentation;
        private readonly ILogRepository _logRepository;

        public LogPresentation(IApiPresentation apiPresentation
            , IApplicationPresentation applicationPresentation
            , IServerPresentation serverPresentation
            , ITransactionPresentation transactionPresentation
            , ILogRepository logRepository)
        {
            _apiPresentation = apiPresentation;
            _applicationPresentation = applicationPresentation;
            _serverPresentation = serverPresentation;
            _transactionPresentation = transactionPresentation;
            _logRepository = logRepository;
        }

        public void Create(LogVm logVm)
        {
            var application = _applicationPresentation.FindByCode(logVm.Application);
            var api = _apiPresentation.FindByUriAndHttpMethod(application.Id, logVm.RequestUri, logVm.RequestMethod);
            var server = _serverPresentation.FindByName(logVm.Server);
            var transaction = _transactionPresentation.FindByGuid(logVm.TransactionId);

            _logRepository.Create(new Log
            {
                ApiId = api.Id,
                ApplicationId = application.Id,
                ServerId = server.Id,
                TransactionId = transaction.Id,
                AppUser = logVm.AppUser,
                RequestIpAddress = logVm.RequestIpAddress,
                RequestContentType = logVm.RequestContentType,
                RequestContentBody = logVm.RequestContentBody,
                RequestUri = logVm.RequestUri,
                RequestHeaders = logVm.RequestHeaders,
                RequestTimestamp = logVm.RequestTimestamp,
                ResponseContentType = logVm.ResponseContentType,
                ResponseContentBody = logVm.ResponseContentBody,
                ResponseStatusCode = logVm.ResponseStatusCode,
                ResponseHeaders = logVm.ResponseHeaders,
                Duration = logVm.Duration
            });
        }
    }
}