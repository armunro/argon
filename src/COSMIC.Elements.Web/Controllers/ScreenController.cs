using System.Collections.Generic;
using System.Linq;
using COSMIC.Elements.Web.Domain.Screen;
using COSMIC.Elements.Web.Domain.Screen.Host;
using Microsoft.AspNetCore.Mvc;

namespace COSMIC.Elements.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScreenController : Controller
    {
        private IBoxHostController _controller;
        public ScreenController(IBoxHostController controller)
        {
            _controller = controller;
        }


        [HttpGet]
        public Dictionary<string, ScreenGroup> Index()
        {
            return _controller.BoxGroups;
        }

    }
}