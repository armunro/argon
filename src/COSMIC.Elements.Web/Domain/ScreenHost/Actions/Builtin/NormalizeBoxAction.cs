using COSMIC.Elements.Web.Domain.Screen;
using COSMIC.Elements.Web.Domain.ScreenHost.State;

namespace COSMIC.Elements.Web.Domain.ScreenHost.Actions.Builtin
{
    public class NormalizeBoxAction : IBoxHostAction
    {
        public void PerformAction(IScreenHost host, ScreenModel screenModel,  IScreenHostController controller)
        {
            host.ChangeWindowState(BoxHostFormState.Normal);
        }
        
    }
}