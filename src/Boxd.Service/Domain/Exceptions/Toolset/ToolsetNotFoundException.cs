using System;

namespace Boxd.Service.Domain.Exceptions.Toolset
{
    public class ToolsetNotFoundException : Exception
    {
        public ToolsetNotFoundException(Exception innerException) :base("", innerException)
        {
            
        }
    }
}