using Microsoft.AspNetCore.Mvc;

namespace MellysUndergroundCuisine.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }
    }
}
