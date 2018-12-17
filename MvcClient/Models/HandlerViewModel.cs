using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MvcClient.DTO;

namespace MvcClient.Models
{
    public class HandlerViewModel
    {
        private DTO_Handler dto_handler;

        public HandlerViewModel()
        {

        }

        public HandlerViewModel(DTO_Handler dto_handler, string handlerAddress)
        {
            this.HandlerName = dto_handler.HandlerName;
            this.AdditionalInformation = dto_handler.AdditionalInformation;
            this.HandlerAddress = dto_handler.AdditionalInformation;

        }

        [Required]
        [Display(Name = "Handler Ethereum Address")]
        [RegularExpression("^0x[a-fA-F0-9]{40}$", ErrorMessage = "Insert a correct Ethereum Address")]
        public string HandlerAddress { get; set; }
        [Required]
        [Display(Name = "Handler Name")]
        public string HandlerName { get; set; }
        [Required]
        [Display(Name = "Additional Informations (Company Name)")]
        public string AdditionalInformation { get; set; }
    }
}
