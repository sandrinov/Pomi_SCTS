using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClient.EthereumHelper
{
    public class BlockChain
    {
        #region SCTS stuffs
        public static string DatabaseABI
        {
            get
            {
                return @"[
    {
      'constant': true,
      'inputs': [
        {
          'name': '',
          'type': 'address'
        }
      ],
      'name': 'addressToHandler',
      'outputs': [
        {
          'name': '_name',
          'type': 'string'
        },
        {
          'name': '_additionalInformation',
          'type': 'string'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0x590b2d9b'
    },
    {
      'constant': true,
      'inputs': [
        {
          'name': '',
          'type': 'uint256'
        }
      ],
      'name': 'products',
      'outputs': [
        {
          'name': '',
          'type': 'address'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0x7acc0b20'
    },
    {
      'constant': true,
      'inputs': [],
      'name': 'owner',
      'outputs': [
        {
          'name': '',
          'type': 'address'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0x8da5cb5b'
    },
    {
      'constant': false,
      'inputs': [
        {
          'name': 'newOwner',
          'type': 'address'
        }
      ],
      'name': 'transferOwnership',
      'outputs': [],
      'payable': false,
      'stateMutability': 'nonpayable',
      'type': 'function',
      'signature': '0xf2fde38b'
    },
    {
      'constant': true,
      'inputs': [
        {
          'name': '',
          'type': 'uint256'
        }
      ],
      'name': 'addressHandlerSupport',
      'outputs': [
        {
          'name': '',
          'type': 'address'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0xf6425cf6'
    },
    {
      'inputs': [],
      'payable': false,
      'stateMutability': 'nonpayable',
      'type': 'constructor',
      'signature': 'constructor'
    },
    {
      'payable': false,
      'stateMutability': 'nonpayable',
      'type': 'fallback'
    },
    {
      'constant': true,
      'inputs': [],
      'name': 'getNumberOfProducts',
      'outputs': [
        {
          'name': '',
          'type': 'uint256'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0x3ffd81fb'
    },
    {
      'constant': true,
      'inputs': [
        {
          'name': 'index',
          'type': 'uint256'
        }
      ],
      'name': 'getProduct',
      'outputs': [
        {
          'name': '',
          'type': 'address'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0xb9db15b4'
    },
    {
      'constant': true,
      'inputs': [],
      'name': 'getNumberOfHandlers',
      'outputs': [
        {
          'name': '',
          'type': 'uint256'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0x8a48e067'
    },
    {
      'constant': true,
      'inputs': [
        {
          'name': 'index',
          'type': 'address'
        }
      ],
      'name': 'getHandler',
      'outputs': [
        {
          'name': '',
          'type': 'string'
        },
        {
          'name': '',
          'type': 'string'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0xb6c9b393'
    },
    {
      'constant': false,
      'inputs': [
        {
          'name': '_address',
          'type': 'address'
        },
        {
          'name': '_name',
          'type': 'string'
        },
        {
          'name': '_additionalInformation',
          'type': 'string'
        }
      ],
      'name': 'addHandler',
      'outputs': [],
      'payable': false,
      'stateMutability': 'nonpayable',
      'type': 'function',
      'signature': '0xcaa63742'
    },
    {
      'constant': false,
      'inputs': [
        {
          'name': 'productAddress',
          'type': 'address'
        }
      ],
      'name': 'storeProductReference',
      'outputs': [],
      'payable': false,
      'stateMutability': 'nonpayable',
      'type': 'function',
      'signature': '0x805593db'
    }
  ]";
            }
        }
        public static string ProductABI
        {
            get
            {
                return @"[
    {
      'constant': true,
      'inputs': [],
      'name': 'name',
      'outputs': [
        {
          'name': '',
          'type': 'bytes32'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0x06fdde03'
    },
    {
      'constant': true,
      'inputs': [
        {
          'name': '',
          'type': 'uint256'
        }
      ],
      'name': 'childProducts',
      'outputs': [
        {
          'name': '',
          'type': 'address'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0x0a430d89'
    },
    {
      'constant': true,
      'inputs': [],
      'name': 'DATABASE_CONTRACT',
      'outputs': [
        {
          'name': '',
          'type': 'address'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0x301374c6'
    },
    {
      'constant': true,
      'inputs': [],
      'name': 'isConsumed',
      'outputs': [
        {
          'name': '',
          'type': 'bool'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0x7a0d0031'
    },
    {
      'constant': true,
      'inputs': [
        {
          'name': '',
          'type': 'uint256'
        }
      ],
      'name': 'actions',
      'outputs': [
        {
          'name': 'handler',
          'type': 'address'
        },
        {
          'name': 'description',
          'type': 'bytes32'
        },
        {
          'name': 'lon',
          'type': 'uint256'
        },
        {
          'name': 'lat',
          'type': 'uint256'
        },
        {
          'name': 'timestamp',
          'type': 'uint256'
        },
        {
          'name': 'blockNumber',
          'type': 'uint256'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0x83240f83'
    },
    {
      'constant': true,
      'inputs': [],
      'name': 'additionalInformation',
      'outputs': [
        {
          'name': '',
          'type': 'bytes32'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0x87b3eaba'
    },
    {
      'constant': true,
      'inputs': [
        {
          'name': '',
          'type': 'uint256'
        }
      ],
      'name': 'parentProducts',
      'outputs': [
        {
          'name': '',
          'type': 'address'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0xf227867f'
    },
    {
      'inputs': [
        {
          'name': '_name',
          'type': 'bytes32'
        },
        {
          'name': '_additionalInformation',
          'type': 'bytes32'
        },
        {
          'name': '_lat',
          'type': 'uint256'
        },
        {
          'name': '_lon',
          'type': 'uint256'
        },
        {
          'name': '_DATABASE_CONTRACT',
          'type': 'address'
        }
      ],
      'payable': false,
      'stateMutability': 'nonpayable',
      'type': 'constructor',
      'signature': 'constructor'
    },
    {
      'payable': false,
      'stateMutability': 'nonpayable',
      'type': 'fallback'
    },
    {
      'constant': true,
      'inputs': [],
      'name': 'getNumberOfActions',
      'outputs': [
        {
          'name': '',
          'type': 'uint256'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0xcd2048b2'
    },
    {
      'constant': true,
      'inputs': [
        {
          'name': 'index',
          'type': 'uint256'
        }
      ],
      'name': 'getAction',
      'outputs': [
        {
          'name': '',
          'type': 'address'
        },
        {
          'name': '',
          'type': 'bytes32'
        },
        {
          'name': '',
          'type': 'uint256'
        },
        {
          'name': '',
          'type': 'uint256'
        },
        {
          'name': '',
          'type': 'uint256'
        },
        {
          'name': '',
          'type': 'uint256'
        }
      ],
      'payable': false,
      'stateMutability': 'view',
      'type': 'function',
      'signature': '0xb6e76873'
    },
    {
      'constant': false,
      'inputs': [
        {
          'name': 'description',
          'type': 'bytes32'
        },
        {
          'name': 'lat',
          'type': 'uint256'
        },
        {
          'name': 'lon',
          'type': 'uint256'
        },
        {
          'name': '_consumed',
          'type': 'bool'
        }
      ],
      'name': 'addAction',
      'outputs': [],
      'payable': false,
      'stateMutability': 'nonpayable',
      'type': 'function',
      'signature': '0x2e61cdec'
    },
    {
      'constant': false,
      'inputs': [
        {
          'name': 'newProductAddress',
          'type': 'address'
        },
        {
          'name': 'lat',
          'type': 'uint256'
        },
        {
          'name': 'lon',
          'type': 'uint256'
        }
      ],
      'name': 'collaborateInMerge',
      'outputs': [],
      'payable': false,
      'stateMutability': 'nonpayable',
      'type': 'function',
      'signature': '0xc0a9ef46'
    },
    {
      'constant': false,
      'inputs': [],
      'name': 'consume',
      'outputs': [],
      'payable': false,
      'stateMutability': 'nonpayable',
      'type': 'function',
      'signature': '0x1dedc6f7'
    }
  ]";
            }
        }
        public static String DataBaseAddress
        {
            get
            {

                return @"0xdE554c0b4Ca9eFcf1958c01485d673a0b06D5BC1";
            }
        }
        public static String ProductAddress
        {
            get
            {
                return @"0xb38BE41f6cFc874eC5332e180c87adEb42a609d6";
            }
        }
        public static String ProductByteCode
        {
            get
            {
                return @"0x608060405234801561001057600080fd5b5060405160a080611056833981018060405260a081101561003057600080fd5b810190808051906020019092919080519060200190929190805190602001909291908051906020019092919080519060200190929190505050846004819055506000600360006101000a81548160ff02191690831515021790555083600581905550806000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506100da6102f3565b33816000019073ffffffffffffffffffffffffffffffffffffffff16908173ffffffffffffffffffffffffffffffffffffffff16815250507f50726f64756374206372656174696f6e00000000000000000000000000000000816020018181525050828160400181815250508381606001818152505042816080018181525050438160a00181815250506006819080600181540180825580915050906001820390600052602060002090600602016000909192909190915060008201518160000160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506020820151816001015560408201518160020155606082015181600301556080820151816004015560a0820151816005015550505060008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663805593db306040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001915050600060405180830381600087803b1580156102cf57600080fd5b505af11580156102e3573d6000803e3d6000fd5b5050505050505050505050610343565b60c060405190810160405280600073ffffffffffffffffffffffffffffffffffffffff16815260200160008019168152602001600081526020016000815260200160008152602001600081525090565b610d04806103526000396000f3fe6080604052600436106100ba576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff16806306fdde03146101355780630a430d89146101605780631dedc6f7146101db5780632e61cdec146101f2578063301374c61461024d5780637a0d0031146102a457806383240f83146102d357806387b3eaba14610371578063b6e768731461039c578063c0a9ef461461043a578063cd2048b21461049f578063f227867f146104ca575b3480156100c657600080fd5b506040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252600f8152602001807f6e6f20657468206163636570746564000000000000000000000000000000000081525060200191505060405180910390fd5b34801561014157600080fd5b5061014a610545565b6040518082815260200191505060405180910390f35b34801561016c57600080fd5b506101996004803603602081101561018357600080fd5b810190808035906020019092919050505061054b565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156101e757600080fd5b506101f0610589565b005b3480156101fe57600080fd5b5061024b6004803603608081101561021557600080fd5b81019080803590602001909291908035906020019092919080359060200190929190803515159060200190929190505050610629565b005b34801561025957600080fd5b506102626107e9565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156102b057600080fd5b506102b961080e565b604051808215151515815260200191505060405180910390f35b3480156102df57600080fd5b5061030c600480360360208110156102f657600080fd5b8101908080359060200190929190505050610821565b604051808773ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001868152602001858152602001848152602001838152602001828152602001965050505050505060405180910390f35b34801561037d57600080fd5b5061038661088c565b6040518082815260200191505060405180910390f35b3480156103a857600080fd5b506103d5600480360360208110156103bf57600080fd5b8101908080359060200190929190505050610892565b604051808773ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001868152602001858152602001848152602001838152602001828152602001965050505050505060405180910390f35b34801561044657600080fd5b5061049d6004803603606081101561045d57600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291908035906020019092919080359060200190929190505050610996565b005b3480156104ab57600080fd5b506104b4610c3d565b6040518082815260200191505060405180910390f35b3480156104d657600080fd5b50610503600480360360208110156104ed57600080fd5b8101908080359060200190929190505050610c4a565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b60045481565b60028181548110151561055a57fe5b906000526020600020016000915054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b600360009054906101000a900460ff161561060c576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252600c8152602001807f6e6f7420636f6e73756d6564000000000000000000000000000000000000000081525060200191505060405180910390fd5b6001600360006101000a81548160ff021916908315150217905550565b600360009054906101000a900460ff16156106ac576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252600c8152602001807f6e6f7420636f6e73756d6564000000000000000000000000000000000000000081525060200191505060405180910390fd5b6106b4610c88565b33816000019073ffffffffffffffffffffffffffffffffffffffff16908173ffffffffffffffffffffffffffffffffffffffff168152505084816020018181525050828160400181815250508381606001818152505042816080018181525050438160a00181815250506006819080600181540180825580915050906001820390600052602060002090600602016000909192909190915060008201518160000160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506020820151816001015560408201518160020155606082015181600301556080820151816004015560a0820151816005015550505081600360006101000a81548160ff0219169083151502179055505050505050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b600360009054906101000a900460ff1681565b60068181548110151561083057fe5b90600052602060002090600602016000915090508060000160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16908060010154908060020154908060030154908060040154908060050154905086565b60055481565b6000806000806000806006878154811015156108aa57fe5b906000526020600020906006020160000160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff166006888154811015156108eb57fe5b90600052602060002090600602016001015460068981548110151561090c57fe5b90600052602060002090600602016003015460068a81548110151561092d57fe5b90600052602060002090600602016002015460068b81548110151561094e57fe5b90600052602060002090600602016004015460068c81548110151561096f57fe5b90600052602060002090600602016005015495509550955095509550955091939550919395565b600360009054906101000a900460ff1615610a19576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252600c8152602001807f6e6f7420636f6e73756d6564000000000000000000000000000000000000000081525060200191505060405180910390fd5b60028390806001815401808255809150509060018203906000526020600020016000909192909190916101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555050610a87610c88565b30816000019073ffffffffffffffffffffffffffffffffffffffff16908173ffffffffffffffffffffffffffffffffffffffff16815250507f436f6c6c61626f7261746520696e206d65726765000000000000000000000000816020018181525050818160400181815250508281606001818152505042816080018181525050438160a00181815250506006819080600181540180825580915050906001820390600052602060002090600602016000909192909190915060008201518160000160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506020820151816001015560408201518160020155606082015181600301556080820151816004015560a082015181600501555050503073ffffffffffffffffffffffffffffffffffffffff16631dedc6f76040518163ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401600060405180830381600087803b158015610c1f57600080fd5b505af1158015610c33573d6000803e3d6000fd5b5050505050505050565b6000600680549050905090565b600181815481101515610c5957fe5b906000526020600020016000915054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60c060405190810160405280600073ffffffffffffffffffffffffffffffffffffffff1681526020016000801916815260200160008152602001600081526020016000815260200160008152509056fea165627a7a723058205abc0914453636ec4b2de0cfc2665d9c2b2017f6ea7a36aa3fcdbe49bbbc4bba0029";
            }
        }
        #endregion

        #region Openbadge
        //      public static string OBDatabaseABI
        //      {
        //          get
        //          {
        //              return @"[
        //  {
        //    'constant': true,
        //    'inputs': [
        //      {
        //        'name': '',
        //        'type': 'uint256'
        //      }
        //    ],
        //    'name': 'assertions',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'address'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'owner',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'address'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': false,
        //    'inputs': [
        //      {
        //        'name': 'newOwner',
        //        'type': 'address'
        //      }
        //    ],
        //    'name': 'transferOwnership',
        //    'outputs': [],
        //    'payable': false,
        //    'stateMutability': 'nonpayable',
        //    'type': 'function'
        //  },
        //  {
        //    'inputs': [],
        //    'payable': false,
        //    'stateMutability': 'nonpayable',
        //    'type': 'constructor'
        //  },
        //  {
        //    'payable': false,
        //    'stateMutability': 'nonpayable',
        //    'type': 'fallback'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'getNumberOfAssertions',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'uint256'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [
        //      {
        //        'name': 'index',
        //        'type': 'uint256'
        //      }
        //    ],
        //    'name': 'getAssertion',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'address'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': false,
        //    'inputs': [
        //      {
        //        'name': 'assertionAddress',
        //        'type': 'address'
        //      }
        //    ],
        //    'name': 'storeAssertion',
        //    'outputs': [],
        //    'payable': false,
        //    'stateMutability': 'nonpayable',
        //    'type': 'function'
        //  }
        //]";
        //          }
        //      }
        //      public static string OpenBadgeABI
        //      {
        //          get
        //          {
        //              return @"[
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'OB_DATABASE_CONTRACT',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'address'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'recipient_type',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'string'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'badge_issuer',
        //    'outputs': [
        //      {
        //        'name': 'id',
        //        'type': 'string'
        //      },
        //      {
        //        'name': 'name',
        //        'type': 'string'
        //      },
        //      {
        //        'name': 'image',
        //        'type': 'string'
        //      },
        //      {
        //        'name': 'url',
        //        'type': 'string'
        //      },
        //      {
        //        'name': 'email',
        //        'type': 'string'
        //      },
        //      {
        //        'name': 'publicKey',
        //        'type': 'string'
        //      },
        //      {
        //        'name': 'revocationList',
        //        'type': 'string'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'recipient_salt',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'string'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'issuedOn',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'string'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'badge',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'string'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'evidence',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'string'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'id',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'string'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'expires',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'string'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'recipient_identity',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'string'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'recipient_hashed',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'bool'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'context',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'string'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'image',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'string'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'verification_type',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'string'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'inputs': [
        //      {
        //        'name': '_context',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_id',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_recipient_type',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_recipient_hashed',
        //        'type': 'bool'
        //      },
        //      {
        //        'name': '_recipient_salt',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_recipient_identity',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_image',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_evidence',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_issuedOn',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_expires',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_badge',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_verification_type',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_OB_DATABASE_CONTRACT',
        //        'type': 'address'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'nonpayable',
        //    'type': 'constructor'
        //  },
        //  {
        //    'payable': false,
        //    'stateMutability': 'nonpayable',
        //    'type': 'fallback'
        //  },
        //  {
        //    'constant': false,
        //    'inputs': [
        //      {
        //        'name': '_id',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_name',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_image',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_url',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_email',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_publicKey',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '_revocationList',
        //        'type': 'string'
        //      }
        //    ],
        //    'name': 'addIssuer',
        //    'outputs': [],
        //    'payable': false,
        //    'stateMutability': 'nonpayable',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'getIssuer',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '',
        //        'type': 'string'
        //      },
        //      {
        //        'name': '',
        //        'type': 'string'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  }
        //]";
        //          }
        //      }
        //      public static String OBDataBaseAddress
        //      {
        //          get
        //          {
        //              return @"0x48c768c066489332afc07be2ba078b6cee94f99c";
        //          }
        //      }
        //      public static String OpenBadgeAddress
        //      {
        //          get
        //          {
        //              return @"0xa24b36c5b9954e50ab2e69e3e3788724b9b97f2d";
        //          }
        //      }
        //      public static String OpenBadgeByteCode
        //      {
        //          get
        //          {
        //              return @"0x60806040523480156200001157600080fd5b50604051620025cb380380620025cb8339810180604052810190808051820192919060200180518201929190602001805182019291906020018051906020019092919080518201929190602001805182019291906020018051820192919060200180518201929190602001805182019291906020018051820192919060200180518201929190602001805182019291906020018051906020019092919050505060008d60019080519060200190620000cb9291906200030d565b508c60029080519060200190620000e49291906200030d565b508b60039080519060200190620000fd9291906200030d565b508a600460006101000a81548160ff0219169083151502179055508960059080519060200190620001309291906200030d565b508860069080519060200190620001499291906200030d565b508760079080519060200190620001629291906200030d565b5086600890805190602001906200017b9291906200030d565b508560099080519060200190620001949291906200030d565b5084600a9080519060200190620001ad9291906200030d565b5083600b9080519060200190620001c69291906200030d565b5082600c9080519060200190620001df9291906200030d565b50816000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663bb3d95a4306040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001915050600060405180830381600087803b158015620002e057600080fd5b505af1158015620002f5573d6000803e3d6000fd5b505050505050505050505050505050505050620003bc565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106200035057805160ff191683800117855562000381565b8280016001018555821562000381579182015b828111156200038057825182559160200191906001019062000363565b5b50905062000390919062000394565b5090565b620003b991905b80821115620003b55760008160009055506001016200039b565b5090565b90565b6121ff80620003cc6000396000f3006080604052600436106100e6576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff168063208cc594146100f85780632114af8c1461014f578063221e41c5146101df57806352556421146104f75780635e4ec4da1461080f57806377dc74b21461089f57806391d768de1461092f578063a77e0987146109bf578063af640d0f14610a4f578063b1cb0db314610adf578063b775deb914610b6f578063bf17d8da14610bff578063c679863114610e0c578063d0496d6a14610e3b578063f3ccaac014610ecb578063ff41552214610f5b575b3480156100f257600080fd5b50600080fd5b34801561010457600080fd5b5061010d610feb565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561015b57600080fd5b50610164611010565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156101a4578082015181840152602081019050610189565b50505050905090810190601f1680156101d15780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b3480156101eb57600080fd5b506101f46110ae565b604051808060200180602001806020018060200180602001806020018060200188810388528f818151815260200191508051906020019080838360005b8381101561024c578082015181840152602081019050610231565b50505050905090810190601f1680156102795780820380516001836020036101000a031916815260200191505b5088810387528e818151815260200191508051906020019080838360005b838110156102b2578082015181840152602081019050610297565b50505050905090810190601f1680156102df5780820380516001836020036101000a031916815260200191505b5088810386528d818151815260200191508051906020019080838360005b838110156103185780820151818401526020810190506102fd565b50505050905090810190601f1680156103455780820380516001836020036101000a031916815260200191505b5088810385528c818151815260200191508051906020019080838360005b8381101561037e578082015181840152602081019050610363565b50505050905090810190601f1680156103ab5780820380516001836020036101000a031916815260200191505b5088810384528b818151815260200191508051906020019080838360005b838110156103e45780820151818401526020810190506103c9565b50505050905090810190601f1680156104115780820380516001836020036101000a031916815260200191505b5088810383528a818151815260200191508051906020019080838360005b8381101561044a57808201518184015260208101905061042f565b50505050905090810190601f1680156104775780820380516001836020036101000a031916815260200191505b50888103825289818151815260200191508051906020019080838360005b838110156104b0578082015181840152602081019050610495565b50505050905090810190601f1680156104dd5780820380516001836020036101000a031916815260200191505b509e50505050505050505050505050505060405180910390f35b34801561050357600080fd5b5061050c611506565b604051808060200180602001806020018060200180602001806020018060200188810388528f818151815260200191508051906020019080838360005b83811015610564578082015181840152602081019050610549565b50505050905090810190601f1680156105915780820380516001836020036101000a031916815260200191505b5088810387528e818151815260200191508051906020019080838360005b838110156105ca5780820151818401526020810190506105af565b50505050905090810190601f1680156105f75780820380516001836020036101000a031916815260200191505b5088810386528d818151815260200191508051906020019080838360005b83811015610630578082015181840152602081019050610615565b50505050905090810190601f16801561065d5780820380516001836020036101000a031916815260200191505b5088810385528c818151815260200191508051906020019080838360005b8381101561069657808201518184015260208101905061067b565b50505050905090810190601f1680156106c35780820380516001836020036101000a031916815260200191505b5088810384528b818151815260200191508051906020019080838360005b838110156106fc5780820151818401526020810190506106e1565b50505050905090810190601f1680156107295780820380516001836020036101000a031916815260200191505b5088810383528a818151815260200191508051906020019080838360005b83811015610762578082015181840152602081019050610747565b50505050905090810190601f16801561078f5780820380516001836020036101000a031916815260200191505b50888103825289818151815260200191508051906020019080838360005b838110156107c85780820151818401526020810190506107ad565b50505050905090810190601f1680156107f55780820380516001836020036101000a031916815260200191505b509e50505050505050505050505050505060405180910390f35b34801561081b57600080fd5b5061082461198f565b6040518080602001828103825283818151815260200191508051906020019080838360005b83811015610864578082015181840152602081019050610849565b50505050905090810190601f1680156108915780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b3480156108ab57600080fd5b506108b4611a2d565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156108f45780820151818401526020810190506108d9565b50505050905090810190601f1680156109215780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b34801561093b57600080fd5b50610944611acb565b6040518080602001828103825283818151815260200191508051906020019080838360005b83811015610984578082015181840152602081019050610969565b50505050905090810190601f1680156109b15780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b3480156109cb57600080fd5b506109d4611b69565b6040518080602001828103825283818151815260200191508051906020019080838360005b83811015610a145780820151818401526020810190506109f9565b50505050905090810190601f168015610a415780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b348015610a5b57600080fd5b50610a64611c07565b6040518080602001828103825283818151815260200191508051906020019080838360005b83811015610aa4578082015181840152602081019050610a89565b50505050905090810190601f168015610ad15780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b348015610aeb57600080fd5b50610af4611ca5565b6040518080602001828103825283818151815260200191508051906020019080838360005b83811015610b34578082015181840152602081019050610b19565b50505050905090810190601f168015610b615780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b348015610b7b57600080fd5b50610b84611d43565b6040518080602001828103825283818151815260200191508051906020019080838360005b83811015610bc4578082015181840152602081019050610ba9565b50505050905090810190601f168015610bf15780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b348015610c0b57600080fd5b50610e0a600480360381019080803590602001908201803590602001908080601f0160208091040260200160405190810160405280939291908181526020018383808284378201915050505050509192919290803590602001908201803590602001908080601f0160208091040260200160405190810160405280939291908181526020018383808284378201915050505050509192919290803590602001908201803590602001908080601f0160208091040260200160405190810160405280939291908181526020018383808284378201915050505050509192919290803590602001908201803590602001908080601f0160208091040260200160405190810160405280939291908181526020018383808284378201915050505050509192919290803590602001908201803590602001908080601f0160208091040260200160405190810160405280939291908181526020018383808284378201915050505050509192919290803590602001908201803590602001908080601f0160208091040260200160405190810160405280939291908181526020018383808284378201915050505050509192919290803590602001908201803590602001908080601f0160208091040260200160405190810160405280939291908181526020018383808284378201915050505050509192919290505050611de1565b005b348015610e1857600080fd5b50610e21611f03565b604051808215151515815260200191505060405180910390f35b348015610e4757600080fd5b50610e50611f16565b6040518080602001828103825283818151815260200191508051906020019080838360005b83811015610e90578082015181840152602081019050610e75565b50505050905090810190601f168015610ebd5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b348015610ed757600080fd5b50610ee0611fb4565b6040518080602001828103825283818151815260200191508051906020019080838360005b83811015610f20578082015181840152602081019050610f05565b50505050905090810190601f168015610f4d5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b348015610f6757600080fd5b50610f70612052565b6040518080602001828103825283818151815260200191508051906020019080838360005b83811015610fb0578082015181840152602081019050610f95565b50505050905090810190601f168015610fdd5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60038054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156110a65780601f1061107b576101008083540402835291602001916110a6565b820191906000526020600020905b81548152906001019060200180831161108957829003601f168201915b505050505081565b600d806000018054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156111485780601f1061111d57610100808354040283529160200191611148565b820191906000526020600020905b81548152906001019060200180831161112b57829003601f168201915b505050505090806001018054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156111e65780601f106111bb576101008083540402835291602001916111e6565b820191906000526020600020905b8154815290600101906020018083116111c957829003601f168201915b505050505090806002018054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156112845780601f1061125957610100808354040283529160200191611284565b820191906000526020600020905b81548152906001019060200180831161126757829003601f168201915b505050505090806003018054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156113225780601f106112f757610100808354040283529160200191611322565b820191906000526020600020905b81548152906001019060200180831161130557829003601f168201915b505050505090806004018054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156113c05780601f10611395576101008083540402835291602001916113c0565b820191906000526020600020905b8154815290600101906020018083116113a357829003601f168201915b505050505090806005018054600181600116156101000203166002900480601f01602080910402602001604051908101604052809291908181526020018280546001816001161561010002031660029004801561145e5780601f106114335761010080835404028352916020019161145e565b820191906000526020600020905b81548152906001019060200180831161144157829003601f168201915b505050505090806006018054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156114fc5780601f106114d1576101008083540402835291602001916114fc565b820191906000526020600020905b8154815290600101906020018083116114df57829003601f168201915b5050505050905087565b6060806060806060806060600d600001600d600101600d600201600d600301600d600401600d600501600d600601868054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156115c95780601f1061159e576101008083540402835291602001916115c9565b820191906000526020600020905b8154815290600101906020018083116115ac57829003601f168201915b50505050509650858054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156116655780601f1061163a57610100808354040283529160200191611665565b820191906000526020600020905b81548152906001019060200180831161164857829003601f168201915b50505050509550848054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156117015780601f106116d657610100808354040283529160200191611701565b820191906000526020600020905b8154815290600101906020018083116116e457829003601f168201915b50505050509450838054600181600116156101000203166002900480601f01602080910402602001604051908101604052809291908181526020018280546001816001161561010002031660029004801561179d5780601f106117725761010080835404028352916020019161179d565b820191906000526020600020905b81548152906001019060200180831161178057829003601f168201915b50505050509350828054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156118395780601f1061180e57610100808354040283529160200191611839565b820191906000526020600020905b81548152906001019060200180831161181c57829003601f168201915b50505050509250818054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156118d55780601f106118aa576101008083540402835291602001916118d5565b820191906000526020600020905b8154815290600101906020018083116118b857829003601f168201915b50505050509150808054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156119715780601f1061194657610100808354040283529160200191611971565b820191906000526020600020905b81548152906001019060200180831161195457829003601f168201915b50505050509050965096509650965096509650965090919293949596565b60058054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015611a255780601f106119fa57610100808354040283529160200191611a25565b820191906000526020600020905b815481529060010190602001808311611a0857829003601f168201915b505050505081565b60098054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015611ac35780601f10611a9857610100808354040283529160200191611ac3565b820191906000526020600020905b815481529060010190602001808311611aa657829003601f168201915b505050505081565b600b8054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015611b615780601f10611b3657610100808354040283529160200191611b61565b820191906000526020600020905b815481529060010190602001808311611b4457829003601f168201915b505050505081565b60088054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015611bff5780601f10611bd457610100808354040283529160200191611bff565b820191906000526020600020905b815481529060010190602001808311611be257829003601f168201915b505050505081565b60028054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015611c9d5780601f10611c7257610100808354040283529160200191611c9d565b820191906000526020600020905b815481529060010190602001808311611c8057829003601f168201915b505050505081565b600a8054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015611d3b5780601f10611d1057610100808354040283529160200191611d3b565b820191906000526020600020905b815481529060010190602001808311611d1e57829003601f168201915b505050505081565b60068054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015611dd95780601f10611dae57610100808354040283529160200191611dd9565b820191906000526020600020905b815481529060010190602001808311611dbc57829003601f168201915b505050505081565b611de96120f0565b878160000181905250868160200181905250858160400181905250848160600181905250838160800181905250828160a00181905250818160c0018190525080600d6000820151816000019080519060200190611e4792919061212e565b506020820151816001019080519060200190611e6492919061212e565b506040820151816002019080519060200190611e8192919061212e565b506060820151816003019080519060200190611e9e92919061212e565b506080820151816004019080519060200190611ebb92919061212e565b5060a0820151816005019080519060200190611ed892919061212e565b5060c0820151816006019080519060200190611ef592919061212e565b509050505050505050505050565b600460009054906101000a900460ff1681565b60018054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015611fac5780601f10611f8157610100808354040283529160200191611fac565b820191906000526020600020905b815481529060010190602001808311611f8f57829003601f168201915b505050505081565b60078054600181600116156101000203166002900480601f01602080910402602001604051908101604052809291908181526020018280546001816001161561010002031660029004801561204a5780601f1061201f5761010080835404028352916020019161204a565b820191906000526020600020905b81548152906001019060200180831161202d57829003601f168201915b505050505081565b600c8054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156120e85780601f106120bd576101008083540402835291602001916120e8565b820191906000526020600020905b8154815290600101906020018083116120cb57829003601f168201915b505050505081565b60e060405190810160405280606081526020016060815260200160608152602001606081526020016060815260200160608152602001606081525090565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f1061216f57805160ff191683800117855561219d565b8280016001018555821561219d579182015b8281111561219c578251825591602001919060010190612181565b5b5090506121aa91906121ae565b5090565b6121d091905b808211156121cc5760008160009055506001016121b4565b5090565b905600a165627a7a723058200026b3ed1df20c9f2ba189e2e6535b6a7394b03674c5f3775bf3287dd09746490029";
        //          }
        //      }
        #endregion

        #region Sample Contracts
        //      public static String Sample1ABI
        //      {
        //          get
        //          {
        //              return @" [
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'my_p1',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'uint256'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'inputs': [
        //      {
        //        'name': 'p1',
        //        'type': 'uint256'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'nonpayable',
        //    'type': 'constructor'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'getParam',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'uint256'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  }
        //]";
        //          }
        //      }
        //      public static String Sample2ABI
        //      {
        //          get
        //          {
        //              return @" [
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'my_p1',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'uint256'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'my_address',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'address'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'inputs': [
        //      {
        //        'name': 'p1',
        //        'type': 'uint256'
        //      },
        //      {
        //        'name': 'addr',
        //        'type': 'address'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'nonpayable',
        //    'type': 'constructor'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'getParam',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'uint256'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'getAddress',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'address'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  }
        //]";
        //          }
        //      }
        //      public static String Sample3ABI
        //      {
        //          get
        //          {
        //              return @" [
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'my_string',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'bytes32'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'my_p1',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'uint256'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'my_address',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'address'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'inputs': [
        //      {
        //        'name': 'a_string',
        //        'type': 'bytes32'
        //      },
        //      {
        //        'name': 'p1',
        //        'type': 'uint256'
        //      },
        //      {
        //        'name': 'addr',
        //        'type': 'address'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'nonpayable',
        //    'type': 'constructor'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'getParam',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'uint256'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'getAddress',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'address'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  },
        //  {
        //    'constant': true,
        //    'inputs': [],
        //    'name': 'getstring',
        //    'outputs': [
        //      {
        //        'name': '',
        //        'type': 'bytes32'
        //      }
        //    ],
        //    'payable': false,
        //    'stateMutability': 'view',
        //    'type': 'function'
        //  }
        //]";
        //          }
        //      }

        //      public static String Sample1ByteCode
        //      {
        //          get
        //          {
        //              return @"0x608060405234801561001057600080fd5b5060405160208061012283398101806040528101908080519060200190929190505050806000819055505060d9806100496000396000f3006080604052600436106049576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff1680632a2465fc14604e5780639b97c6fc146076575b600080fd5b348015605957600080fd5b506060609e565b6040518082815260200191505060405180910390f35b348015608157600080fd5b50608860a7565b6040518082815260200191505060405180910390f35b60008054905090565b600054815600a165627a7a7230582067f3bef2f197229ba14f292f0be481bd5c99119dfcd597590b3373835d9f8b640029";
        //          }
        //      }
        //      public static String Sample2ByteCode
        //      {
        //          get
        //          {
        //              return @"0x608060405234801561001057600080fd5b5060405160408061028c83398101806040528101908080519060200190929190805190602001909291905050508160008190555080600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555050506101f6806100966000396000f300608060405260043610610062576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff1680632a2465fc1461006757806338cc4831146100925780639b97c6fc146100e9578063b71d2cec14610114575b600080fd5b34801561007357600080fd5b5061007c61016b565b6040518082815260200191505060405180910390f35b34801561009e57600080fd5b506100a7610174565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156100f557600080fd5b506100fe61019e565b6040518082815260200191505060405180910390f35b34801561012057600080fd5b506101296101a4565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b60008054905090565b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16905090565b60005481565b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16815600a165627a7a72305820650275dbe5646d5999380c2d07f25c60151be640caa619d286ffa78b797ab4f90029";
        //          }
        //      }
        //      public static String Sample3ByteCode
        //      {
        //          get
        //          {
        //              return @"0x608060405234801561001057600080fd5b5060405160608061032e8339810180604052810190808051906020019092919080519060200190929190805190602001909291905050508160008190555080600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055508260028160001916905550505050610282806100ac6000396000f300608060405260043610610078576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff1680632a2465fc1461007d57806338cc4831146100a85780634f61d2d4146100ff5780639b97c6fc14610132578063b71d2cec1461015d578063e2f5cc0d146101b4575b600080fd5b34801561008957600080fd5b506100926101e7565b6040518082815260200191505060405180910390f35b3480156100b457600080fd5b506100bd6101f0565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561010b57600080fd5b5061011461021a565b60405180826000191660001916815260200191505060405180910390f35b34801561013e57600080fd5b50610147610220565b6040518082815260200191505060405180910390f35b34801561016957600080fd5b50610172610226565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156101c057600080fd5b506101c961024c565b60405180826000191660001916815260200191505060405180910390f35b60008054905090565b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16905090565b60025481565b60005481565b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60006002549050905600a165627a7a7230582034ecedd900fc39b9e2253749432543ec63964f133ba2f2e122af166c464763600029";
        //          }
        //      }

        #endregion
    }
}
