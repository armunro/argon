using COSMIC.Elements.Web.Domain.Screen;
using COSMIC.Elements.Web.Domain.ScreenHost.State;

namespace COSMIC.Elements.Web.Domain.ScreenHost.Actions.Builtin
{
    public class MaximizeBoxAction: IBoxHostAction
    {
        public void PerformAction(IScreenHost host, ScreenModel screenModel,  IScreenHostController controller)
        {
            host.ChangeWindowState(BoxHostFormState.Maximized);
        }
    }
}