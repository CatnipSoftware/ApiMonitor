using Microsoft.AspNetCore.Mvc;
using Monitor.Business.Contract;
using Monitor.Domain.ViewModel;

namespace Monitor.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogRepository _logRepository;
        private readonly ITimeRepository _timeRepository;

        public HomeController(IApplicationRepository applicationRepository, ICategoryRepository categoryRepository, ILogRepository logRepository, ITimeRepository timeRepository)
        {
            _applicationRepository = applicationRepository;
            _categoryRepository = categoryRepository;
            _logRepository = logRepository;
            _timeRepository = timeRepository;
        }

        public IActionResult Index()
        {
            var vm = new HomeVm
            {
                Applications = _applicationRepository.List(),
                Categories = _categoryRepository.List(),
                Times = _timeRepository.List()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Grid(int? applicationId, int? categoryId, int? timeId)
        {
            var result = _logRepository.List(applicationId, categoryId, timeId);
            return PartialView(result);
        }
    }
}