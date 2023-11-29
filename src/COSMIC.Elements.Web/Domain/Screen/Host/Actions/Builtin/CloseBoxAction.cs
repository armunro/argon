namespace COSMIC.Elements.Web.Domain.Screen.Host.Actions.Builtin
{
    public class CloseBoxAction : IBoxHostAction
    {
        public void PerformAction(IBoxHost host, ScreenModel screenModel, IBoxHostController controller)
        {   
            controller.StopBox("", screenModel.Name);
            
        }
    }
}