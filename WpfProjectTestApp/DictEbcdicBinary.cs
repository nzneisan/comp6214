﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectTestApp
{
    class DictEbcdicBinary
    {
        public static string returnDICT { get; private set; }


        public static SortedDictionary<string, string> EbcdicBinary = new SortedDictionary<string, string>()
        {
            //Ebcdic Binary -- to redo
            {"Space","01000000"},
            {"!","01011010"},
            {"\"","01111111"},
            {"#","01111011"},
            {"$","01011011"},
            {"%","01101100"},
            {"&","01010000"},
            {"'","01111101"},
            {"(","01001101"},
            {")","01011101"},
            {"*","01011100"},
            {"+","01001110"},
            {",","01101011"},
            {"-","01100000"},
            {".","01001011"},
            {"/","01100001"},
            {"0","11110000"},
            {"1","11110001"},
            {"2","11110010"},
            {"3","11110011"},
            {"4","11110100"},
            {"5","11110101"},
            {"6","11110110"},
            {"7","11110111"},
            {"8","11111000"},
            {"9","11111001"},
            {":","01111010"},
            {";","01011110"},
            {"<","01001100"},
            {"=","01111110"},
            {">","01101110"},
            {"?","01101111"},
            {"@","01111100"},
            {"A","01000001"},
            {"B","01000010"},
            {"C","01000011"},
            {"D","01000100"},
            {"E","01000101"},
            {"F","01000110"},
            {"G","01000111"},
            {"H","01001000"},
            {"I","01001001"},
            {"J","01001010"},
            {"K","01001011"},
            {"L","01001100"},
            {"M","01001101"},
            {"N","01001110"},
            {"O","01001111"},
            {"P","01010000"},
            {"Q","01010001"},
            {"R","01010010"},
            {"S","01010011"},
            {"T","01010100"},
            {"U","01010101"},
            {"V","01010110"},
            {"W","01010111"},
            {"X","01011000"},
            {"Y","01011001"},
            {"Z","01011010"},
            {"[","10111010"},
            {"\\","11100000"},
            {"]","10111011"},
            {"^","10110000"},
            {"_","01101101"},
            {"`","01111001"},
            {"a","10000001"},
            {"b","10000010"},
            {"c","10000011"},
            {"d","10000100"},
            {"e","10000101"},
            {"f","10000110"},
            {"g","10000111"},
            {"h","10001000"},
            {"i","10001001"},
            {"j","10010001"},
            {"k","10010010"},
            {"l","10010011"},
            {"m","10010100"},
            {"n","10010101"},
            {"o","10010110"},
            {"p","10010111"},
            {"q","10011000"},
            {"r","10011001"},
            {"s","10100010"},
            {"t","10100011"},
            {"u","10100100"},
            {"v","10100101"},
            {"w","10100110"},
            {"x","10100111"},
            {"y","10101000"},
            {"z","10101001"},
            {"{","11000000"},
            {"|","01001111"},
            {"}","11010000"},
            {"~","10100001"},
            {"DEL","00000111"},


        };

        public static void checkDict(string input)
        {
            if (EbcdicBinary.ContainsKey(input))
            {
                returnDICT = EbcdicBinary[input];
            }


        }
    }
}
