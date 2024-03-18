using Microsoft.AspNetCore.Mvc;

namespace WebEnergyAnalytics.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
