using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IQC_Dapp.EthereumHelper
{
 
    public class BlockChain
    {
        protected IHostingEnvironment _hostingEnvironment;
        public BlockChain(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            
        }
        public String GetCert_ABI()
        {
            using (StreamReader r = new StreamReader(GetCertFileName()))
            {
                string json = r.ReadToEnd();
                dynamic data = JObject.Parse(json);
                return data.abi;
            }
        }
        public String GetCert_Address()
        {
            using (StreamReader r = new StreamReader(GetAddressesFileName()))
            {
                string json = r.ReadToEnd();
                dynamic data = JObject.Parse(json);
                return data.CertAddress;
            }
        }
        public String GetCertManager_Address()
        {
            using (StreamReader r = new StreamReader(GetAddressesFileName()))
            {
                string json = r.ReadToEnd();
                dynamic data = JObject.Parse(json);
                return data.CertManagerAddress;
            }
        }
        public String GetCert_ByteCode()
        {
            using (StreamReader r = new StreamReader(GetCertFileName()))
            {
                string json = r.ReadToEnd();
                dynamic data = JObject.Parse(json);
                return data.bytecode;
            }
        }
        private String GetCertFileName()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string path = webRootPath + @"\contracts";
            String file = "Cert.json";
            string contractFileName = Path.Combine(path, file);
            return contractFileName;
        }
        private String GetAddressesFileName()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string path = webRootPath + @"\contracts";
            String file = "Addresses.json";
            string contractFileName = Path.Combine(path, file);
            return contractFileName;
        }
    }
}
