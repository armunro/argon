using System.Collections.Generic;

namespace COSMIC.Elements.Web.Domain.Screen
{
    public class ScreenGroup
    {
        public string Name { get; set; }
        public List<ScreenModel> Tools { get; set; } = new();

    }
}