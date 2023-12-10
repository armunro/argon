using COSMIC.Elements.Web.Domain.Screen;

namespace COSMIC.Elements.Web.Domain.ScreenHost.Actions
{
    public interface IBoxHostAction
    {
        void PerformAction(IScreenHost host, ScreenModel screenModel, IScreenHostController controller);
    }
}