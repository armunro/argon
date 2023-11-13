using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Boxd.Service.Pages
{
    
    public class TitleBar : PageModel
    {
        public string InstanceId { get; set; }
        

        public void OnGet(string instanceId)
        {
            InstanceId = instanceId;
        }
    }
}