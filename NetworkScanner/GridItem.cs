using System.Net.NetworkInformation;

namespace NetworkScanner
{
    public class GridItem
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public IPStatus Status { get; set; }
    }
}