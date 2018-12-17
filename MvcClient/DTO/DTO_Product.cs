using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClient.DTO
{
    [FunctionOutput]
    public class DTO_Product
    {
        [ScaffoldColumn(false)]
        public int Index { get; set; }

        [Parameter("bytes32", "name", 1)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Parameter("bytes32", "additionalInformation", 2)]
        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [Parameter("bool", "isConsumed", 3)]
        [Display(Name = "Is Consumed")]
        public bool IsConsumed { get; set; }
    }
}
