using System;
using COSMIC.Elements.Web.Domain.Screen.Host.State;

namespace COSMIC.Elements.Web.Domain.Screen.Host
{
    public interface IBoxHost
    {
        
        Guid InstanceId { get; set; }
        void OpenWindow();
        void CloseBox();
        void ChangeWindowState(BoxHostFormState formState);
        void SetHostBox(ScreenModel screenModel);
    }
}