using Boxd.Service.Domain.Box.Host.State;

namespace Boxd.Service.Domain.Box
{
    public class BoxState
    {
        public HostBoxState Host { get; set; } = new();
    }
}