using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebEnergyAnalytics.Services;

namespace WebEnergyAnalytics.Models
{
    public class ChartModel : PageModel
    {
        public Dictionary<DateTime, double> Data { get; set; }
        public List<string> Title {  get; set; }
        public string TitleContr {  get; set; }
        public string StartDate {  get; set; }
        public string EndDate {  get; set; }

        [HttpGet]
        public void OnGet()
        {
            Title = DBReader.ReadTitle();
        }

        public void Post(string titleContr, string startDate, string endDate)
        {
            TitleContr = titleContr;
            StartDate = startDate;
            EndDate = endDate;
            // Заполните массив данных
            Data = DBReader.ReadValue(titleContr, startDate, endDate);
            Title = DBReader.ReadTitle();
        }
    }
}
