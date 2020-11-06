using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectTestApp
{
    class Binary : DictAsciiBinary
    {
        public static string returnBinary { get; private set; }
        public static string binarystring { get; private set; }


        public static void ToBinary(int input)
        {
            returnBinary = Convert.ToString(input, 2);
        }

        public static void AsciiToBinary(string input)
        {
            binarystring = "";
            //split string
            char[] collection = input.ToCharArray();
            //foreach char send to dictionary check
            foreach (var item in collection)
            {
                DictAsciiBinary.checkDict(Convert.ToString(item));
                //join dictionary return together
                binarystring += DictAsciiBinary.returnDICT + " ";
            }
            

            
            //send combined result back
            returnBinary = binarystring; 
            
        }
        

        
    }
}
