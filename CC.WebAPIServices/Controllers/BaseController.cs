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
    public abstract class BaseController<TService, TDto> : ApiController
        where TService : IService<TDto>, new()
        where TDto : BaseDto, IValidate, new()
    {

        private readonly TService _service = default(TService);

        public BaseController()
        {
            _service = new TService();
        }
        // GET: api/Cars
        public IHttpActionResult Get()
        {
            return Json(_service.Get());
        }

        // GET: api/Cars/5
        public IHttpActionResult GetById(int id)
        {
            return Json(_service.GetById(id));
        }

        // POST: api/Cars
        [HttpPost]
        public IHttpActionResult Save(TDto dto)
        {
            if (!dto.Validate())
            {
                return Json(new ResponseMessage { Code = 500, Error = "Invalid data!" });
            }

            ResponseMessage response = new ResponseMessage();

            if (_service.Save(dto))
            {
                response.Code = 200;
                response.Body = "Item saved!";
            }
            else
            {
                response.Code = 500;
                response.Body = "Item wasn't saved!";
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
                response.Body = "Item deleted!";
            }
            else
            {
                response.Code = 500;
                response.Body = "Item wasn't deleted!";
            }

            return Json(response);
        }

        [HttpGet]
        public IHttpActionResult Index()
        {
            return Json("Web API version 2.0");
        }
    }
}
