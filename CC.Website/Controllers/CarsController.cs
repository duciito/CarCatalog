using CC.Website.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CC.Website.Controllers
{
    public class CarsController : Controller
    {
        private readonly Uri url = new Uri("http://localhost:49610/api/cars/");
        // GET: CarTypes
        public async Task<ActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("get");

                string jsonString = await response.Content.ReadAsStringAsync();
                List<CarVM> viewModel = JsonConvert.DeserializeObject<List<CarVM>>(jsonString);
                return View(viewModel);
            }
        }

        // GET: CarTypes/Details/5
        public async Task<ActionResult> Details(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("getbyid/" + id);

                string jsonString = await response.Content.ReadAsStringAsync();
                CarVM viewModel = JsonConvert.DeserializeObject<CarVM>(jsonString);
                return View(viewModel);
            }
        }

        // GET: CarTypes/Create
        public async Task<ActionResult> Create()
        {
            CarVM carVM = new CarVM();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49610/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("cartypes/get");

                string jsonString = await response.Content.ReadAsStringAsync();
                List<CarTypeVM> carTypes = JsonConvert.DeserializeObject<List<CarTypeVM>>(jsonString);
                carVM.CarTypes = new SelectList(
                    carTypes,
                    "Id",
                    "Name"
                );

                response = await client.GetAsync("carmakes/get");
                jsonString = await response.Content.ReadAsStringAsync();

                List<CarMakeVM> carMakes = JsonConvert.DeserializeObject<List<CarMakeVM>>(jsonString);
                carVM.CarMakes = new SelectList(
                    carMakes,
                    "Id",
                    "Name"
                );
            }
            return View(carVM);
        }

        // POST: CarTypes/Create
        [HttpPost]
        public async Task<ActionResult> Create(CarVM viewModel)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = url;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = JsonConvert.SerializeObject(viewModel);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // make the request
                    HttpResponseMessage response = await client.PostAsync("save", byteContent);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }

        // GET: CarTypes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // make the request
                HttpResponseMessage response = await client.GetAsync("getbyid/" + id);

                // parse the response and return the data.
                string jsonString = await response.Content.ReadAsStringAsync();
                var viewModel = JsonConvert.DeserializeObject<CarVM>(jsonString);
                return View(viewModel);
            }
        }

        // POST: CarTypes/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(CarVM viewModel)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = url;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = JsonConvert.SerializeObject(viewModel);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // make the request
                    HttpResponseMessage response = await client.PostAsync("save", byteContent);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }

        // POST: CarTypes/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = url;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // make the request
                    HttpResponseMessage response = await client.DeleteAsync("delete/" + id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpNotFoundResult("This item doesn't exist!");
            }
        }
    }
}