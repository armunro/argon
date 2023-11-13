using System.Collections.Generic;
using Boxd.Service.Domain.Box;

namespace Boxd.Service.Application.Example.Toolset
{
    public class ExampleBasicGoogleToolset
    {
        public static BoxGroup ProvideToolset => new()
        {
            Name = "Google",
            Tools = new List<Box>()
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