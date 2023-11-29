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
        private IScreenHostController _controller;
        public ScreenController(IScreenHostController controller)
        {
            _controller = controller;
        }


        [HttpGet]
        public Dictionary<string, ScreenGroup> Index()
        {
            return _controller.ScreenGroups;
        }

    }
}