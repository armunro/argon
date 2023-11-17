namespace COSMIC.Elements.Web.Domain.Box.Host.Actions
{
    public interface IBoxHostAction
    {
        void PerformAction(IBoxHost host, Domain.Box.Box box, IBoxHostController controller);
    }
}