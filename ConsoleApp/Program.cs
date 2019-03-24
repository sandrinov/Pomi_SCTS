using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertinHex();
        }

        private static void ConvertinHex()
        {
            byte[] ba = Encoding.Default.GetBytes("sample");
            var hexString = BitConverter.ToString(ba);
            hexString = "0x" + hexString.Replace("-", "");
            Console.WriteLine(hexString);
        }
    }
}
