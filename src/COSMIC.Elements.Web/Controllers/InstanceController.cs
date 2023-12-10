using System;
using System.Collections.Generic;
using System.Linq;
using COSMIC.Elements.Web.Domain.Screen;
using COSMIC.Elements.Web.Domain.ScreenHost;
using Microsoft.AspNetCore.Mvc;

namespace COSMIC.Elements.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstanceController : Controller
    {
        private readonly IScreenHostController _screenHostController;

        public InstanceController(IScreenHostController screenHostController)
        {
            _screenHostController = screenHostController;
        }

        [HttpGet]
        public List<ScreenInstance> GetActiveWindows()
        {
            return _screenHostController.Instances.Values.ToList();
        }

        [HttpGet]
        [Route("{instanceId:guid}")]
        public ScreenInstance GetActiveWindow(Guid instanceId)
        {
            return _screenHostController.Instances[instanceId];
        }

        [HttpGet]
        [Route("{groupName}/{boxName}")]
        public List<ScreenInstance> GetInstances(string groupName, string boxName)
        {
            return _screenHostController.Instances.Values.Where(x => x.ScreenModel.Name == boxName).ToList();
        }
    }
}