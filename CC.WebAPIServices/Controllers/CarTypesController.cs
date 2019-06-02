using CC.ApplicationServices.DTOs;
using CC.ApplicationServices.Implementations;
using CC.WebAPIServices.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CC.WebAPIServices.Controllers
{
    public class CarTypesController : BaseController
    {
        private readonly CarTypeService _service = null;

        public CarTypesController()
        {
            _service = new CarTypeService();
        }

        public IHttpActionResult Get()
        {
            return Json(_service.Get());
        }

        public IHttpActionResult Get(int id)
        {
            return Json(_service.GetById(id));
        }

        [HttpPost]
        public IHttpActionResult Save(CarTypeDto carTypeDto)
        {
            if (!carTypeDto.Validate())
            {
                return Json(new ResponseMessage { Code = 500, Error = "Invalid data!" });
            }

            ResponseMessage response = new ResponseMessage();

            if (_service.Save(carTypeDto))
            {
                response.Code = 200;
                response.Body = "Car saved!";
            }
            else
            {
                response.Code = 500;
                response.Body = "Car wasn't saved!";
            }
            return Json(response);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (_service.Delete(id))
            {
                response.Code = 200;
                response.Body = "Car deleted!";
            }
            else
            {
                response.Code = 500;
                response.Body = "Car wasn't deleted!";
            }

            return Json(response);
        }
    }
}
