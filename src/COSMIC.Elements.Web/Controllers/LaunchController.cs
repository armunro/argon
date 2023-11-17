using COSMIC.Elements.Web.Domain.Box.Host;
using Microsoft.AspNetCore.Mvc;

namespace COSMIC.Elements.Web.Controllers
{
    [ApiController]
    [Route("[controller]/{boxGroupName}/{boxName}")]
    public class LaunchController : Controller
    {
        public LaunchController(IBoxHostController boxHostController)
        {
            _handler = boxHostController;
        }

        private IBoxHostController _handler { get; set; }
        
        [HttpGet]
        public IActionResult Index(string boxGroupName, string boxName)
        {
            _handler.StartBox(boxGroupName, boxName);
            return Ok();

        }
    }
}