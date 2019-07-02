using System;
using Microsoft.AspNetCore.Hosting;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace IQC_Dapp.EthereumHelper
{
    public class CertDeployment : ContractDeploymentMessage
    {
        private static IHostingEnvironment _hostingEnvironment;
        private static string BYTECODE = new BlockChain(_hostingEnvironment).GetCert_ByteCode();
        public CertDeployment(IHostingEnvironment hostingEnvironment) : base(BYTECODE)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [Parameter("bytes32", "_issuedBy", 1)]
        public String IssuedBy { get; set; }
        [Parameter("bytes32", "_issuedTo", 2)]
        public String IssuedTo { get; set; }
        [Parameter("bytes32", "_issuingDate", 3)]
        public String IssuingDate { get; set; }
        [Parameter("bytes32", "_certHash", 4)]
        public String CertHash { get; set; }
        [Parameter("address", 5)]
        public string CertManagerContract { get; set; }
    }
}
