using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebEnergyAnalytics.Controllers
{
    public class ChartController : Controller
    {
        private readonly IConfiguration _configuration;

        public ChartController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Получаем строку подключения из файла json
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
        public IActionResult Index()
        {
            var model = GetData();
            return View(model);
        }

        public class Data
        {
            public string Name { get;}
            public DateTime Date { get;}
            public double Value { get;}
        }

        private List<Data> GetData()
        {
            try
            {
                using (IDbConnection db = Connection)
                {
                    var result = db.Query<Data>("SELECT * FROM my_test_db WHERE name='T_obr_1'").ToList();

                    return result;
                }
            }
            catch { return null; }
        }
    }
}
