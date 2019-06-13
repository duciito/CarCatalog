using CC.ApplicationServices.DTOs;
using CC.ApplicationServices.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CC.WebAPIServices.Controllers
{
    public class CarsController : BaseController<CarService, CarDto>
    {
    }
}