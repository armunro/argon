using COSMIC.Elements.Web.Domain.Screen.Host.State;

namespace COSMIC.Elements.Web.Domain.Screen.Host.Actions.Builtin
{
    public class NormalizeBoxAction : IBoxHostAction
    {
        public void PerformAction(IBoxHost host, ScreenModel screenModel,  IBoxHostController controller)
        {
            host.ChangeWindowState(BoxHostFormState.Normal);
        }
        
    }
}