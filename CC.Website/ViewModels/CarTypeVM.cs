using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CC.Website.ViewModels
{
    public class CarTypeVM : BaseVM
    {
        [Required(ErrorMessage = "Field is required!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Field must be between 1 and 100 characters!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field is required!")]
        [StringLength(400, MinimumLength = 1, ErrorMessage = "Field must be between 1 and 400 characters!")]
        public string Description { get; set; }
    }
}