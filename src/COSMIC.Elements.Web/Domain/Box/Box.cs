namespace COSMIC.Elements.Web.Domain.Box
{
    public class Box
    {
        public string Name { get; set; } 
        public string HostType { get; set; }

        public string[] CustomCssFiles { get; set; } = System.Array.Empty<string>();
        public string StartUrl { get; set; }
        public BoxState State { get; set; } = new BoxState();
    }
}