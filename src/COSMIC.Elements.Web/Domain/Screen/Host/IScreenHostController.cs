using System;
using System.Collections.Generic;

namespace COSMIC.Elements.Web.Domain.Screen.Host
{
    public interface IScreenHostController
    {
        Dictionary<string, ScreenGroup> ScreenGroups { get; set; }
        Dictionary<Guid, ScreenInstance> Instances { get; set; }
        void OpenScreen(string toolsetName, string toolName);
        void CloseScreen(string toolsetName, string toolName);
        ScreenInstance GetScreenByName(string name);
        
    }
}