using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MvcClient.DTO;

namespace MvcClient.Models
{
    public class ActionHistoryViewModel
    {

        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        [Required]
        [Display(Name = "User")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Company")]
        public string AdditionalInformation { get; set; }
        [Required]
        [Display(Name = "Action Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Latitude")]
        public String Latitude { get; set; }
        [Required]
        [Display(Name = "Longitude")]
        public String Longitude { get; set; }
        [Required]
        [Display(Name = "Timestamp")]
        public String TimeStamp { get; set; }

        public ActionHistoryViewModel(DTO_Action dto_action, string user_name, string additionalInformation)
        {

            this.Description = dto_action.Description;
            this.Latitude = Convert.ToString(dto_action.Latitude / 1000000.00);
            this.Longitude = Convert.ToString(dto_action.Longitude / 1000000.00);
            this.TimeStamp = FromUnixTime(dto_action.Timestamp).ToLongDateString() + " " + FromUnixTime(dto_action.Timestamp).ToLongTimeString();
            this.UserName = user_name;
            this.AdditionalInformation = additionalInformation;

        }

        public static DateTime FromUnixTime(long unixTime)
        {
            return epoch.AddSeconds(unixTime);
        }



    }
}
