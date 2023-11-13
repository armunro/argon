using Boxd.Service.Domain.Box.Host.State;

namespace Boxd.Service.Domain.Box.Host.Actions.Builtin
{
    public class MinimizeBoxAction : IBoxHostAction
    {
        public void PerformAction(IBoxHost host, Domain.Box.Box box,  IBoxHostController controller)
        {
            host.ChangeWindowState(BoxHostFormState.Minimized);
        }
        
    }
}