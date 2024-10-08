using System.Collections.Generic;
using COSMIC.Elements.Web.Domain.Screen;

namespace COSMIC.Elements.Web.Application.Example.ScreenGroup
{
    public class ExampleScreenGroup
    {
        public static Domain.Screen.ScreenGroup ProvideToolset => new()
        {
            Name = "Google",
            Tools = new List<ScreenModel>()
            {
                new()
                {
                    Name = "Calendar",
                    StartUrl = "https://calendar.google.com/calendar/u/0/r"
                    
                }
            }
        };
    }
}