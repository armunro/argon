using System.Collections.Generic;
using COSMIC.Elements.Web.Domain.Box;

namespace COSMIC.Elements.Web.Domain.Config
{
    public interface IBoxGroupReader
    {
        Dictionary<string,BoxGroup> ReadToolsets();
    }
}