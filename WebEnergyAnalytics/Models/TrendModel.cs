using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.PortableExecutable;
using WebEnergyAnalytics.Controllers;

namespace WebEnergyAnalytics.Models
{
    public class TrendModel : PageModel

    {
        public Dictionary<DateTime, double> Data { get; set; }

        [HttpGet]
        public void OnGet(ChartController controller)
        {
            // Заполните массив данных
            Data = controller.GetData();
        }
    }
}
