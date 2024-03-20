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
        public static void OnGet()
        {
            // Заполните массив данных
            Data = ChartController.GetData();
        }
    }
}
