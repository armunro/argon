using System;
using System.Windows.Forms;

namespace COSMIC.Elements.Windows.Extensions
{
    public static class ControlExtensions
    {
        public static void InvokeOnUiThreadIfRequired(this Control control, Action action)
        {
            if (control.Disposing || control.IsDisposed || !control.IsHandleCreated)
                return;

            if (control.InvokeRequired)
                control.BeginInvoke(action);
            else
                action.Invoke();
        }
    }
}