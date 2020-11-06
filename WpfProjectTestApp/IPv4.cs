using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectTestApp
{
    class IPv4
    {
        public static string returnIPv4 { get; private set; }
        private static string str1 = "";
        private static string dhex;
        private static string chex;
        private static string bhex;
        private static string ahex;
        private static string result;
        public static void ToIPv4(string input)
        {
            int oint = Convert.ToInt32(input);
            returnIPv4 = Convert.ToString(oint, 16);
        }

        public static string IPAddrToBinary(string input)
        {
            return String.Join(".", (input.Split('.').Select(x => Convert.ToString(Int32.Parse(x), 2).PadLeft(8, '0'))).ToArray());
        }

        public static string IPAddrToHex(string input)
        {
            string[] splitIpAdd = input.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            //use array to format hex properly
            int a = 3, b = 2, c = 1, d = 0;
            long hexa = ((long.Parse(splitIpAdd[a]) % 256) * (long)Math.Pow(256, (3 - a)));
            long hexb = ((long.Parse(splitIpAdd[b]) % 256) * (long)Math.Pow(256, (3 - a)));
            long hexc = ((long.Parse(splitIpAdd[c]) % 256) * (long)Math.Pow(256, (3 - a)));
            long hexd = ((long.Parse(splitIpAdd[d]) % 256) * (long)Math.Pow(256, (3 - a)));
            //Console.WriteLine(hexd +" "+ hexc + " " + hexb + " " + hexa);
            if (hexd < 16)
            {
                dhex = string.Format("0" + "{0:X}", hexd);
            }
            else
            {
                dhex = string.Format("{0:X}", hexd);
            }
            if (hexc < 16)
            {
                chex = string.Format("0" + "{0:X}", hexc);
            }
            else
            {
                chex = string.Format("{0:X}", hexc);
            }
            if (hexb < 16)
            {
                bhex = string.Format("0" + "{0:X}", hexb);
            }
            else
            {
                bhex = string.Format("{0:X}", hexb);
            }
            if (hexa < 16)
            {
                ahex = string.Format("0" + "{0:X}", hexa);
            }
            else
            {
                ahex = string.Format("{0:X}", hexa);
            }
            
            result = $"0:0:0:0:0:FFFF:{dhex}{chex}:{bhex}{ahex}";
            //result = Convert.ToString(("0:0:0:0:0:FFFF:{0}{1}:{2}{3}", dhex, chex, bhex, ahex));

            ////return String.Join(".", (input.Split('.').Select(x => Convert.ToString(Int32.Parse(x), 2).PadLeft(8, '0'))).ToArray());
            //string[] iparray = new string[8];
            //string[] hexarray = new string[8];
            //iparray = input.Split('.');
            //for (int i = 0; i < 4; i++)
            //{
            //    str1 += iparray[i] + ".";
            //}
            //str1 = str1.TrimEnd(".".ToCharArray());//removes last period from line

            //string result = String.Join(".", hexarray);

            return result;
        }

    }
}
