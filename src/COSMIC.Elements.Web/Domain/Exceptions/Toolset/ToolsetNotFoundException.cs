using System;

namespace COSMIC.Elements.Web.Domain.Exceptions.Toolset
{
    public class ToolsetNotFoundException : Exception
    {
        public ToolsetNotFoundException(Exception innerException) :base("", innerException)
        {
            
        }
    }
}