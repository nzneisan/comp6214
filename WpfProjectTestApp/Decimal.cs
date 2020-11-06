using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectTestApp
{
    class Decimal
    {
        public static string returnDecimal { get; private set; }
        public static string returnOctalDEC { get; private set; }

        public static string ASCIIDecimal { get; private set; }


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



        public static void ToDecimal(int input)
        {
            returnDecimal = (Convert.ToString(input, 10));
            //returnDecimal = ( );
        }

        public static void ToDecimal(string input)
        {
            int oint = Convert.ToInt32(input);
            returnDecimal = Convert.ToString(oint, 10);
        }

        public static void AsciiToDecimal(string input)
        {
            ASCIIDecimal = "";
            //split string
            char[] collection = input.ToCharArray();
            //foreach char send to dictionary check
            foreach (var item in collection)
            {
                DictAsciiDecimal.checkDict(Convert.ToString(item));
                //join dictionary return together
                ASCIIDecimal += DictAsciiDecimal.returnDICT + " ";
            }
        }

        public static void OctalToDecimal(int input)
        {
            int n, i, j, ocno = 0;

            n = input;

            i = 1;

            for (j = n; j > 0; j = j / 8)
            {
                ocno = ocno + (j % 8) * i;
                i = i * 10;
                n = n / 8;
            }
            returnOctalDEC = Convert.ToString(ocno);
        }
        public static void BinaryToDecimal(string input)
        {
            int n, p = 1;
            int dec = 0, i = 1, j, d;
            //int ocno = 0;

            n = Convert.ToInt32(input);

            for (j = n; j > 0; j = j / 10)
            {
                d = j % 10;
                if (i == 1)
                    p = p * 1;
                else
                    p = p * 2;

                dec = dec + (d * p);
                i++;
            }
            returnDecimal = Convert.ToString(dec);
        }
        public static void HexToDecimal(string input)
        {
           int decValue = unhex_table[(byte)input[0]];
                for (int i = 1; i < input.Length; i++)
                {
                    decValue *= 16;
                    decValue += unhex_table[(byte)input[i]];
                }
                
            returnDecimal = Convert.ToString(decValue);
        }
    }
}
