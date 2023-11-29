using System;
using COSMIC.Elements.Web.Domain.Screen.Host;

namespace COSMIC.Elements.Web.Domain.Screen
{
    public class ScreenInstance
    {
        public Guid InstanceId { get; }
        public ScreenModel ScreenModel { get; }
        public IScreenHost Host { get; }

        public ScreenInstance(Guid instanceId, ScreenModel screenModel, IScreenHost host)
        {
            ScreenModel = screenModel;
            Host = host;
            InstanceId = instanceId;
        }
    }
}