using Microsoft.AspNetCore.Mvc;
using WebEnergyAnalytics.Models;

namespace WebEnergyAnalytics.Controllers
{
    public class ChartController : Controller
    {
        string startDate = string.Empty;
        string endDate = string.Empty;
        string titleContr = string.Empty;
        public IActionResult Index()
        {
            var model = new ChartModel();
            model.OnGet(titleContr, startDate, endDate);
            return View(model);
        }

        [HttpPost]
        public IActionResult Show()
        {
            if (ModelState.IsValid)
            {
                startDate = Request.Form["startdate"];
                endDate = Request.Form["enddate"];
                titleContr = Request.Form["titleContr"];

                var model = new ChartModel();
                model.OnGet(titleContr, startDate, endDate);
                return View(model);
            }
            return View("Index");
        }
    }
}