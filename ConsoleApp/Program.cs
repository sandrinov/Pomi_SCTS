using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class SuperClass
    {
        protected String  _superS;
        public SuperClass(string s)
        {
            _superS = s;
        }

        public string SuperS { get => _superS; }
    }

    class Myclass : SuperClass
    {
        static String s = new StringBuilder("param").ToString().ToUpper();
        public Myclass():base(s)
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //ConvertinHex();
            //ManageContract();
            Myclass mc = new Myclass();
            Console.WriteLine(mc.SuperS);
        }

        private static void ManageContract()
        {
            using (StreamReader r = new StreamReader(@"D:\users\sandr\source\repos\Pomi_SCTS\ConsoleApp\Cert.json"))
            {
                string json = r.ReadToEnd();
                dynamic data = JObject.Parse(json);
                Console.WriteLine(data.abi);
                Console.WriteLine(data.bytecode);
            }
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
