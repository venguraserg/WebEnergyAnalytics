using MySql.Data.MySqlClient;

namespace WebEnergyAnalytics.Services
{
    public class DBReader
    {
        const string connectionString = "server=82.97.255.90;port=3306;database=default_db;user=gen_user;password=l~}Q<2c_J|D8>S";


        public static Dictionary<DateTime, double> ReadValue(string valueName, string startQuery, string endQuery)
        {

            var retVal = new Dictionary<DateTime, double>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Открытие подключения
                    connection.Open();

                    // SQL-запрос для получения всех строк из таблицы
                    string query = $"SELECT date, value FROM `my_test_db` WHERE name = '{valueName}' AND date > '{startQuery}' AND date < '{endQuery}' ORDER BY date";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Выполнение SQL-запроса и получение результатов
                    MySqlDataReader reader = command.ExecuteReader();
                    // Вывод результатов запроса

                    while (reader.Read())
                    {
                        // Получение значений полей из текущей строки

                        DateTime date = reader.GetDateTime("date");
                        double value = reader.GetDouble("value");

                        retVal.Add(date, value);
                        // Вывод значений полей

                    }

                    reader.Close();
                }
                catch { }
                return retVal;
            }
        }

        public static List<string> ReadTitle()
        {
            var listTitle = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Открытие подключения
                    connection.Open();

                    // SQL-запрос для получения всех строк из таблицы
                    string query = $"SELECT name FROM `my_test_db` ORDER BY name";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Выполнение SQL-запроса и получение результатов
                    MySqlDataReader reader = command.ExecuteReader();
                    // Вывод результатов запроса

                    while (reader.Read())
                    {
                        // Получение значений полей из текущей строки
                        string title = reader.GetString("name");

                        listTitle.Add(title);
                        // Вывод значений полей
                    }

                    reader.Close();
                }
                catch { }
                var finishList = listTitle.Distinct().ToList();
                return finishList;
            }
        }
    }
}
