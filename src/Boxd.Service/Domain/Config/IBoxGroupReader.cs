using System.Collections.Generic;
using Boxd.Service.Domain.Box;

namespace Boxd.Service.Domain.Config
{
    public interface IBoxGroupReader
    {
        Dictionary<string,BoxGroup> ReadToolsets();
    }
}