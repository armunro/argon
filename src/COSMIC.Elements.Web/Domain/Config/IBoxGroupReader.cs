using System.Collections.Generic;
using COSMIC.Elements.Web.Domain.Screen;

namespace COSMIC.Elements.Web.Domain.Config
{
    public interface IBoxGroupReader
    {
        Dictionary<string,ScreenGroup> ReadToolsets();
    }
}