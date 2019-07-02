using MvcClient.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClient.EthereumHelper
{
    public class BlockChain
    {

        public String Get_ABI(string contractName)
        {
            using (StreamReader r = new StreamReader(GetFileName(contractName)))
            {
                string json = r.ReadToEnd();
                var abifromJson = GetAbiFromJson(json);
                return abifromJson;
            }
        }
        private string GetAbiFromJson(string json)
        {
            dynamic data = JObject.Parse(json);
            String s = data["abi"].ToString();
            String normalizedString = s.NormalizeCarriageReturn().NormalizeBackSlash();
            return normalizedString;
        }
        public String GetDefaultAccount()
        {
            using (StreamReader r = new StreamReader(GetFileName("Addresses")))
            {
                string json = r.ReadToEnd();
                dynamic data = JObject.Parse(json);
                string s = data["DefaultAccount"].ToString();
                return s;
            }
        }
        public String Get_Address(string contractName)
        {
            using (StreamReader r = new StreamReader(GetFileName("Addresses")))
            {
                string json = r.ReadToEnd();
                dynamic data = JObject.Parse(json);
                string s = data[contractName + "Address"].ToString();
                return s;
            }
        }
        public String Get_ByteCode(string contractname)
        {
            using (StreamReader r = new StreamReader(GetFileName(contractname)))
            {
                string json = r.ReadToEnd();
                dynamic data = JObject.Parse(json);
                String s = data["bytecode"].ToString();
                return s;
            }
        }
        private String GetFileName(string contractname)
        {
            var rootFolder = Directory.GetCurrentDirectory();

            string webRootPath = rootFolder + @"\wwwroot";
            string path = webRootPath + @"\contracts";
            String file = contractname + ".json";
            string contractFileName = Path.Combine(path, file);
            return contractFileName;
        }


        #region SCTS stuffs
        //      public static string DatabaseABI
        //      {
        //          get
        //          {
        //              return @"[
        //  {
        //     'constant ': true,
        //     'inputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'address '
        //      }
        //    ],
        //     'name ':  'addressToHandler ',
        //     'outputs ': [
        //      {
        //         'name ':  '_name ',
        //         'type ':  'string '
        //      },
        //      {
        //         'name ':  '_additionalInformation ',
        //         'type ':  'string '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0x590b2d9b '
        //  },
        //  {
        //     'constant ': true,
        //     'inputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'uint256 '
        //      }
        //    ],
        //     'name ':  'products ',
        //     'outputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'address '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0x7acc0b20 '
        //  },
        //  {
        //     'constant ': true,
        //     'inputs ': [],
        //     'name ':  'owner ',
        //     'outputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'address '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0x8da5cb5b '
        //  },
        //  {
        //     'constant ': false,
        //     'inputs ': [
        //      {
        //         'name ':  'newOwner ',
        //         'type ':  'address '
        //      }
        //    ],
        //     'name ':  'transferOwnership ',
        //     'outputs ': [],
        //     'payable ': false,
        //     'stateMutability ':  'nonpayable ',
        //     'type ':  'function ',
        //     'signature ':  '0xf2fde38b '
        //  },
        //  {
        //     'constant ': true,
        //     'inputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'uint256 '
        //      }
        //    ],
        //     'name ':  'addressHandlerSupport ',
        //     'outputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'address '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0xf6425cf6 '
        //  },
        //  {
        //     'inputs ': [],
        //     'payable ': false,
        //     'stateMutability ':  'nonpayable ',
        //     'type ':  'constructor ',
        //     'signature ':  'constructor '
        //  },
        //  {
        //     'payable ': false,
        //     'stateMutability ':  'nonpayable ',
        //     'type ':  'fallback '
        //  },
        //  {
        //     'constant ': true,
        //     'inputs ': [],
        //     'name ':  'getNumberOfProducts ',
        //     'outputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'uint256 '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0x3ffd81fb '
        //  },
        //  {
        //     'constant ': true,
        //     'inputs ': [
        //      {
        //         'name ':  'index ',
        //         'type ':  'uint256 '
        //      }
        //    ],
        //     'name ':  'getProduct ',
        //     'outputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'address '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0xb9db15b4 '
        //  },
        //  {
        //     'constant ': true,
        //     'inputs ': [],
        //     'name ':  'getNumberOfHandlers ',
        //     'outputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'uint256 '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0x8a48e067 '
        //  },
        //  {
        //     'constant ': true,
        //     'inputs ': [
        //      {
        //         'name ':  'index ',
        //         'type ':  'address '
        //      }
        //    ],
        //     'name ':  'getHandler ',
        //     'outputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'string '
        //      },
        //      {
        //         'name ':  ' ',
        //         'type ':  'string '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0xb6c9b393 '
        //  },
        //  {
        //     'constant ': false,
        //     'inputs ': [
        //      {
        //         'name ':  '_address ',
        //         'type ':  'address '
        //      },
        //      {
        //         'name ':  '_name ',
        //         'type ':  'string '
        //      },
        //      {
        //         'name ':  '_additionalInformation ',
        //         'type ':  'string '
        //      }
        //    ],
        //     'name ':  'addHandler ',
        //     'outputs ': [],
        //     'payable ': false,
        //     'stateMutability ':  'nonpayable ',
        //     'type ':  'function ',
        //     'signature ':  '0xcaa63742 '
        //  },
        //  {
        //     'constant ': false,
        //     'inputs ': [
        //      {
        //         'name ':  'productAddress ',
        //         'type ':  'address '
        //      }
        //    ],
        //     'name ':  'storeProductReference ',
        //     'outputs ': [],
        //     'payable ': false,
        //     'stateMutability ':  'nonpayable ',
        //     'type ':  'function ',
        //     'signature ':  '0x805593db '
        //  }
        //]";
        //          }
        //      }
        //      public static string ProductABI
        //      {
        //          get
        //          {
        //              return @" [
        //  {
        //     'constant ': true,
        //     'inputs ': [],
        //     'name ':  'name ',
        //     'outputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'bytes32 '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0x06fdde03 '
        //  },
        //  {
        //     'constant ': true,
        //     'inputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'uint256 '
        //      }
        //    ],
        //     'name ':  'childProducts ',
        //     'outputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'address '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0x0a430d89 '
        //  },
        //  {
        //     'constant ': true,
        //     'inputs ': [],
        //     'name ':  'DATABASE_CONTRACT ',
        //     'outputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'address '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0x301374c6 '
        //  },
        //  {
        //     'constant ': true,
        //     'inputs ': [],
        //     'name ':  'isConsumed ',
        //     'outputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'bool '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0x7a0d0031 '
        //  },
        //  {
        //     'constant ': true,
        //     'inputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'uint256 '
        //      }
        //    ],
        //     'name ':  'actions ',
        //     'outputs ': [
        //      {
        //         'name ':  'handler ',
        //         'type ':  'address '
        //      },
        //      {
        //         'name ':  'description ',
        //         'type ':  'bytes32 '
        //      },
        //      {
        //         'name ':  'lon ',
        //         'type ':  'uint256 '
        //      },
        //      {
        //         'name ':  'lat ',
        //         'type ':  'uint256 '
        //      },
        //      {
        //         'name ':  'timestamp ',
        //         'type ':  'uint256 '
        //      },
        //      {
        //         'name ':  'blockNumber ',
        //         'type ':  'uint256 '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0x83240f83 '
        //  },
        //  {
        //     'constant ': true,
        //     'inputs ': [],
        //     'name ':  'additionalInformation ',
        //     'outputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'bytes32 '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0x87b3eaba '
        //  },
        //  {
        //     'constant ': true,
        //     'inputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'uint256 '
        //      }
        //    ],
        //     'name ':  'parentProducts ',
        //     'outputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'address '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0xf227867f '
        //  },
        //  {
        //     'inputs ': [
        //      {
        //         'name ':  '_name ',
        //         'type ':  'bytes32 '
        //      },
        //      {
        //         'name ':  '_additionalInformation ',
        //         'type ':  'bytes32 '
        //      },
        //      {
        //         'name ':  '_lat ',
        //         'type ':  'uint256 '
        //      },
        //      {
        //         'name ':  '_lon ',
        //         'type ':  'uint256 '
        //      },
        //      {
        //         'name ':  '_DATABASE_CONTRACT ',
        //         'type ':  'address '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'nonpayable ',
        //     'type ':  'constructor ',
        //     'signature ':  'constructor '
        //  },
        //  {
        //     'payable ': false,
        //     'stateMutability ':  'nonpayable ',
        //     'type ':  'fallback '
        //  },
        //  {
        //     'constant ': true,
        //     'inputs ': [],
        //     'name ':  'getNumberOfActions ',
        //     'outputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'uint256 '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0xcd2048b2 '
        //  },
        //  {
        //     'constant ': true,
        //     'inputs ': [
        //      {
        //         'name ':  'index ',
        //         'type ':  'uint256 '
        //      }
        //    ],
        //     'name ':  'getAction ',
        //     'outputs ': [
        //      {
        //         'name ':  ' ',
        //         'type ':  'address '
        //      },
        //      {
        //         'name ':  ' ',
        //         'type ':  'bytes32 '
        //      },
        //      {
        //         'name ':  ' ',
        //         'type ':  'uint256 '
        //      },
        //      {
        //         'name ':  ' ',
        //         'type ':  'uint256 '
        //      },
        //      {
        //         'name ':  ' ',
        //         'type ':  'uint256 '
        //      },
        //      {
        //         'name ':  ' ',
        //         'type ':  'uint256 '
        //      }
        //    ],
        //     'payable ': false,
        //     'stateMutability ':  'view ',
        //     'type ':  'function ',
        //     'signature ':  '0xb6e76873 '
        //  },
        //  {
        //     'constant ': false,
        //     'inputs ': [
        //      {
        //         'name ':  'description ',
        //         'type ':  'bytes32 '
        //      },
        //      {
        //         'name ':  'lat ',
        //         'type ':  'uint256 '
        //      },
        //      {
        //         'name ':  'lon ',
        //         'type ':  'uint256 '
        //      },
        //      {
        //         'name ':  '_consumed ',
        //         'type ':  'bool '
        //      }
        //    ],
        //     'name ':  'addAction ',
        //     'outputs ': [],
        //     'payable ': false,
        //     'stateMutability ':  'nonpayable ',
        //     'type ':  'function ',
        //     'signature ':  '0x2e61cdec '
        //  },
        //  {
        //     'constant ': false,
        //     'inputs ': [
        //      {
        //         'name ':  'newProductAddress ',
        //         'type ':  'address '
        //      },
        //      {
        //         'name ':  'lat ',
        //         'type ':  'uint256 '
        //      },
        //      {
        //         'name ':  'lon ',
        //         'type ':  'uint256 '
        //      }
        //    ],
        //     'name ':  'collaborateInMerge ',
        //     'outputs ': [],
        //     'payable ': false,
        //     'stateMutability ':  'nonpayable ',
        //     'type ':  'function ',
        //     'signature ':  '0xc0a9ef46 '
        //  },
        //  {
        //     'constant ': false,
        //     'inputs ': [],
        //     'name ':  'consume ',
        //     'outputs ': [],
        //     'payable ': false,
        //     'stateMutability ':  'nonpayable ',
        //     'type ':  'function ',
        //     'signature ':  '0x1dedc6f7 '
        //  }
        //]";
        //          }
        //      }
        //      public static String DataBaseAddress
        //      {
        //          get
        //          {

        //              return @"0x1D13022439979Db3F64AF0A798bb4cea1A11076d";
        //          }
        //      }
        //      public static String ProductAddress
        //      {
        //          get
        //          {
        //              return @"0x49d4378E9537f3c8C41d37a453f08D73627eDB86";
        //          }
        //      }
        //      public static String ProductByteCode
        //      {
        //          get
        //          {
        //              return @"0x6080604052600436106100ba576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff16806306fdde03146101355780630a430d89146101605780631dedc6f7146101db5780632e61cdec146101f2578063301374c61461024d5780637a0d0031146102a457806383240f83146102d357806387b3eaba14610371578063b6e768731461039c578063c0a9ef461461043a578063cd2048b21461049f578063f227867f146104ca575b3480156100c657600080fd5b506040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252600f8152602001807f6e6f20657468206163636570746564000000000000000000000000000000000081525060200191505060405180910390fd5b34801561014157600080fd5b5061014a610545565b6040518082815260200191505060405180910390f35b34801561016c57600080fd5b506101996004803603602081101561018357600080fd5b810190808035906020019092919050505061054b565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156101e757600080fd5b506101f0610589565b005b3480156101fe57600080fd5b5061024b6004803603608081101561021557600080fd5b81019080803590602001909291908035906020019092919080359060200190929190803515159060200190929190505050610629565b005b34801561025957600080fd5b506102626107e9565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156102b057600080fd5b506102b961080e565b604051808215151515815260200191505060405180910390f35b3480156102df57600080fd5b5061030c600480360360208110156102f657600080fd5b8101908080359060200190929190505050610821565b604051808773ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001868152602001858152602001848152602001838152602001828152602001965050505050505060405180910390f35b34801561037d57600080fd5b5061038661088c565b6040518082815260200191505060405180910390f35b3480156103a857600080fd5b506103d5600480360360208110156103bf57600080fd5b8101908080359060200190929190505050610892565b604051808773ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001868152602001858152602001848152602001838152602001828152602001965050505050505060405180910390f35b34801561044657600080fd5b5061049d6004803603606081101561045d57600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291908035906020019092919080359060200190929190505050610996565b005b3480156104ab57600080fd5b506104b4610c3d565b6040518082815260200191505060405180910390f35b3480156104d657600080fd5b50610503600480360360208110156104ed57600080fd5b8101908080359060200190929190505050610c4a565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b60045481565b60028181548110151561055a57fe5b906000526020600020016000915054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b600360009054906101000a900460ff161561060c576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252600c8152602001807f6e6f7420636f6e73756d6564000000000000000000000000000000000000000081525060200191505060405180910390fd5b6001600360006101000a81548160ff021916908315150217905550565b600360009054906101000a900460ff16156106ac576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252600c8152602001807f6e6f7420636f6e73756d6564000000000000000000000000000000000000000081525060200191505060405180910390fd5b6106b4610c88565b33816000019073ffffffffffffffffffffffffffffffffffffffff16908173ffffffffffffffffffffffffffffffffffffffff168152505084816020018181525050828160400181815250508381606001818152505042816080018181525050438160a00181815250506006819080600181540180825580915050906001820390600052602060002090600602016000909192909190915060008201518160000160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506020820151816001015560408201518160020155606082015181600301556080820151816004015560a0820151816005015550505081600360006101000a81548160ff0219169083151502179055505050505050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b600360009054906101000a900460ff1681565b60068181548110151561083057fe5b90600052602060002090600602016000915090508060000160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16908060010154908060020154908060030154908060040154908060050154905086565b60055481565b6000806000806000806006878154811015156108aa57fe5b906000526020600020906006020160000160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff166006888154811015156108eb57fe5b90600052602060002090600602016001015460068981548110151561090c57fe5b90600052602060002090600602016003015460068a81548110151561092d57fe5b90600052602060002090600602016002015460068b81548110151561094e57fe5b90600052602060002090600602016004015460068c81548110151561096f57fe5b90600052602060002090600602016005015495509550955095509550955091939550919395565b600360009054906101000a900460ff1615610a19576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252600c8152602001807f6e6f7420636f6e73756d6564000000000000000000000000000000000000000081525060200191505060405180910390fd5b60028390806001815401808255809150509060018203906000526020600020016000909192909190916101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555050610a87610c88565b30816000019073ffffffffffffffffffffffffffffffffffffffff16908173ffffffffffffffffffffffffffffffffffffffff16815250507f436f6c6c61626f7261746520696e206d65726765000000000000000000000000816020018181525050818160400181815250508281606001818152505042816080018181525050438160a00181815250506006819080600181540180825580915050906001820390600052602060002090600602016000909192909190915060008201518160000160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506020820151816001015560408201518160020155606082015181600301556080820151816004015560a082015181600501555050503073ffffffffffffffffffffffffffffffffffffffff16631dedc6f76040518163ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401600060405180830381600087803b158015610c1f57600080fd5b505af1158015610c33573d6000803e3d6000fd5b5050505050505050565b6000600680549050905090565b600181815481101515610c5957fe5b906000526020600020016000915054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60c060405190810160405280600073ffffffffffffffffffffffffffffffffffffffff1681526020016000801916815260200160008152602001600081526020016000815260200160008152509056fea165627a7a723058206f95b056592e2ac2cf47a5c7b7777f2999cf17fe7b8ef51d8a5a8777f1d144c40029";
        //          }
        //      }
        #endregion

    }
}
