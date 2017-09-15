using Microsoft.AspNetCore.Mvc;

namespace a2toh_WebAngularApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("/wwwroot/index.html");
        }
    }
}
