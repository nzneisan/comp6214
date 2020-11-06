using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectTestApp
{
    class Hexadecimal
    {
        public static string returnHex { get; private set; }

        public static void ToHexadecimal(int input)
        {
            returnHex = Convert.ToString(input, 16);
        }
        public static void ToHexadecimal(string input)
        {
            int oint = Convert.ToInt32(input);
            returnHex = Convert.ToString(oint, 16);
        }

    }
}
