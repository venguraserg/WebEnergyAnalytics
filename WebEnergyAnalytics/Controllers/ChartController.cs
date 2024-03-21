using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using WebEnergyAnalytics.Models;

namespace WebEnergyAnalytics.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            var model = new ChartModel();
            model.OnGet();
            return View(model);
        }
    }
}