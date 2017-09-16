using Microsoft.AspNetCore.Mvc;

namespace a2toh.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return View("/wwwroot/index.html");

            return File("index.html", "text/html");
        }
    }
}
