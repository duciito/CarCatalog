using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CC.Website.ViewModels
{
    public class CarVM : BaseVM
    {
        [Required(ErrorMessage = "Field is required!")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Field must be between 1 and 200 characters!")]
        public string Model { get; set; }
        [DisplayName("Year")]
        [Required(ErrorMessage = "Field is required!")]
        public string ReleaseYear { get; set; }

        [DisplayName("Horse power")]
        public int HorsePower { get; set; }

        [DisplayName("Make")]
        public int MakeId { get; set; }
        [DisplayName("Type")]
        public int TypeId { get; set; }

        [DisplayName("Make")]
        public string MakeName { get; set; }
        [DisplayName("Type")]
        public string TypeName { get; set; }
        public SelectList CarTypes { get; set; }
        public SelectList CarMakes { get; set; }
    }
}