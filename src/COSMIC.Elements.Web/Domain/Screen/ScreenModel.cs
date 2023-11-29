namespace COSMIC.Elements.Web.Domain.Screen
{
    public class ScreenModel
    {
        public string Name { get; set; } 
        public string StartUrl { get; set; }
        public ScreenState State { get; set; } = new ScreenState();
    }
}