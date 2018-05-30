using Microsoft.AspNetCore.Mvc;
using Monitor.Presentation.Contract;

namespace Monitor.Controllers
{
    [Route("Apis")]
    public class ApiController : Controller
    {
        private readonly IApiPresentation _apiPresentation;

        public ApiController(IApiPresentation apiPresentation)
        {
            _apiPresentation = apiPresentation;
        }

        [HttpGet]
        public IActionResult List(int applicationId)
        {
            var result = _apiPresentation.List(applicationId);
            return Ok(result);
        }
    }
}