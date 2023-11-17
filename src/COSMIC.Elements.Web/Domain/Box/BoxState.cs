using COSMIC.Elements.Web.Domain.Box.Host.State;

namespace COSMIC.Elements.Web.Domain.Box
{
    public class BoxState
    {
        public HostBoxState Host { get; set; } = new();
    }
}