using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectTestApp
{
    class Octal
    {
        public static string returnOctal { get; private set; }
        public static string returnDecOct { get; private set; }
        public static void ToOctal(int input)
        {
            returnOctal = Convert.ToString(input, 8);
        }

        public static void ToOctal(string input)
        {
            int oint = Convert.ToInt32(input);
            returnOctal = Convert.ToString(oint, 8);
        }

        public static void DecimaltoOctal(int input)
        {
            int n1, n5, p = 1, k, ch = 1;
            int dec = 0, i = 1, j, d;

            n1 = input;
            n5 = n1;
            for (; n1 > 0; n1 = n1 / 10)
            {
                k = n1 % 10;
                if (k >= 8)
                {
                    ch = 0;
                }
            }

            switch (ch)
            {
                case 0:
                    returnDecOct = Convert.ToString(8);
                    break;
                case 1:
                    n1 = n5;
                    for (j = n1; j > 0; j = j / 10)
                    {
                        d = j % 10;
                        if (i == 1)
                            p = p * 1;
                        else
                            p = p * 8;

                        dec = dec + (d * p);
                        i++;
                    }
                    returnDecOct = Convert.ToString(dec);
                    
                    break;
            }
        }
    }
}
