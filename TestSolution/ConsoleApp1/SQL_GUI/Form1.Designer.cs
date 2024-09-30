namespace SQL_GUI;

partial class Form1
{
    
    ListBox lbFriends = new ListBox();
    private int _infoMarginCounter;
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Freundesliste";

        lbFriends.Name = "lbFriends";
        lbFriends.Left = 50;
        lbFriends.Top = 50;
        lbFriends.Width = 200;
        lbFriends.Height = 200;
        this.Controls.Add(lbFriends);

        TextBox searchBox = new TextBox();
        searchBox.Left = 50;
        searchBox.Top = 25;
        searchBox.Width = 200;
        searchBox.Height = 20;
        searchBox.TextChanged += OnTextChanged;
        Controls.Add(searchBox);
        
        
        string[] infos = new string[] {"Name", "Surname", "Hobby", "Birthday"};
        foreach (string info in infos)
        {
            CreatePersonalInfoBox(info);
        }
        CreateButton("save",350, _infoMarginCounter+=50, SaveFriend);
        CreateButton("create",350, _infoMarginCounter+=50, CreateFriend);
        CreateButton("delete",350, _infoMarginCounter+=50, DeleteFriend);
    }

    private void CreateButton(string text, int Left, int Top, EventHandler method, int Width = 200, int Height = 35)
    {
        Button SaveButton = new Button();
        SaveButton.Left = Left;
        SaveButton.Top = Top;
        SaveButton.Height = Height;
        SaveButton.Width = Width;
        SaveButton.Text = text;
        SaveButton.Click += method;
        Controls.Add(SaveButton);
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
        this.Controls.Add(label);
        _infoMarginCounter += 50;
        _informationTb.Add(tb);
    }

    
    
    
    
    
    
    
    
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


   

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    

    #endregion
}