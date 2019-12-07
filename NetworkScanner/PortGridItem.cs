using JToolbox.NetworkTools;

namespace NetworkScanner
{
    public class PortGridItem
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public PortType Type { get; set; }
        public bool Opened { get; set; }
        public string OpenedDisp => Opened ? "Opened" : "Closed";
    }
}