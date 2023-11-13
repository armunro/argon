using System.Collections.Generic;
using System.Linq;
using Boxd.Service.Domain.Box;
using Boxd.Service.Domain.Box.Host;
using Microsoft.AspNetCore.Mvc;

namespace Boxd.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoxController : Controller
    {
        private IBoxHostController _controller;
        public BoxController(IBoxHostController controller)
        {
            _controller = controller;
        }


        [HttpGet]
        public Dictionary<string, BoxGroup> Index()
        {
            return _controller.BoxGroups;
        }

    }
}