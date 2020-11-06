using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfProjectTestApp
{
    class Endian
    {
        public static string returnLittleE { get; private set; }
        public static string returnBigE { get; private set; }
        
        public static string Builderfeed { get; private set; }
        public static string Builderfeed2 { get; private set; }

        public static void LittleE(string input) //input is abcd need to output as d c b a
        {
            Builderfeed = "";
            returnLittleE = "";
            string[] stringfeed = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in stringfeed)
            {
               Builderfeed += item;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Builderfeed.Length; i++)
            {
                if (i % 2 == 0)
                    sb.Append('.');
                sb.Append(Builderfeed[i]);// need to output this into a stack
            }
            string formatted = sb.ToString();
            string[] stackfeed = formatted.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            Stack litEndStack = new Stack();
            foreach (var item in stackfeed)
            {
                litEndStack.Push(item);
            }
            //pull data from stack
            foreach (var item in litEndStack)
            {
                returnLittleE += item + " ";
            }
        }

        public static void BigE(string input) //input is abcd need to output as a b c d
        {
            Builderfeed2 = "";
            returnBigE = "";
            string[] stringfeed = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in stringfeed)
            {
                Builderfeed2 += item;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Builderfeed.Length; i++)
            {
                if (i % 2 == 0)
                    sb.Append('.');
                sb.Append(Builderfeed[i]);// need to output this into a stack
            }
            string formatted = sb.ToString();
            string[] BigEfeed = formatted.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var item in BigEfeed)
            {
                returnBigE += item + " ";
            }
        }

    }
}
