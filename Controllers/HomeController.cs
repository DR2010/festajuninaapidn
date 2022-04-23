using Microsoft.AspNetCore.Mvc;

namespace fjapifestajuninadn.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
