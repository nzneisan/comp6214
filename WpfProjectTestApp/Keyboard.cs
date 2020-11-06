using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectTestApp
{
    class Keyboard
    {
        public static string ASCIIDecimal { get; private set; }
        public static string ASCIIBinary { get; private set; }

        public static string EBCDICDecimal { get; private set; }
        public static string EBCDICBinary { get; private set; }


        public static void ASCII(string input) 
        {
            ASCIIBinary = "";
            //split string
            char[] collection = input.ToCharArray();
            //foreach char send to dictionary check
            foreach (var item in collection)
            {
                DictAsciiBinary.checkDict(Convert.ToString(item));
                //join dictionary return together
                ASCIIBinary += DictAsciiBinary.returnDICT + " ";
            }


        }



        public static void EBCDIC(string input)
        {
            EBCDICBinary = "";
            //split string
            char[] collection = input.ToCharArray();
            //foreach char send to dictionary check
            foreach (var item in collection)
            {
                DictEbcdicBinary.checkDict(Convert.ToString(item));
                //join dictionary return together
                EBCDICBinary += DictEbcdicBinary.returnDICT + " ";
            }


        }



    }
}
