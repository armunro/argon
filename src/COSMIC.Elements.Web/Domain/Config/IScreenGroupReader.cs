using System.Collections.Generic;
using COSMIC.Elements.Web.Domain.Screen;

namespace COSMIC.Elements.Web.Domain.Config
{
    public interface IScreenGroupReader
    {
        Dictionary<string,ScreenGroup> ReadToolsets();
    }
}