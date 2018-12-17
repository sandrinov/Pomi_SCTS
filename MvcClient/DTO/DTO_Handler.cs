using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcClient.DTO
{
    /// <summary>
    /// In SolidityContract
    /// 
    /// // @dev struct which represents a Handler for the products stored in the database.
    ///struct Handler
    /// {
    ///     // @dev indicates the name of a Handler.
    ///     string _name;
    ///    // @dev Additional information about the Handler, generally as a JSON object
    ///     string _additionalInformation;
    ///  }
    ///  
    /// </summary>
    /// 
    [FunctionOutput]
    public class DTO_Handler
    {
        [Parameter("string", "_name", 1)]
        [Display(Name = "Handler Name")]
        public String HandlerName { get; set; }
        [Parameter("string", "_additionalInformation", 2)]
        [Display(Name = "Additional Information")]
        public String AdditionalInformation { get; set; }
    }
}
