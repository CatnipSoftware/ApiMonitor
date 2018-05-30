using Microsoft.AspNetCore.Mvc;
using Monitor.Domain.ViewModel;
using Monitor.Presentation.Contract;

namespace Monitor.Controllers
{
    [Route("Logs")]
    public class LogController : Controller
    {
        private readonly ILogPresentation _logPresentation;

        public LogController(ILogPresentation logPresentation)
        {
            _logPresentation = logPresentation;
        }

        [HttpPost]
        public IActionResult Create([FromBody] LogVm logVm)
        {
            _logPresentation.Create(logVm);
            return Ok();
        }
    }
}