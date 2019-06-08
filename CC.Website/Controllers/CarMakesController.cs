using CC.Website.ViewModels;
using System;

namespace CC.Website.Controllers
{
    public class CarMakesController : BaseController<CarMakeVM>
    {
        public CarMakesController() : base(new Uri("https://localhost/api/carmakes/"))
        {

        }
    }
}