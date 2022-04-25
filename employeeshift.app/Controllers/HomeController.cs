using Core.Dtos.EmployeeShifts;
using employeeshift.app.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace employeeshift.app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? id)
        {

            //var u = "https://localhost:44359/api/employeeshift";

            //using var client = new HttpClient();

            //var builder = new UriBuilder(u);
            //if (id != null)
            //    builder.Query = $"id={id}";
            //var url = builder.ToString();

            //var res = await client.GetAsync(url);

            //var content = await res.Content.ReadAsStringAsync();
            //var result = JsonConvert.DeserializeObject<List<EmployeeShiftDto>>(content);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}