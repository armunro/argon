using Boxd.Service.Domain.Box.Host;
using Microsoft.AspNetCore.Mvc;

namespace Boxd.Service.Controllers
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