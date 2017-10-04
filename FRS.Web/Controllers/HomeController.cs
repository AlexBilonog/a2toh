using Microsoft.AspNetCore.Mvc;

namespace FRS.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("/wwwroot/index.html");
        }
    }
}
