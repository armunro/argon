using System;
using System.Collections.Generic;
using System.Linq;
using COSMIC.Elements.Web.Domain.Box;
using COSMIC.Elements.Web.Domain.Box.Host;
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
        public List<BoxInstance> GetActiveWindows()
        {
            return _boxHostController.Instances.Values.ToList();
        }

        [HttpGet]
        [Route("{instanceId:guid}")]
        public BoxInstance GetActiveWindow(Guid instanceId)
        {
            return _boxHostController.Instances[instanceId];
        }

        [HttpGet]
        [Route("{groupName}/{boxName}")]
        public List<BoxInstance> GetInstances(string groupName, string boxName)
        {
            return _boxHostController.Instances.Values.Where(x => x.Box.Name == boxName).ToList();
        }
    }
}