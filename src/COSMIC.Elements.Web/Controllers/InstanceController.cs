using System;
using System.Collections.Generic;
using System.Linq;
using COSMIC.Elements.Web.Domain.Screen;
using COSMIC.Elements.Web.Domain.Screen.Host;
using Microsoft.AspNetCore.Mvc;

namespace COSMIC.Elements.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstanceController : Controller
    {
        private readonly IBoxHostController _boxHostController;

        public InstanceController(IBoxHostController boxHostController)
        {
            _boxHostController = boxHostController;
        }

        [HttpGet]
        public List<ScreenInstance> GetActiveWindows()
        {
            return _boxHostController.Instances.Values.ToList();
        }

        [HttpGet]
        [Route("{instanceId:guid}")]
        public ScreenInstance GetActiveWindow(Guid instanceId)
        {
            return _boxHostController.Instances[instanceId];
        }

        [HttpGet]
        [Route("{groupName}/{boxName}")]
        public List<ScreenInstance> GetInstances(string groupName, string boxName)
        {
            return _boxHostController.Instances.Values.Where(x => x.ScreenModel.Name == boxName).ToList();
        }
    }
}