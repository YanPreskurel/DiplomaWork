using FinLit.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinLit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() => View();
        public IActionResult Hello()
        {
            return PartialView();
        }
        public IActionResult About() => View();

        public IActionResult Privacy() => View();

        //public string Index(string name)
        //{
        //    return $"Your name : {name}";
        //}

        //public IActionResult Index()
        //{
        //    var jsonOptions = new System.Text.Json.JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true, // не учитываем регистр
        //        WriteIndented = true                // отступы для красоты
        //    };

        //    return new HtmlResult("<h2>Hello Yanchik)</h2>");
        //}

        //public IActionResult GetFile()
        //{
        //    // Путь к файлу
        //    string file_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/File.txt");
        //    // Тип файла - content-type
        //    string file_type = "text/plain";
        //    // Имя файла - необязательно
        //    string file_name = "File.txt";
        //    return PhysicalFile(file_path, file_type, file_name);
        //}

        //public IActionResult Index()
        //{
        //    return RedirectToAction("About", "Home", new { name = "Tom", age = 37 });
        //}
        //public IActionResult About(string name, int age) => Content($"Name:{name}  Age: {age}");


        //public IActionResult Index()
        //{
        //    return RedirectToRoute("default", new { controller = "Home", action = "About", name = "Tom", age = 22 });
        //}
        //public IActionResult About(string name, int age) => Content($"Name:{name}  Age: {age}");


        ////[HttpGet]
        //public async Task Index()
        //{
        //    string content = @"<form method='post'>
        //        <label>Name:</label><br />
        //        <input name='name' /><br />
        //        <label>Age:</label><br />
        //        <input type='number' name='age' /><br />
        //        <input type='submit' value='Send' />
        //    </form>";
        //    Response.ContentType = "text/html;charset=utf-8";
        //    await Response.WriteAsync(content);
        //}
        //[HttpPost]
        //public string Index(string name, int age) => $"{name}: {age}";


        //public async Task Index()
        //{
        //    string content = @"<form method='post' action='/Home/PersonData'>
        //           <label>Name:</label><br />
        //        <input name='name' /><br />
        //        <label>Age:</label><br />
        //        <input type='number' name='age' /><br />
        //        <input type='submit' value='Send' />
        //    </form>";
        //    Response.ContentType = "text/html;charset=utf-8";
        //    await Response.WriteAsync(content);
        //}
        //[HttpPost]
        //public string PersonData()
        //{
        //    string? name = Request.Form["name"];
        //    string? age = Request.Form["age"];
        //    return $"{name}: {age}";
        //}



        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
