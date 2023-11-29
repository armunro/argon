namespace COSMIC.Elements.Web.Domain.Screen.Host.Actions
{
    public interface IBoxHostAction
    {
        void PerformAction(IBoxHost host, ScreenModel screenModel, IBoxHostController controller);
    }
}