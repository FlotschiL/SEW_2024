namespace FriendsLibSQL;
using MySql.Data.MySqlClient;
public class Database : List<Friend>
{
    private string _file;
    
    public void Load()
    {
        using var con = new MySqlConnection(_connStrg);
        con.Open();
        var sql = "select * from friends";
        var cmd = new MySqlCommand(sql, con);

        using MySqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            DateTime date = DateTime.Parse(rdr.GetValue(3).ToString());
            this.Add(new Friend(
                rdr.GetInt32(0) ,rdr.GetString(1), rdr.GetString(2), date));
        }
        con.Close();
    }

    public void SaveToFile()
    {
    }
}