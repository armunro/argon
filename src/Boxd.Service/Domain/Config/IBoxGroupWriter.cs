using Boxd.Service.Domain.Box;

namespace Boxd.Service.Domain.Config
{
    public interface IBoxGroupWriter
    {
        void WriteToolset(BoxGroup boxGroup);
    }
}