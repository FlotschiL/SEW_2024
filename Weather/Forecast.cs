using MySql.Data.MySqlClient;

namespace WeatherNameSpace;

public class ForecastManager
{
    private MySqlConnection _connection = new("server=localhost;user=root;password=sew;port=3306;database=weather;");
    private List<Forecast> entries { get; set; } = new();
    private ForecastManager _forecastManager = new();

    public Forecast this[int index] => entries[index];

    public ForecastManager()
    {
        _connection.Open();
        using var command = new MySqlCommand("SELECT * FROM forecast", _connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int value1 = reader.GetInt32(0);
            string value2 = reader.GetString(1);
            entries.Add(new Forecast(value1, value2));
        }
    }
}

public class Forecast(int id, string val)
{
    public int id { get; set; }
    public string date { get; set; }
}