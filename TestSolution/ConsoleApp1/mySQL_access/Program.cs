using MySql.Data.MySqlClient;
using System;
using Org.BouncyCastle.Asn1.Cms;

string cs = @"server=localhost;userid=root;password=insy;database=miniis";

using var con = new MySqlConnection(cs);
con.Open();
Console.WriteLine($"MySQL version: {con.ServerVersion}");

var sql = "select * from friends";
var cmd = new MySqlCommand(sql, con);

using MySqlDataReader rdr = cmd.ExecuteReader();
while (rdr.Read())
{
    Console.WriteLine("{0} {1} {2} {3}", rdr.GetInt32(0), rdr.GetString(1) , rdr.GetString(2), rdr.GetValue(3));
}