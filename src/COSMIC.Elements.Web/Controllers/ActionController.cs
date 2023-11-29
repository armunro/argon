using System;
using COSMIC.Elements.Web.Domain.Screen;
using COSMIC.Elements.Web.Domain.Screen.Host;
using COSMIC.Elements.Web.Domain.Screen.Host.Actions;
using COSMIC.Elements.Web.Domain.Screen.Host.Actions.Builtin;
using Microsoft.AspNetCore.Mvc;

namespace COSMIC.Elements.Web.Controllers
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

            ScreenInstance instance = _boxHostController.Instances[instanceId];
            action.PerformAction(instance.Host, instance.ScreenModel, _boxHostController);

            return Ok();
        }
    }
}