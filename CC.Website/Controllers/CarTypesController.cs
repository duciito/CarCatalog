using CC.Website.ViewModels;
using System;

namespace CC.Website.Controllers
{
    public class CarTypesController : BaseController<CarTypeVM>
    {
        public CarTypesController() : base(new Uri("http://localhost:53410/api/cartypes/"))
        {

        }
         
    }
}
