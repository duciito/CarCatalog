using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Entities
{
    public class Car : BaseEntity
    {
        [Required]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Field must be between 1 and 200 characters!")]
        public string Model { get; set; }
        [Required]
        public string ReleaseYear { get; set; }

        public int HorsePower { get; set; }

        public int MakeId { get; set; }
        public CarMake CarMake { get; set; }

        public int TypeId { get; set; }
        public CarType CarType { get; set; }
    }
}
