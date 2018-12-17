using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcClient.Models
{
    public class ProductViewModel
    {
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }
        [Required]
        [Display(Name = "Latitude Geolocation of creation (in decimal)")]
        // [RegularExpression(@"^([-+]?)([\d]{1,2})(((\.)(\d+)(,)))(\s*)(([-+]?)([\d]{1,3})((\.)(\d+))?)$", ErrorMessage = "Latitude non in valid format")]
        public String Latitude { get; set; }
        [Required]
        // [RegularExpression(@"^([-+]?)([\d]{1,2})(((\.)(\d+)(,)))(\s*)(([-+]?)([\d]{1,3})((\.)(\d+))?)$", ErrorMessage ="Longitude non in valid format")]
        [Display(Name = "Longitude Geolocation of creation (in decimal)")]
        public String Longitude { get; set; }
    }
}
