using System.Collections.Generic;

namespace Boxd.Service.Domain.Box
{
    public class BoxGroup
    {
        public string Name { get; set; }
        public List<Box> Tools { get; set; } = new();

    }
}