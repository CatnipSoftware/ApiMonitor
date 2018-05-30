using Microsoft.AspNetCore.Mvc;
using Monitor.Presentation.Contract;

namespace Monitor.Controllers
{
    [Route("Servers")]
    public class ServerController : Controller
    {
        private readonly IServerPresentation _serverPresentation;

        public ServerController(IServerPresentation serverPresentation)
        {
            _serverPresentation = serverPresentation;
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = _serverPresentation.List();
            return Ok(result);
        }
    }
}