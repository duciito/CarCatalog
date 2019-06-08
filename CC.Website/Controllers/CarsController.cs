using CC.Website.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CC.Website.Controllers
{
    public class CarsController : BaseController<CarVM>
    {
        public CarsController() : base(new Uri("https://localhost/api/cars/"))
        {

        }
    }
}