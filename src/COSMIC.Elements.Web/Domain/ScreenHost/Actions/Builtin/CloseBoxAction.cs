using COSMIC.Elements.Web.Domain.Screen;

namespace COSMIC.Elements.Web.Domain.ScreenHost.Actions.Builtin
{
    public class CloseBoxAction : IBoxHostAction
    {
        public void PerformAction(IScreenHost host, ScreenModel screenModel, IScreenHostController controller)
        {   
            controller.CloseScreen("", screenModel.Name);
            
        }
    }
}