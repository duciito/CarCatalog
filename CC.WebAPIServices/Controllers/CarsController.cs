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
    public class CarsController : BaseController
    {

        private readonly CarService _service = null;

        public CarsController()
        {
            _service = new CarService();
        }
        // GET: api/Cars
        public IHttpActionResult Get()
        {
            return Json(_service.Get());
        }

        // GET: api/Cars/5
        public IHttpActionResult Get(int id)
        {
            return Json(_service.GetById(id));
        }

        // POST: api/Cars
        [HttpPost]
        public IHttpActionResult Save(CarDto carDto)
        {
            if (!carDto.Validate())
            {
                return Json(new ResponseMessage { Code = 500, Error = "Invalid data!" });
            }

            ResponseMessage response = new ResponseMessage();

            if (_service.Save(carDto))
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

        // DELETE: api/Cars/5
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