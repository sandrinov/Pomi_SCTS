using System;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace MvcClient.EthereumHelper
{
    public class ProductDeployment : ContractDeploymentMessage
    {
        public static string BYTECODE = new BlockChain().Get_ByteCode("Product");

        public ProductDeployment() : base(BYTECODE) { }

        [Parameter("bytes32", "_name", 1)]
        public String Name { get; set; }
        [Parameter("bytes32", "_additionalInformation", 2)]
        public String AdditionalInformation { get; set; }
        [Parameter("uint256", 3)]
        public int Latitude { get; set; }
        [Parameter("uint256", 4)]
        public int Longitude { get; set; }
        [Parameter("address", 5)]
        public string DataBaseContract { get; set; }

    }
}
