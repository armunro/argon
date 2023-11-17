using System;
using COSMIC.Elements.Web.Domain.Box.Host.State;

namespace COSMIC.Elements.Web.Domain.Box.Host
{
    public interface IBoxHost
    {
        
        Guid InstanceId { get; set; }
        void OpenWindow();
        void CloseBox();
        void ChangeWindowState(BoxHostFormState formState);
        void SetHostBox(Box box);
    }
}