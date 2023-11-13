namespace Boxd.Service.Domain.Box.Host.Actions.Builtin
{
    public class CloseBoxAction : IBoxHostAction
    {
        public void PerformAction(IBoxHost host, Domain.Box.Box box, IBoxHostController controller)
        {   
            controller.StopBox("", box.Name);
            
        }
    }
}