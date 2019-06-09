using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("MakeId")]
        public virtual CarMake CarMake { get; set; }

        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual CarType CarType { get; set; }
    }
}
