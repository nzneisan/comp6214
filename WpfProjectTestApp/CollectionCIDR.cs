using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectTestApp
{
    class CollectionCIDR
    {
        public string Subnet { get; set; }
        public string NetworkAddress { get; set; }
        public string FirstIPv4address { get; set; }
        public string LastIPv4address { get; set; }
        public string BroadcastAddress { get; set; }

        public string Netmask { get; set; }


        public string collectionDisplay()
        {
            return $"Subnet {Subnet}\nNetwork Address:\t\t {NetworkAddress}\nFirst IPv4 address:\t\t {FirstIPv4address} \nLast IPv4 address:\t\t {LastIPv4address}\nBroadcast Address:\t {BroadcastAddress}\nNetmask: \t\t\t {Netmask}";
        }
    }
}
