using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CC.Website.ViewModels
{
    public class CarVM : BaseVM
    {
        [Required(ErrorMessage = "Field is required!")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Field must be between 1 and 200 characters!")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Field is required!")]
        public string ReleaseYear { get; set; }

        public int HorsePower { get; set; }

        public int MakeId { get; set; }
        public CarMakeVM CarMake { get; set; }

        public int TypeId { get; set; }
        public CarTypeVM CarType { get; set; }
    }
}