using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WpfProjectTestApp
{
    class CIDR
    {
        public static string returncidr { get; private set; }
        public static List<CollectionCIDR> CIDRcollection = new List<CollectionCIDR>();

        private static string Netclass { get; set; }

        private static string ipaddress { get; set; }

        private static bool partbset { get; set; }
        private static bool partcset { get; set; }
        private static bool partdset { get; set; }



        static string range;


        public static void cidrClass(string input) 
        {
            if (input == "")        //if input empty  return nothing - maybe
            {
                return;
            }
            ipaddress = input;
            string[] splitIpAdd = input.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            
            //PartA
            int ipaddparta = Convert.ToInt32(splitIpAdd[0]);
            //split ip address and find the network class
            if (ipaddparta >= 1 && ipaddparta < 127)
            {
                Netclass = "A";
            }
            else if (ipaddparta >= 128 && ipaddparta <= 191)
            {
                Netclass = "B";
            }
            else if (ipaddparta >= 192 && ipaddparta <= 223)
            {
                Netclass = "C";
            }
            else if(ipaddparta >= 224 && ipaddparta <= 239)
            {
                Netclass = "D";
            }

            //PartB
            int ipaddpartb = Convert.ToInt32(splitIpAdd[1]);
            if (ipaddpartb >= 0 && ipaddpartb <= 255)
            {
                //
                partbset = true;
            }
           

            //PartC
            int ipaddpartc = Convert.ToInt32(splitIpAdd[2]);
            if (ipaddpartc >= 0 && ipaddpartc <= 255)
            {
                //
                partcset = true;
            }


            //PartD
            int ipaddpartd = Convert.ToInt32(splitIpAdd[3]);
            if (ipaddpartd >= 0 && ipaddpartd <= 254)
            {
                //
                partbset = true;
            }


        }



        public static void cidrCalculator(int hosts)
        {
            if (hosts < 255)
            {
                if (hosts <= 6)
                {
                    int hostmax = 6;
                    //network address 192.168.1.1
                    //network 192.168.1.0
                    //range x.x.1.0 - x.x.1.7
                    //bits = 29
                    //subnets = 8
                    //wildcard = 0.0.0.7
                    //netmask = 255.255.255.248
                    //cidr notation = 192.168.1.0/29
                     
                    //network
                    string[] ipnetwork = ipaddress.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    ipnetwork[3] = "0";
                    int ip2 = 0;
                    //if (ipnetwork.Length == 4)
                    //{
                    //    ip2 = Convert.ToInt32(ipnetwork[0]) << 24;
                    //    ip2 += Convert.ToInt32(ipnetwork[1]) << 16;
                    //    ip2 += Convert.ToInt32(ipnetwork[2]) << 8;
                    //    ip2 += Convert.ToInt32(ipnetwork[3]);
                    //}
                    string ipaddy = ipnetwork[0] + "." + ipnetwork[1] + "." + ipnetwork[2];

                    //bits
                    int bits = (32 - 1) - 2; //32 bits max, /32 gives 1 addresses, 31 gives 2 addresses, 30 gives 2 addresses, 29 gives 6 addresses
                    string net = "255.255.255.248";

                    //subnets
                    int subnets = hosts + 2;

                    //ranges
                    //range One
                    CollectionCIDR SubnetOne = new CollectionCIDR();
                    int part4 = 0;
                    part4 = Convert.ToInt32(ipnetwork[3]);
                    SubnetOne.Subnet = "One";
                    SubnetOne.NetworkAddress = ipaddy + "." + part4;
                    SubnetOne.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetOne.LastIPv4address = ipaddy + "." + (part4 + hostmax);
                    SubnetOne.BroadcastAddress = ipaddy + "." + (part4 + (hostmax + 1));
                    CIDRcollection.Add(SubnetOne);
                    part4 = (part4 + (hostmax + 1));
                    //range Two
                    CollectionCIDR SubnetTwo = new CollectionCIDR();
                    SubnetTwo.Subnet = "Two";
                    SubnetTwo.NetworkAddress = ipaddy + "." + part4;
                    SubnetTwo.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetTwo.LastIPv4address = ipaddy + "." + (part4 + hostmax);
                    SubnetTwo.BroadcastAddress = ipaddy + "." + (part4 + (hostmax + 1));
                    CIDRcollection.Add(SubnetTwo);
                    part4 = (part4 + (hostmax + 1));
                    //range Three
                    CollectionCIDR SubnetThree = new CollectionCIDR();
                    SubnetThree.Subnet = "Three";
                    SubnetThree.NetworkAddress = ipaddy + "." + part4;
                    SubnetThree.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetThree.LastIPv4address = ipaddy + "." + (part4 + hostmax);
                    SubnetThree.BroadcastAddress = ipaddy + "." + (part4 + (hostmax + 1));
                    CIDRcollection.Add(SubnetThree);
                    part4 = (part4 + (hostmax + 1));

                    //range Four
                    CollectionCIDR SubnetFour = new CollectionCIDR();
                    SubnetFour.Subnet = "Four";
                    SubnetFour.NetworkAddress = ipaddy + "." + part4;
                    SubnetFour.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetFour.LastIPv4address = ipaddy + "." + (part4 + hostmax);
                    SubnetFour.BroadcastAddress = ipaddy + "." + (part4 + (hostmax + 1));
                    CIDRcollection.Add(SubnetFour);
                    part4 = (part4 + (hostmax + 1));
                    //range Five
                    CollectionCIDR SubnetFive = new CollectionCIDR();
                    SubnetFive.Subnet = "Five";
                    SubnetFive.NetworkAddress = ipaddy + "." + part4;
                    SubnetFive.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetFive.LastIPv4address = ipaddy + "." + (part4 + hostmax);
                    SubnetFive.BroadcastAddress = ipaddy + "." + (part4 + (hostmax + 1));
                    CIDRcollection.Add(SubnetFive);
                    part4 = (part4 + (hostmax + 1));
                    //range Six
                    CollectionCIDR SubnetSix = new CollectionCIDR();
                    SubnetSix.Subnet = "Six";
                    SubnetSix.NetworkAddress = ipaddy + "." + part4;
                    SubnetSix.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetSix.LastIPv4address = ipaddy + "." + (part4 + hostmax);
                    SubnetSix.BroadcastAddress = ipaddy + "." + (part4 + (hostmax + 1));
                    CIDRcollection.Add(SubnetSix);
                    part4 = (part4 + (hostmax + 1));
                    //range Seven
                    CollectionCIDR SubnetSeven = new CollectionCIDR();
                    SubnetSeven.Subnet = "Seven";
                    SubnetSeven.NetworkAddress = ipaddy + "." + part4;
                    SubnetSeven.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetSeven.LastIPv4address = ipaddy + "." + (part4 + hostmax);
                    SubnetSeven.BroadcastAddress = ipaddy + "." + (part4 + (hostmax + 1));
                    CIDRcollection.Add(SubnetSeven);
                    part4 = (part4 + (hostmax + 1));
                    //range Eight
                    CollectionCIDR SubnetEight = new CollectionCIDR();
                    SubnetEight.Subnet = "Eight";
                    SubnetEight.NetworkAddress = ipaddy + "." + part4;
                    SubnetEight.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetEight.LastIPv4address = ipaddy + "." + (part4 + hostmax);
                    SubnetEight.BroadcastAddress = ipaddy + "." + (part4 + (hostmax + 1));
                    CIDRcollection.Add(SubnetEight);
                    part4 = (part4 + (hostmax + 1));
                    //ipnetwork[3] = Convert.ToString(part4);
                    //foreach (var item in collection)
                    //{
                    //     range += item;

                    //}



                    //netmask & wildcard


                    //return data setting
                    returncidr = "Network: " + ip2 + "/" + bits;

                }
                else if (hosts >6 & hosts <= 14)
                {
                    int hostmax2 = 14;
                    //network
                    string[] ipnetwork = ipaddress.Split(new Char[] { '.' });
                    ipnetwork[3] = "0";
                    int ip2 = 0;
                    string ipaddy = ipnetwork[0] + "." + ipnetwork[1] + "." + ipnetwork[2];

                    //bits
                    int bits = (32 - 1) - 3;
                    string net = "255.255.255.240";
                    //subnets
                    int subnets = hostmax2 + 2;

                    //ranges
                    //range One
                    CollectionCIDR SubnetOne = new CollectionCIDR();
                    int part4 = 0;
                    part4 = Convert.ToInt32(ipnetwork[3]);
                    SubnetOne.Subnet = "One";
                    SubnetOne.NetworkAddress = ipaddy + "." + part4;
                    SubnetOne.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetOne.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetOne.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    SubnetOne.Netmask = net;
                    CIDRcollection.Add(SubnetOne);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Two
                    CollectionCIDR SubnetTwo = new CollectionCIDR();
                    SubnetTwo.Subnet = "Two";
                    SubnetTwo.NetworkAddress = ipaddy + "." + part4;
                    SubnetTwo.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetTwo.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetTwo.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    SubnetTwo.Netmask = net;
                    CIDRcollection.Add(SubnetTwo);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Three
                    CollectionCIDR SubnetThree = new CollectionCIDR();
                    SubnetThree.Subnet = "Three";
                    SubnetThree.NetworkAddress = ipaddy + "." + part4;
                    SubnetThree.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetThree.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetThree.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    SubnetThree.Netmask = net; 
                    CIDRcollection.Add(SubnetThree);
                    part4 = (part4 + (hostmax2 + 1));

                    //range Four
                    CollectionCIDR SubnetFour = new CollectionCIDR();
                    SubnetFour.Subnet = "Four";
                    SubnetFour.NetworkAddress = ipaddy + "." + part4;
                    SubnetFour.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetFour.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetFour.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    SubnetFour.Netmask = net; 
                    CIDRcollection.Add(SubnetFour);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Five
                    CollectionCIDR SubnetFive = new CollectionCIDR();
                    SubnetFive.Subnet = "Five";
                    SubnetFive.NetworkAddress = ipaddy + "." + part4;
                    SubnetFive.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetFive.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetFive.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    SubnetFive.Netmask = net; 
                    CIDRcollection.Add(SubnetFive);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Six
                    CollectionCIDR SubnetSix = new CollectionCIDR();
                    SubnetSix.Subnet = "Six";
                    SubnetSix.NetworkAddress = ipaddy + "." + part4;
                    SubnetSix.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetSix.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetSix.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    SubnetSix.Netmask = net; 
                    CIDRcollection.Add(SubnetSix);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Seven
                    CollectionCIDR SubnetSeven = new CollectionCIDR();
                    SubnetSeven.Subnet = "Seven";
                    SubnetSeven.NetworkAddress = ipaddy + "." + part4;
                    SubnetSeven.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetSeven.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetSeven.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2+ 1));
                    SubnetSeven.Netmask = net; 
                    CIDRcollection.Add(SubnetSeven);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Eight
                    CollectionCIDR SubnetEight = new CollectionCIDR();
                    SubnetEight.Subnet = "Eight";
                    SubnetEight.NetworkAddress = ipaddy + "." + part4;
                    SubnetEight.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetEight.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetEight.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    SubnetEight.Netmask = net; 
                    CIDRcollection.Add(SubnetEight);
                    part4 = (part4 + (hostmax2 + 1));
                }
                else if (hosts > 14 & hosts <= 30)
                {
                    int hostmax2 = 14;
                    //network
                    string[] ipnetwork = ipaddress.Split(new Char[] { '.' });
                    ipnetwork[3] = "0";
                    int ip2 = 0;
                    string ipaddy = ipnetwork[0] + "." + ipnetwork[1] + "." + ipnetwork[2];

                    //bits
                    int bits = (32 - 1) - 3;
                    string net = "255.255.255.224";
                    //subnets
                    int subnets = hostmax2 + 2;

                    //ranges
                    //range One
                    CollectionCIDR SubnetOne = new CollectionCIDR();
                    int part4 = 0;
                    part4 = Convert.ToInt32(ipnetwork[3]);
                    SubnetOne.Subnet = "One";
                    SubnetOne.NetworkAddress = ipaddy + "." + part4;
                    SubnetOne.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetOne.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetOne.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    SubnetOne.Netmask = net;
                    CIDRcollection.Add(SubnetOne);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Two
                    CollectionCIDR SubnetTwo = new CollectionCIDR();
                    SubnetTwo.Subnet = "Two";
                    SubnetTwo.NetworkAddress = ipaddy + "." + part4;
                    SubnetTwo.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetTwo.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetTwo.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetTwo);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Three
                    CollectionCIDR SubnetThree = new CollectionCIDR();
                    SubnetThree.Subnet = "Three";
                    SubnetThree.NetworkAddress = ipaddy + "." + part4;
                    SubnetThree.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetThree.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetThree.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetThree);
                    part4 = (part4 + (hostmax2 + 1));

                    //range Four
                    CollectionCIDR SubnetFour = new CollectionCIDR();
                    SubnetFour.Subnet = "Four";
                    SubnetFour.NetworkAddress = ipaddy + "." + part4;
                    SubnetFour.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetFour.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetFour.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetFour);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Five
                    CollectionCIDR SubnetFive = new CollectionCIDR();
                    SubnetFive.Subnet = "Five";
                    SubnetFive.NetworkAddress = ipaddy + "." + part4;
                    SubnetFive.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetFive.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetFive.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetFive);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Six
                    CollectionCIDR SubnetSix = new CollectionCIDR();
                    SubnetSix.Subnet = "Six";
                    SubnetSix.NetworkAddress = ipaddy + "." + part4;
                    SubnetSix.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetSix.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetSix.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetSix);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Seven
                    CollectionCIDR SubnetSeven = new CollectionCIDR();
                    SubnetSeven.Subnet = "Seven";
                    SubnetSeven.NetworkAddress = ipaddy + "." + part4;
                    SubnetSeven.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetSeven.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetSeven.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetSeven);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Eight
                    CollectionCIDR SubnetEight = new CollectionCIDR();
                    SubnetEight.Subnet = "Eight";
                    SubnetEight.NetworkAddress = ipaddy + "." + part4;
                    SubnetEight.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetEight.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetEight.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetEight);
                    part4 = (part4 + (hostmax2 + 1));
                }
                else if (hosts > 30 & hosts <= 62)
                {
                    int hostmax2 = 30;
                    //network
                    string[] ipnetwork = ipaddress.Split(new Char[] { '.' });
                    ipnetwork[3] = "0";
                    int ip2 = 0;
                    string ipaddy = ipnetwork[0] + "." + ipnetwork[1] + "." + ipnetwork[2];

                    //bits
                    int bits = (32 - 1) - 3;
                    string net = "255.255.255.192";
                    //subnets
                    int subnets = hostmax2 + 2;

                    //ranges
                    //range One
                    CollectionCIDR SubnetOne = new CollectionCIDR();
                    int part4 = 0;
                    part4 = Convert.ToInt32(ipnetwork[3]);
                    SubnetOne.Subnet = "One";
                    SubnetOne.NetworkAddress = ipaddy + "." + part4;
                    SubnetOne.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetOne.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetOne.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetOne);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Two
                    CollectionCIDR SubnetTwo = new CollectionCIDR();
                    SubnetTwo.Subnet = "Two";
                    SubnetTwo.NetworkAddress = ipaddy + "." + part4;
                    SubnetTwo.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetTwo.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetTwo.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetTwo);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Three
                    CollectionCIDR SubnetThree = new CollectionCIDR();
                    SubnetThree.Subnet = "Three";
                    SubnetThree.NetworkAddress = ipaddy + "." + part4;
                    SubnetThree.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetThree.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetThree.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetThree);
                    part4 = (part4 + (hostmax2 + 1));

                    //range Four
                    CollectionCIDR SubnetFour = new CollectionCIDR();
                    SubnetFour.Subnet = "Four";
                    SubnetFour.NetworkAddress = ipaddy + "." + part4;
                    SubnetFour.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetFour.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetFour.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetFour);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Five
                    CollectionCIDR SubnetFive = new CollectionCIDR();
                    SubnetFive.Subnet = "Five";
                    SubnetFive.NetworkAddress = ipaddy + "." + part4;
                    SubnetFive.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetFive.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetFive.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetFive);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Six
                    CollectionCIDR SubnetSix = new CollectionCIDR();
                    SubnetSix.Subnet = "Six";
                    SubnetSix.NetworkAddress = ipaddy + "." + part4;
                    SubnetSix.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetSix.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetSix.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetSix);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Seven
                    CollectionCIDR SubnetSeven = new CollectionCIDR();
                    SubnetSeven.Subnet = "Seven";
                    SubnetSeven.NetworkAddress = ipaddy + "." + part4;
                    SubnetSeven.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetSeven.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetSeven.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetSeven);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Eight
                    CollectionCIDR SubnetEight = new CollectionCIDR();
                    SubnetEight.Subnet = "Eight";
                    SubnetEight.NetworkAddress = ipaddy + "." + part4;
                    SubnetEight.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetEight.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetEight.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetEight);
                    part4 = (part4 + (hostmax2 + 1));
                }
                else if (hosts > 62 & hosts <= 126)
                {
                    int hostmax2 = 62;
                    //network
                    string[] ipnetwork = ipaddress.Split(new Char[] { '.' });
                    ipnetwork[3] = "0";
                    int ip2 = 0;
                    string ipaddy = ipnetwork[0] + "." + ipnetwork[1] + "." + ipnetwork[2];

                    //bits
                    int bits = (32 - 1) - 3;
                    string net = "255.255.255.128";
                    //subnets
                    int subnets = hostmax2 + 2;

                    //ranges
                    //range One
                    CollectionCIDR SubnetOne = new CollectionCIDR();
                    int part4 = 0;
                    part4 = Convert.ToInt32(ipnetwork[3]);
                    SubnetOne.Subnet = "One";
                    SubnetOne.NetworkAddress = ipaddy + "." + part4;
                    SubnetOne.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetOne.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetOne.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetOne);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Two
                    CollectionCIDR SubnetTwo = new CollectionCIDR();
                    SubnetTwo.Subnet = "Two";
                    SubnetTwo.NetworkAddress = ipaddy + "." + part4;
                    SubnetTwo.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetTwo.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetTwo.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetTwo);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Three
                    CollectionCIDR SubnetThree = new CollectionCIDR();
                    SubnetThree.Subnet = "Three";
                    SubnetThree.NetworkAddress = ipaddy + "." + part4;
                    SubnetThree.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetThree.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetThree.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetThree);
                    part4 = (part4 + (hostmax2 + 1));

                    //range Four
                    CollectionCIDR SubnetFour = new CollectionCIDR();
                    SubnetFour.Subnet = "Four";
                    SubnetFour.NetworkAddress = ipaddy + "." + part4;
                    SubnetFour.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetFour.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetFour.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    CIDRcollection.Add(SubnetFour);
                    part4 = (part4 + (hostmax2 + 1));
                    
                }
                else if (hosts > 127 & hosts <= 254)
                {
                    int hostmax2 = 127;
                    //network
                    string[] ipnetwork = ipaddress.Split(new Char[] { '.' });
                    ipnetwork[3] = "0";
                    int ip2 = 0;
                    string ipaddy = ipnetwork[0] + "." + ipnetwork[1] + "." + ipnetwork[2];

                    //bits
                    int bits = (32 - 1) - 4;
                    string net = "255.255.255.0";
                    //subnets
                    int subnets = hostmax2 + 2;

                    //ranges
                    //range One
                    CollectionCIDR SubnetOne = new CollectionCIDR();
                    int part4 = 0;
                    part4 = Convert.ToInt32(ipnetwork[3]);
                    SubnetOne.Subnet = "One";
                    SubnetOne.NetworkAddress = ipaddy + "." + part4;
                    SubnetOne.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetOne.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetOne.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    SubnetOne.Netmask = net;
                    CIDRcollection.Add(SubnetOne);
                    part4 = (part4 + (hostmax2 + 1));
                    //range Two
                    CollectionCIDR SubnetTwo = new CollectionCIDR();
                    SubnetTwo.Subnet = "Two";
                    SubnetTwo.NetworkAddress = ipaddy + "." + part4;
                    SubnetTwo.FirstIPv4address = ipaddy + "." + (part4 + 1);
                    SubnetTwo.LastIPv4address = ipaddy + "." + (part4 + hostmax2);
                    SubnetTwo.BroadcastAddress = ipaddy + "." + (part4 + (hostmax2 + 1));
                    SubnetTwo.Netmask = net;
                    CIDRcollection.Add(SubnetTwo);
                    part4 = (part4 + (hostmax2 + 1));
                    
                }
            }
            
            
            //netClassCalc(hosts); //divert as there was code here for a bit
        }
        public static void netClassCalc(int hosts)
        {
            if (Netclass == "A")
            {
                //if (hosts < )
                //{

                //}
            }
            if (Netclass == "B")
            {

            }
            if (Netclass == "C")
            {

            }
            if (Netclass == "D")
            {

            }
        }

        

    }
}
