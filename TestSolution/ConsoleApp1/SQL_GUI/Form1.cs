namespace SQL_GUI;
using MySql.Data.MySqlClient;

public partial class Form1 : Form
{
    string cs = @"server=localhost;userid=root;password=insy;database=miniis";
    private List<TextBox> _informationTb = new List<TextBox>();
    private string _currentFriend = "";
    public void OnLoad(object sender, EventArgs e)
    {
        using var con = new MySqlConnection(cs);
        con.Open();
        var sql = "select * from friends";
        var cmd = new MySqlCommand(sql, con);

        using MySqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            lbFriends.Items.Add(rdr.GetInt32(0) + " " + rdr.GetString(1) + " " + rdr.GetString(2));
        }
        con.Close();
        lbFriends.Click += SelectFriend;
    }
    public Form1()
    {
        InitializeComponent();
        this.Load += OnLoad;
    }

    public void SelectFriend(object sender, EventArgs e)
    {
        if ((sender as ListBox).SelectedItem != null)
        {
            _currentFriend = (string)(sender as ListBox).SelectedItem;
            _informationTb[0].Text = _currentFriend.Split(" ")[1];
            _informationTb[1].Text = _currentFriend.Split(" ")[2];
        }

    }
    public void SaveFriend(object sender, EventArgs e)
    {
        //_currentFriend.FirstName = _informationTb[0].Text;
        //_currentFriend.LastName = _informationTb[1].Text;
        using var con = new MySqlConnection(cs);
        con.Open();
        var sql = "insert into friends values (@param1, @param2)";

        foreach (string friend in lbFriends.Items)
        {
            var cmd = new MySqlCommand($"insert into friends values (0, 'test', 'tes2', '2023-10-28 19:30:35')", con);
            //cmd.Parameters.AddWithValue("@param1", friend.Split(" ")[0]);
            //cmd.Parameters.AddWithValue("@param2", friend.Split(" ")[1]);
            cmd.ExecuteNonQuery();
        }
        con.Close();
        lbFriends.Items.Clear();
        OnLoad(null, null);
    }
    public void CreateFriend(object sender, EventArgs e)
    {
        //f.Add(new Friend("changeme", "changeme", "changeme", DateTime.Now));
        //lbFriends.Items.Clear();
        //lbFriends.Items.AddRange(f.ToArray());
        //f.SaveToFile();
    }
    public void DeleteFriend(object sender, EventArgs e)
    {
        using var con = new MySqlConnection(cs);
        con.Open();
        var sql = "insert into friends values (@param1, @param2)";
        //f.Remove(_currentFriend);
        //lbFriends.Items.Clear();
        //lbFriends.Items.AddRange(f.ToArray());
        //f.SaveToFile();
    }

    public void OnTextChanged(object sender, EventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        if (textBox.Text == "")
        {
            lbFriends.Items.Clear();
        //    lbFriends.Items.AddRange(f.ToArray());
            return;
        }
        //List<Friend> matches = new List<Friend>();
        //foreach (Friend item in f)
        //{
        //    if (item.Hobbies.Contains(textBox.Text))
        //    {
        //        matches.Add(item);
        //    }
        //}
        //lbFriends.Items.Clear();
        //lbFriends.Items.AddRange(matches.ToArray());
    }
}