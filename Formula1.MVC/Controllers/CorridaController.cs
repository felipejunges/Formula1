using Microsoft.AspNetCore.Mvc;

namespace Formula1.MVC.Controllers
{
    public class CorridaController : Controller
    {
        public IActionResult Index()
        {
            return Content("Oi");
        }
    }
}