using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.ApplicationServices.DTOs
{
    public class CarTypeDto : BaseDto, IValidate
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool Validate()
        {
            return !String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Description);
        }
    }
}
