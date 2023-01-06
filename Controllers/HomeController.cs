using AjaxDotNetCoreExample.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AjaxDotNetCoreExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var people = new List<Person>
            {
                new Person() { Id = 1, Name = "Alex", Age = 30 },
                new Person() { Id = 2, Name = "John", Age = 40 },
                new Person() { Id = 3, Name = "Luke", Age = 50 },
            };
            return View(people);
        }

        [HttpPost]
        public JsonResult AjaxPostSimpleDataType(string name, int age)
        {
            var person = new Person() { Name = name, Age = age };
            var jsonResponseVm = new JsonResponseViewModel()
            {
                ResponseCode = 0,
                ResponseMessage = 
                    "Meesage from <strong>AjaxPostSimpleDataType()</strong>: " +
                    JsonConvert.SerializeObject(person)
            };
            return Json(jsonResponseVm);
        }

        [HttpPost]
        public JsonResult AjaxPostObject([FromBody] Person person)
        {
            var jsonResponseVm = new JsonResponseViewModel()
            {
                ResponseCode = 0,
                ResponseMessage = 
                    "Meesage from <strong>AjaxPostObject():</strong>: " +
                    JsonConvert.SerializeObject(person)
            };
            return Json(jsonResponseVm);
        }

        [HttpPost]
        public JsonResult AjaxPostCollection([FromBody] IEnumerable<Person> people)
        {
            var jsonResponseVm = new JsonResponseViewModel()
            {
                ResponseCode = 0,
                ResponseMessage = 
                    "Meesage from <strong>AjaxPostCollection()</strong>: " +
                    JsonConvert.SerializeObject(people)
            };
            return Json(jsonResponseVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}