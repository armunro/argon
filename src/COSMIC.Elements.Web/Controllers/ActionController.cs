using System;
using COSMIC.Elements.Web.Domain.Screen;
using COSMIC.Elements.Web.Domain.ScreenHost;
using COSMIC.Elements.Web.Domain.ScreenHost.Actions;
using COSMIC.Elements.Web.Domain.ScreenHost.Actions.Builtin;
using Microsoft.AspNetCore.Mvc;

namespace COSMIC.Elements.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActionController : Controller
    {
        private readonly IScreenHostController _screenHostController;

        public ActionController(IScreenHostController screenHostController)
        {
            _screenHostController = screenHostController;
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

            ScreenInstance instance = _screenHostController.Instances[instanceId];
            action.PerformAction(instance.Host, instance.ScreenModel, _screenHostController);

            return Ok();
        }
    }
}