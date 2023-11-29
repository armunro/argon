namespace COSMIC.Elements.Web.Domain.Screen.Host.Actions
{
    public interface IBoxHostAction
    {
        void PerformAction(IScreenHost host, ScreenModel screenModel, IScreenHostController controller);
    }
}