using System;
using System.Collections.Generic;

namespace COSMIC.Elements.Web.Domain.Screen.Host
{
    public interface IScreenHostController
    {
        Dictionary<string, ScreenGroup> BoxGroups { get; set; }
        Dictionary<Guid, ScreenInstance> Instances { get; set; }

        void StartBox(string toolsetName, string toolName);
        void StopBox(string toolsetName, string toolName);
        ScreenInstance GetBoxByName(string name);
        
    }
}