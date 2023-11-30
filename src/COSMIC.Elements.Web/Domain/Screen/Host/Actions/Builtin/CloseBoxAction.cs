namespace COSMIC.Elements.Web.Domain.Screen.Host.Actions.Builtin
{
    public class CloseBoxAction : IBoxHostAction
    {
        public void PerformAction(IScreenHost host, ScreenModel screenModel, IScreenHostController controller)
        {   
            controller.CloseScreen("", screenModel.Name);
            
        }
    }
}