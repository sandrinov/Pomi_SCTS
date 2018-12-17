using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcClient.DTO
{
    [FunctionOutput]
    public class DTO_Action
    {
        [Parameter("address", "handler", 1)]
        [Display(Name = "Handler Address")]
        public string Handler { get; set; }

        [Parameter("bytes32", "description", 2)]
        [Display(Name = "Action Description")]
        public string Description { get; set; }

        [Parameter("uint256", "lon", 3)]
        [Display(Name = "Longitude")]
        public int Longitude { get; set; }

        [Parameter("uint256", "lat", 4)]
        [Display(Name = "Latitude")]
        public int Latitude { get; set; }

        [Parameter("uint", "timestamp", 5)]
        [Display(Name = "Timestamp")]
        public int Timestamp { get; set; }

        [Parameter("uint", "blockNumber", 6)]
        [Display(Name = "BlockNumber")]
        public int BlockNumber { get; set; }

    }
}
