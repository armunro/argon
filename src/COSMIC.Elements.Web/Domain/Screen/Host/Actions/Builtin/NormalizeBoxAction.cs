using COSMIC.Elements.Web.Domain.Screen.Host.State;

namespace COSMIC.Elements.Web.Domain.Screen.Host.Actions.Builtin
{
    public class NormalizeBoxAction : IBoxHostAction
    {
        public void PerformAction(IScreenHost host, ScreenModel screenModel,  IScreenHostController controller)
        {
            host.ChangeWindowState(BoxHostFormState.Normal);
        }
        
    }
}