using Microsoft.AspNetCore.Mvc;
using Monitor.Business.Contract;
using Monitor.Domain.ViewModel;

namespace Monitor.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly ILogRepository _logRepository;
        private readonly ITimeRepository _timeRepository;
        private readonly IServerRepository _serverRepository;

        public HomeController(IApplicationRepository applicationRepository
            , ILogRepository logRepository
            , ITimeRepository timeRepository
            , IServerRepository serverRepository)
        {
            _applicationRepository = applicationRepository;
            _logRepository = logRepository;
            _timeRepository = timeRepository;
            _serverRepository = serverRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new HomeVm
            {
                Applications = _applicationRepository.List(),
                Servers = _serverRepository.List(),
                Times = _timeRepository.List()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Grid([FromBody] LogGridInputVm logGridInputVm)
        {
            var result = _logRepository.List(logGridInputVm);
            return PartialView(result);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var result = _logRepository.Get(id);
            return View(result);
        }
    }
}