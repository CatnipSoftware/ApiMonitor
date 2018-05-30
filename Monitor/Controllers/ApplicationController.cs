using Microsoft.AspNetCore.Mvc;
using Monitor.Presentation.Contract;

namespace Monitor.Controllers
{
    [Route("Applications")]
    public class ApplicationController : Controller
    {
        private readonly IApplicationPresentation _applicationPresentation;

        public ApplicationController(IApplicationPresentation applicationPresentation)
        {
            _applicationPresentation = applicationPresentation;
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = _applicationPresentation.List();
            return Ok(result);
        }
    }
}