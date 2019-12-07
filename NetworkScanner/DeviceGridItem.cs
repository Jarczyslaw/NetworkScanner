using System.Net;
using System.Net.NetworkInformation;

namespace NetworkScanner
{
    public class DeviceGridItem
    {
        public int Id { get; set; }
        public IPAddress Address { get; set; }
        public IPStatus Status { get; set; }
    }
}