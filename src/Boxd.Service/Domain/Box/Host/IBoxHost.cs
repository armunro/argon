using System;
using Boxd.Service.Domain.Box.Host.State;

namespace Boxd.Service.Domain.Box.Host
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