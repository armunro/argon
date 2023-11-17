using System.Collections.Generic;
using System.Linq;
using COSMIC.Elements.Web.Domain.Box;
using COSMIC.Elements.Web.Domain.Box.Host;
using Microsoft.AspNetCore.Mvc;

namespace COSMIC.Elements.Web.Controllers
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