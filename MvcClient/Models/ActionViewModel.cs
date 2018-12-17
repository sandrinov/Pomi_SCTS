using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcClient.Models
{
    public class ActionViewModel
    {
        [Required]
        [Display(Name = "Action Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Latitude Geolocation of creation (in decimal)")]
        // [RegularExpression(@"^([-+]?)([\d]{1,2})(((\.)(\d+)(,)))(\s*)(([-+]?)([\d]{1,3})((\.)(\d+))?)$", ErrorMessage = "Latitude non in valid format")]
        public String Latitude { get; set; }
        [Required]
        // [RegularExpression(@"^([-+]?)([\d]{1,2})(((\.)(\d+)(,)))(\s*)(([-+]?)([\d]{1,3})((\.)(\d+))?)$", ErrorMessage ="Longitude non in valid format")]
        [Display(Name = "Longitude Geolocation of creation (in decimal)")]
        public String Longitude { get; set; }
        [Required]
        [Display(Name = "End of Process")]
        public bool IsConsumed { get; set; }

    }
}
