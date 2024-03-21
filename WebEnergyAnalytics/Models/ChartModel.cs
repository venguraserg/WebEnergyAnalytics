using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebEnergyAnalytics.Services;

namespace WebEnergyAnalytics.Models
{
    public class ChartModel : PageModel
    {
        public Dictionary<DateTime, double> Data { get; set; }
        public List<string> Title {  get; set; }
        public string? Name {  get; set; }

        [HttpGet]
        public void OnGet()
        {
            // Заполните массив данных
            Data = DBReader.ReadValue("T_obr_1", "2024-03-20 00:00:00", "2024-03-21 05:00:00");
            Title = DBReader.ReadTitle();
            MyAction(Name);
        }
        [HttpPost]
        public IActionResult MyAction(string data)
        {
            // Используйте значение параметра "data"
            return null;
        }
    }
}
