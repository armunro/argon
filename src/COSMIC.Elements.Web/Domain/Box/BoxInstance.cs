using System;
using COSMIC.Elements.Web.Domain.Box.Host;

namespace COSMIC.Elements.Web.Domain.Box
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