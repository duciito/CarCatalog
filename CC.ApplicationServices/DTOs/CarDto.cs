using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.ApplicationServices.DTOs
{
    public class CarDto : BaseDto, IValidate
    {
        public string Model { get; set; }
        public string ReleaseYear { get; set; }

        public int HorsePower { get; set; }
        public int MakeId { get; set; }
        public int TypeId { get; set; }

        public bool Validate()
        {
            return !String.IsNullOrEmpty(Model) && !String.IsNullOrEmpty(ReleaseYear);
        }
    }
}
