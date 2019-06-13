using CC.Website.ViewModels;
using System;

namespace CC.Website.Controllers
{
    public class CarMakesController : BaseController<CarMakeVM>
    {
        public CarMakesController() : base(new Uri("http://localhost:53410/api/carmakes/"))
        {

        }
    }
}