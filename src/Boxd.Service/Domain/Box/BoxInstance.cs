using System;
using Boxd.Service.Domain.Box.Host;

namespace Boxd.Service.Domain.Box
{
    public class BoxInstance
    {
        public Guid InstanceId { get; }
        public Box Box { get; }
        public IBoxHost Host { get; }

        public BoxInstance(Guid instanceId, Box box, IBoxHost host)
        {
            Box = box;
            Host = host;
            InstanceId = instanceId;
        }
    }
}