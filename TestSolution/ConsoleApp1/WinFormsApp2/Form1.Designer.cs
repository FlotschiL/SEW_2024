namespace WinFormsApp2;

sealed partial class Form1
{
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
    ListBox lb = new ListBox();
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Freundesliste";
        this.BackColor = Color.FromArgb(0, 7, 45);

        lb.Name = "lbFriends";
        lb.Left = 50;
        lb.Top = 50;
        lb.Width = 200;
        lb.Height = 350;
        this.Controls.Add(lb);
        
        Button saveButton = new Button();
        saveButton.Top = _infoMarginCounter;
        saveButton.Left = 350;
        saveButton.BackColor = _buttonColor;
        saveButton.Height = 50;
        saveButton.Width = 200;
        saveButton.Text = "save";
        saveButton.Click += SaveFriend;
        this.Controls.Add(saveButton);
        
        Button showButton = new Button();
        showButton.Top = 400;
        showButton.Left = 50;
        showButton.BackColor = _buttonColor;
        showButton.Height = 50;
        showButton.Width = 100;
        showButton.Text = "show";
        showButton.Click += DisplayFriend;
        this.Controls.Add(showButton);
        string[] infos = new string[] {"Name", "Surname", "Birthday", "Birthplace", "Hobby"};
        foreach (string info in infos)
        {
            CreatePersonalInfoBox(info);
        }
    }

    #endregion
}