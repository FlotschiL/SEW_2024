namespace WeatherNameSpace;
using System.Collections;
using System.Globalization;
using MySql.Data.MySqlClient;



public class ForecastManager : IEnumerable<Forecast>
{
    private MySqlConnection _connection = new("server=localhost;user=root;password=sew;port=3306;database=weather;");
    public List<Forecast> entries { get; set; } = new();

    public Forecast this[int index] => entries[index];

    public int Debug = 0;
    public ForecastManager()
    {
        
    }

    public void Initialize()
    {
        _connection.Open();
        using var command = new MySqlCommand("SELECT * FROM forecasts", _connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            DateTime value1 = reader.GetDateTime(0);
            int value2 = reader.GetInt32(1);
            entries.Add(new Forecast(value1, value2.ToString()));
        }
        _connection.Close();
    }

    public void Delete(Forecast fc)
    {
        _connection.Open();
        using var command = new MySqlCommand("DELETE FROM forecasts WHERE date=@param", _connection);
        command.Parameters.AddWithValue("@param", fc.time.ToString("yyyy-MM-dd HH:mm:ss"));
        command.ExecuteNonQuery();
        _connection.Close();
        entries.Remove(fc);
    }

    public void Add(Forecast fc)
    {
        entries.Add(fc);
        _connection.Open();
        using var command = new MySqlCommand("INSERT INTO forecasts VALUES (@value1, @value2);", _connection);
        command.Parameters.AddWithValue("@value1", fc.time.ToString("yyyy-MM-dd HH:mm:ss"));
        command.Parameters.AddWithValue("@value2", Convert.ToInt32(fc.data[0]));

        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void Update(Forecast fc)
    {
        entries.Add(fc);
        _connection.Open();
        using var command = new MySqlCommand("UPDATE INTO forecasts VALUES (@value1, @value2);", _connection);
        command.Parameters.AddWithValue("@value1", fc.time.ToString("yyyy-MM-dd HH:mm:ss"));
        command.Parameters.AddWithValue("@value2", Convert.ToInt32(fc.data[0]));

        command.ExecuteNonQuery();
        _connection.Close();
    }
    public IEnumerator<Forecast> GetEnumerator()
    {
        return entries.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Forecast : IEnumerable<string>
{
    public DateTime time { get; set; }
    public List<string> data { get; set; } = new();

    public Forecast(DateTime time, params string[] par)
    {
        this.time = time;
        foreach (var item in par)
        {
            data.Add(item);
        }
    }
    public IEnumerator<string> GetEnumerator()
    {
        List<string> help = new();
        help.Add(time.ToString(CultureInfo.CurrentCulture));
        help.AddRange(data);
        return help.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}