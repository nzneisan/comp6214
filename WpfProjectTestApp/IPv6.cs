using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectTestApp
{
    class IPv6
    {
        public static string ipv6part1 { get; private set; }
        public static string ipv6part2 { get; private set; }
        public static string ipv6part3 { get; private set; }
        public static string ipv6part4 { get; private set; }

        public static sbyte[] unhex_table =
        { -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
       ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
       ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
       , 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,-1,-1,-1,-1,-1,-1
       ,-1,10,11,12,13,14,15,-1,-1,-1,-1,-1,-1,-1,-1,-1
       ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
       ,-1,10,11,12,13,14,15,-1,-1,-1,-1,-1,-1,-1,-1,-1
       ,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1
      };
        public static void IPAddrToV4(string input)
        {
            //need to read a full ipv6 address and remove the first six sections 
            //ie: remove 0:0:0:0:0:FFFF: to read the last four x:x:x:x for conversion

            //split given address
            string[] splitIpAdd = input.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < splitIpAdd.Length; i++)
            {
                if (splitIpAdd[i] == "0")
                {
                    splitIpAdd[i] = splitIpAdd[i] + "000";
                }

            }
            string input2 = string.Join("", splitIpAdd);

            string[] split = new string[input2.Length / 2 + (input2.Length % 2 == 0 ? 0 : 1)];

            for (int i = 0; i < split.Length; i++)

            {

                split[i] = input2.Substring(i * 2, i * 2 + 2 > input2.Length ? 1 : 2);
                
            }
            //used to convert only x:x:x:x
            //ipv6part1 = split[0];
            //ipv6part2 = split[1];
            //ipv6part3 = split[2];
            //ipv6part4 = split[3];

            //used to convert 0000:0000:0000:0000:0000:FFFF:x:x:x:x
            ipv6part1 = split[12];
            ipv6part2 = split[13];
            ipv6part3 = split[14];
            ipv6part4 = split[15];



            //$"{number1}.{number2}.{number3}.{number4}";
            //return input;//placeholder
        }
        
    }
}
