using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using WebEnergyAnalytics.Services;

namespace WebEnergyAnalytics.Models
{
    public class TrendModel : PageModel
    {
        public Dictionary<DateTime, double> Data { get; set; }
        public Dictionary<DateTime, double> Data2 { get; set; }

        [HttpGet]
        public void OnGet()
        {
            // Заполните массив данных
            Data = DBReader.ReadValue("T_obr_1", "2024-02-01 00:00:00", "2024-02-02 00:00:00");
            Data2 = DBReader.ReadValue("EvapPressurePV", "2024-02-01 00:00:00", "2024-02-02 00:00:00");

        }

    }
}
