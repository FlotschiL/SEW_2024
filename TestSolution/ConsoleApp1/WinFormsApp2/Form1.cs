using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace WinFormsApp2;
public partial class Form1 : Form
{
    private int _buttonMarginCounter = 25;
    private int _infoMarginCounter = 38;
    private Button _prevActiveButton = new Button();
    private readonly Color _buttonColor = Color.FromArgb(39,53,107);
    private readonly Color _buttonActiveColor = Color.FromArgb(62,146,204);
    private List<TextBox> _information = new List<TextBox>();
    private string _path = "C:\\Users\\MainUserFlo\\RiderProjects\\SEW_2024" +
                          "\\TestSolution\\ConsoleApp1\\WinFormsApp2\\friends.txt";

    private FriendsManager f;
    public Form1()
    {
        FriendsManager f = new FriendsManager();
        //OpenFileDialog ofd = new OpenFileDialog();
        //if(ofd.ShowDialog() == DialogResult.OK)
            f.GetFriendsFromFile(_path);//ofd.fileName
        lb.Items.AddRange(f.ToArray());
        foreach (Button item in lb.Controls.OfType<Button>().ToArray())
        {
            item.Click += DisplayFriend;
        }
        
        string[] infos = new string[] {"Name", "Surname", "Birthday", "Birthplace", "Hobby"};
        foreach (string info in infos)
        {
            CreatePersonalInfoBox(info);
        }
        InitializeComponent();
    }
    
    private void CreatePersonalInfoBox(string information)
    {
        TextBox tb = new TextBox();
        tb.Left = 350;
        tb.Top = _infoMarginCounter;
        tb.Height = 35;
        tb.Width = 200;
        this.Controls.Add(tb);
        Label label = new Label();
        label.Left = 250;
        label.Top = _infoMarginCounter;
        label.Height = 35;
        label.Text = information + ":";
        label.ForeColor=Color.GhostWhite;
        this.Controls.Add(label);
        _infoMarginCounter += 50;
        _information.Add(tb);
    }
    private void DisplayFriend(object? sender, EventArgs e)
    {
        Person friend = lb.SelectedItem as Person;
        PropertyInfo[] properties = friend.GetType().GetProperties();
        for (var index = 0; index < properties.Length; index++)
        {
            var property = properties[index];
            if (index == 2)
            {
                _information[index].Text = ((DateTime)(property.GetValue(friend) ?? throw new InvalidOperationException())).ToString("dd.MM.yyyy");
            }
            else
            {
                _information[index].Text = property.GetValue(friend)?.ToString();
            }
        }
    }
    private void SaveFriend(object? sender, EventArgs e)
    {
        Person friend = lb.SelectedItem as Person;
        PropertyInfo[] properties = friend.GetType().GetProperties();
        string line = "";
        for (var index = 0; index < properties.Length; index++)
        {
            var property = properties[index];
            line += _information[index] + ";";

            if (index == 2)
            {
                property.SetValue(friend, DateTime.ParseExact(
                    _information[index].Text, "dd.MM.yyyy", null));
            }
            else
            {
                property.SetValue(friend, _information[index].Text);
            }
        }
        StreamWriter sw = new StreamWriter(_path);
        sw.WriteLine(line);
    }
} 