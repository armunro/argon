using System;
using COSMIC.Elements.Web.Domain.Screen;
using COSMIC.Elements.Web.Domain.ScreenHost.State;

namespace COSMIC.Elements.Web.Domain.ScreenHost
{
    public interface IScreenHost
    {
        
        Guid InstanceId { get; set; }
        void OpenWindow();
        void CloseBox();
        void ChangeWindowState(BoxHostFormState formState);
        void SetHostBox(ScreenModel screenModel);
    }
}