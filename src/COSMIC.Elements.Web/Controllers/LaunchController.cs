using COSMIC.Elements.Web.Domain.ScreenHost;
using Microsoft.AspNetCore.Mvc;

namespace COSMIC.Elements.Web.Controllers
{
    [ApiController]
    [Route("[controller]/{boxGroupName}/{boxName}")]
    public class LaunchController : Controller
    {
        public LaunchController(IScreenHostController screenHostController)
        {
            _handler = screenHostController;
        }

        private IScreenHostController _handler { get; set; }
        
        [HttpGet]
        public IActionResult Index(string boxGroupName, string boxName)
        {
            _handler.OpenScreen(boxGroupName, boxName);
            return Ok();

        }
    }
}