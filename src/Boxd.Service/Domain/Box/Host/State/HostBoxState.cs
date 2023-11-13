namespace Boxd.Service.Domain.Box.Host.State
{
    public class HostBoxState
    {
        public string Title { get; set; } = "Boxd | Empty View";
        public string TitleBarBackground { get; set; } = "#3B434F";
        public string WindowBorderColor { get; set; } = "#3B434F";
        public string TitleBarIconColor { get; set; } = "White";
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}