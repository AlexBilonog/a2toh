using Microsoft.AspNetCore.Mvc;

namespace a2toh.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return View("/wwwroot/index.html");
            //return File("index.html", "text/html");

            var content = System.IO.File.ReadAllText("wwwroot/index.html");
            content = content.Replace("href=\"/\"", $"href=\"{Request.PathBase}/\"");
            return Content(content, "text/html");
        }
    }
}
