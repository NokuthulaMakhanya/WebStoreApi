using ConsumeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeWebAPI.Controllers
{
    public class StoreController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7166/api");
        private readonly HttpClient _client;

        public StoreController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;   
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<StoreViewModel> storeList = new List<StoreViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Users/GetUsers").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                storeList = JsonConvert.DeserializeObject<List<StoreViewModel>>(data);
            }
            return View(storeList);
        }
    }
}
