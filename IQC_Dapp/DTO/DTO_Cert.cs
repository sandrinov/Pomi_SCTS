using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace IQC_Dapp.DTO
{
    [FunctionOutput]
    public class DTO_Cert
    {
        [Parameter("bytes32", "issuedBy", 1)]
        [Display(Name = "Issued By")]
        public String IssuedBy { get; set; }

        [Parameter("bytes32", "issuedTo", 2)]
        [Display(Name = "Issued To")]
        public String IssuedTo { get; set; }

        [Parameter("bytes32", "issuingDate", 3)]
        [Display(Name = "Date of Issue")]
        public String IssuingDate { get; set; }

        [Parameter("bytes32", "certHash", 4)]
        [Display(Name = "Cert Hash")]
        public String CertHash { get; set; }
    }
}
