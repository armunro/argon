using System;
using Boxd.Service.Domain.Box;
using Boxd.Service.Domain.Box.Host;
using Boxd.Service.Domain.Box.Host.Actions;
using Boxd.Service.Domain.Box.Host.Actions.Builtin;
using Microsoft.AspNetCore.Mvc;

namespace Boxd.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActionController : Controller
    {
        private readonly IBoxHostController _boxHostController;

        public ActionController(IBoxHostController boxHostController)
        {
            _boxHostController = boxHostController;
        }

        [HttpGet]
        [Route("{instanceId:guid}/{actionName}")]
        public IActionResult DoAction(Guid instanceId, string actionName)
        {
            IBoxHostAction action = null;
            switch (actionName)
            {
                case "Maximize":
                    action = new MaximizeBoxAction();
                    break;
                case "Minimize":
                    action = new MinimizeBoxAction();
                    break;
                case "Normalize":
                    action = new NormalizeBoxAction();
                    break;
                case "Close":
                    action = new CloseBoxAction();
                    break;
            }

            BoxInstance instance = _boxHostController.Instances[instanceId];
            action.PerformAction(instance.Host, instance.Box, _boxHostController);

            return Ok();
        }
    }
}