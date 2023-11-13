using System;
using System.Collections.Generic;

namespace Boxd.Service.Domain.Box.Host
{
    public interface IBoxHostController
    {
        Dictionary<string, BoxGroup> BoxGroups { get; set; }
        Dictionary<Guid, BoxInstance> Instances { get; set; }

        void StartBox(string toolsetName, string toolName);
        void StopBox(string toolsetName, string toolName);
        BoxInstance GetBoxByName(string name);
        
    }
}