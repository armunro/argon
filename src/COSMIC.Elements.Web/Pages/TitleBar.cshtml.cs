using Microsoft.AspNetCore.Mvc.RazorPages;

namespace COSMIC.Elements.Web.Pages
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