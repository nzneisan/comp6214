using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfProjectTestApp
{
    // Program has common base of converting into decimal and then into their equivalent format
    //ie: binary => converted to decimal => converted to octal & Hexadecimal => output oct, hex, dec

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        bool statusBinA1 = false;
        //bool statusBinA2 = false;
        //bool statusBinA3 = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OctalClear_Click(object sender, RoutedEventArgs e)
        {
            //Clear each textbox/label used for output
            OctalOctal.Clear();
            OctalBinary.Clear();
            OctalDecimal.Clear();
            OctalHexadecimal.Clear();
        }

        private void OctalConvert_Click(object sender, RoutedEventArgs e)
        {
            int o1 = Convert.ToInt16(OctalOctal.Text);
            Octal.DecimaltoOctal(o1);
            o1 = Convert.ToInt32(Octal.returnDecOct);
            if (o1 == 8)
            { OctalOctal.Text += "    ERROR!!!!   The number you typed is not an octal number."; }
            else
            {
                Binary.ToBinary(o1);
                OctalBinary.Text = Binary.returnBinary;
                Decimal.ToDecimal(o1);
                OctalDecimal.Text = Decimal.returnDecimal;
                Hexadecimal.ToHexadecimal(o1);
                OctalHexadecimal.Text = Hexadecimal.returnHex;
            }
            //OctalDebug.Text = Convert.ToString(o1);
        }

        private void BinaryConvert_Click(object sender, RoutedEventArgs e)
        {
            string o1 = Convert.ToString(BinaryBinary.Text);
            Decimal.BinaryToDecimal(o1);
            int b1 = Convert.ToInt32(Decimal.returnDecimal);

            Octal.ToOctal(b1);
            BinaryOctal.Text = Octal.returnOctal;
            Decimal.ToDecimal(b1);
            BinaryDecimal.Text = Decimal.returnDecimal;
            Hexadecimal.ToHexadecimal(b1);
            BinaryHexadecimal.Text = Hexadecimal.returnHex;
        }

        private void BinaryClear_Click(object sender, RoutedEventArgs e)
        {
            BinaryOctal.Clear();
            BinaryBinary.Clear();
            BinaryDecimal.Clear();
            BinaryHexadecimal.Clear();
        }
        private void DecimalConvert_Click(object sender, RoutedEventArgs e)
        {
            int o1 = Convert.ToInt16(DecimalDecimal.Text);
            string s1 = DecimalDecimal.Text;
            Binary.ToBinary(o1);
            DecimalBinary.Text = Binary.returnBinary;
            Octal.ToOctal(o1);
            DecimalOctal.Text = Octal.returnOctal;
            Hexadecimal.ToHexadecimal(o1);
            DecimalHexadecimal.Text = Hexadecimal.returnHex;

        }

        private void DecimalClear_Click(object sender, RoutedEventArgs e)
        {
            DecimalOctal.Clear();
            DecimalBinary.Clear();
            DecimalDecimal.Clear();
            DecimalHexadecimal.Clear();
        }
        private void HexadecimalConvert_Click(object sender, RoutedEventArgs e)
        {
            string s1 = HexadecimalHexadecimal.Text;
            Decimal.HexToDecimal(s1);
            int o1 = Convert.ToInt16(Decimal.returnDecimal);
            Binary.ToBinary(o1);
            HexadecimalBinary.Text = Binary.returnBinary;
            Octal.ToOctal(o1);
            HexadecimalOctal.Text = Octal.returnOctal;
            Decimal.ToDecimal(o1);
            HexadecimalDecimal.Text = Decimal.returnDecimal;
        }

        private void HexadecimalClear_Click(object sender, RoutedEventArgs e)
        {
            HexadecimalOctal.Clear();
            HexadecimalBinary.Clear();
            HexadecimalDecimal.Clear();
            HexadecimalHexadecimal.Clear();
        }

        
        private void Ipv4convert_Click(object sender, RoutedEventArgs e)
        {
            string ipv4input1 = Ipv4input.Text;
            //string ipv4bin = IPv4.IPAddrToBinary(ipv4input1);
            //Ipv4toIpv6out.Text = IPv4.IPAddrToHex(ipv4bin);
            Ipv4toIpv6out.Text = IPv4.IPAddrToHex(ipv4input1);
        }

        private void Ipv4Clear_Click(object sender, RoutedEventArgs e)
        {
            Ipv4input.Clear();
            Ipv4toIpv6out.Clear();
        }



        private void IPv6Convert_Click(object sender, RoutedEventArgs e)
        {   //c0a00101
            //get string user entered
            string ipv6userinput = Ipv6input.Text;
            //split string
            IPv6.IPAddrToV4(ipv6userinput);
            //convert part 1
            string ipv6input1 = IPv6.ipv6part1;
            Decimal.HexToDecimal(ipv6input1);
            int o1 = Convert.ToInt16(Decimal.returnDecimal);
            //convert part 2
            string ipv6input2 = IPv6.ipv6part2; 
            Decimal.HexToDecimal(ipv6input2);
            int o2 = Convert.ToInt16(Decimal.returnDecimal);
            //convert part 3
            string ipv6input3 = IPv6.ipv6part3;
            Decimal.HexToDecimal(ipv6input3);
            int o3 = Convert.ToInt16(Decimal.returnDecimal);
            //convert part 4
            string ipv6input4 = IPv6.ipv6part4;
            Decimal.HexToDecimal(ipv6input4);
            int o4 = Convert.ToInt16(Decimal.returnDecimal);

            //C0A8010F
            Ipv6toIpv4out.Text = Convert.ToString(($"{o1}.{o2}.{o3}.{o4}"));
            //ipv6Debug.Text += "5";

        }

        private void Ipv6Clear_Click(object sender, RoutedEventArgs e)
        {
            Ipv6input.Clear();
            Ipv6toIpv4out.Clear();

        }

        private void Ipv6Test_Click(object sender, RoutedEventArgs e)
        {
            Ipv6input.Text = "0:0:0:0:0:FFFF:0AFE:4129";
        }

        private void CIDRCalc_Click(object sender, RoutedEventArgs e)
        {
            CIDR.cidrClass(CIDRinput.Text);
            int hosts = Convert.ToInt32(CIDRcomp.Text); 
            if (hosts >= 255)
            {
                CIDRlist.Text = "I am only proof of concept and can calulate less then 255 pc's";
                return;
            }
            else
            {
                //List<collection> CIDRcollection = new List<collection>();

                CIDR.cidrCalculator(hosts);
                foreach (var item in CIDR.CIDRcollection)
                {
                    CIDRlist.Text += item.collectionDisplay() + "\n";

                }
            }
            

        }

        private void CIDRClear_Click(object sender, RoutedEventArgs e)
        {
            CIDRinput.Clear();
            CIDRcomp.Clear();
            CIDRlist.Clear();
        }

        private void EndianconvertASCII_Click(object sender, RoutedEventArgs e)
        {
            string ea1 = EndianASCII.Text;
            Binary.AsciiToBinary(ea1);
            string o1 = Binary.returnBinary;
            //int o1 = Convert.ToInt16(Decimal.returnDecimal);
            //Binary.ToBinary(Convert.ToInt32(o1));
            EndianBinary.Text = Binary.returnBinary;
            Endian.LittleE(o1);
            EndianLittle.Text = Endian.returnLittleE;
            Endian.BigE(o1);
            EndianBig.Text = Endian.returnBigE;
        }

        private void EndianconvertBINARY_Click(object sender, RoutedEventArgs e)
        {
            string o1 = Convert.ToString(EndianBinary.Text);
            Decimal.BinaryToDecimal(o1);
            int b1 = Convert.ToInt32(Decimal.returnDecimal);

            Octal.ToOctal(b1);
            BinaryOctal.Text = Octal.returnOctal;
            Decimal.ToDecimal(b1);
            BinaryDecimal.Text = Decimal.returnDecimal;
            Hexadecimal.ToHexadecimal(b1);
            BinaryHexadecimal.Text = Hexadecimal.returnHex;
        }

        private void EndianClear_Click(object sender, RoutedEventArgs e)
        {
            EndianASCII.Clear();
            EndianBinary.Clear();
            EndianLittle.Clear();
            EndianBig.Clear();
        }

        private void AsciiConvert_Click(object sender, RoutedEventArgs e)
        {
            string ea1 = AsciiAscii.Text;
            Keyboard.ASCII(ea1);
            Binary.AsciiToBinary(ea1);
            Decimal.AsciiToDecimal(ea1);
            AsciiBinary.Text = Keyboard.ASCIIBinary;
            //AsciiBinary.Text = Binary.returnBinary;
            AsciiDecimal.Text = Decimal.ASCIIDecimal;
            
        }

        private void AsciiClear_Click(object sender, RoutedEventArgs e)
        {
            AsciiAscii.Clear();
            AsciiBinary.Clear();
            AsciiDecimal.Clear();
        }

        private void EBCDICConvert_Click(object sender, RoutedEventArgs e)
        {
            string ea1 = EBCDICEBCDIC.Text;
            Keyboard.EBCDIC(ea1);
            //Binary.AsciiToBinary(ea1);
            //Decimal.EBCDICToDecimal(ea1);
            EBCDICBinary.Text = Keyboard.EBCDICBinary;
            //EBCDICDecimal.Text = Decimal.EBCDICDecimal;
        }

        private void EBCDICClear_Click(object sender, RoutedEventArgs e)
        {
            EBCDICEBCDIC.Clear();
            EBCDICBinary.Clear();
            EBCDICDecimal.Clear();
        }

        //Following Retained for later development of IP address to binary/binary to ip address live changes page

        //private void BinA1_Click(object sender, RoutedEventArgs e)
        //{
        //    if (statusBinA1 == true)
        //    {
        //        binA1.Text = "1";
        //    }
        //    else
        //    {
        //        binA1 = '0';
        //    }
        //}

        //private void BinA2_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void BinA3_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void BinA4_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void BinA5_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void BinA6_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void BinA7_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void BinA8_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
