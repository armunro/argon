using System;
using System.Collections.Generic;
using COSMIC.Elements.Web.Domain.Screen;

namespace COSMIC.Elements.Web.Domain.ScreenHost
{
    public interface IScreenHostController
    {
        Dictionary<string, ScreenGroup> ScreenGroups { get; set; }
        Dictionary<Guid, ScreenInstance> Instances { get; set; }
        void OpenScreen(string groupName, string screenName);
        void CloseScreen(string groupName, string screenName);
        ScreenInstance GetScreenByName(string name);
        
    }
}