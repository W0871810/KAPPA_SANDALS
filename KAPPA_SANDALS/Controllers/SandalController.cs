using Microsoft.AspNetCore.Mvc;

namespace KAPPA_SANDALS.Controllers
{
    public class SandalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
