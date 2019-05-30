using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Data.Entities
{
    public class CarType : BaseEntity
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Field must be between 1 and 100 characters!")]
        public string Name { get; set; }
        [Required]
        [StringLength(400, MinimumLength = 1, ErrorMessage = "Field must be between 1 and 400 characters!")]
        public string Description { get; set; }
    }
}
