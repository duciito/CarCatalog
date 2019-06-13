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
    public class CarsController : BaseController<CarVM>
    {
        public CarsController() : base(new Uri("http://localhost:53410/api/cars/"))
        {
        }

        // GET: CarTypes
        public override async Task<ActionResult> Index()
        {
            string accessToken = await GetAccessToken();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53410/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                HttpResponseMessage response = await client.GetAsync("cars/get");

                string jsonString = await response.Content.ReadAsStringAsync();
                List<CarVM> carsList = JsonConvert.DeserializeObject<List<CarVM>>(jsonString);

                foreach (CarVM car in carsList)
                {
                    response = await client.GetAsync("cartypes/getbyid/" + car.TypeId);
                    jsonString = await response.Content.ReadAsStringAsync();
                    car.TypeName = JsonConvert.DeserializeObject<CarTypeVM>(jsonString).Name;

                    response = await client.GetAsync("carmakes/getbyid/" + car.MakeId);
                    jsonString = await response.Content.ReadAsStringAsync();
                    car.MakeName = JsonConvert.DeserializeObject<CarMakeVM>(jsonString).Name;
                }

                return View(carsList);
            }
        }

        // GET: CarTypes/Details/5
        public override async Task<ActionResult> Details(int id)
        {
            string accessToken = await GetAccessToken();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53410/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                HttpResponseMessage response = await client.GetAsync("cars/getbyid/" + id);

                string jsonString = await response.Content.ReadAsStringAsync();
                CarVM carVM = JsonConvert.DeserializeObject<CarVM>(jsonString);

                response = await client.GetAsync("cartypes/getbyid/" + carVM.TypeId);
                jsonString = await response.Content.ReadAsStringAsync();
                carVM.TypeName = JsonConvert.DeserializeObject<CarTypeVM>(jsonString).Name;

                response = await client.GetAsync("carmakes/getbyid/" + carVM.MakeId);
                jsonString = await response.Content.ReadAsStringAsync();
                carVM.MakeName = JsonConvert.DeserializeObject<CarMakeVM>(jsonString).Name;
                return View(carVM);
            }
        }

        // GET: CarTypes/Create
        public override async Task<ActionResult> Create()
        {
            CarVM carVM = new CarVM();
            string accessToken = await GetAccessToken();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53410/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

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

        // GET: CarTypes/Edit/5
        public override async Task<ActionResult> Edit(int id)
        {

            string accessToken = await GetAccessToken();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53410/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                HttpResponseMessage response = await client.GetAsync("cars/getbyid/" + id);

                // parse the response and return the data.
                string jsonString = await response.Content.ReadAsStringAsync();
                CarVM carVM = JsonConvert.DeserializeObject<CarVM>(jsonString);

                response = await client.GetAsync("cartypes/get");
                jsonString = await response.Content.ReadAsStringAsync();
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

                return View(carVM);
            }
        }
    }
}