using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSIShoppingEngine.Classes;
using PSIShoppingEngine.Forms;
using System.Data.SQLite;

namespace PSIShoppingEngine.Forms
{
    public partial class Login : Form
    {
        public string userName { get; set; }
        public string userPassword { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)     //  starting point of the program, connecting to db
        {
            string SQLiteEx = null;

            if (DbHelper.ValidateDB())
            {
                DbHelper.OpenConnection();

                if (DbHelper.myConnection != null)
                {
                    statusStrip1.Text = "Connection sucessful.";
                }
                else
                {
                    statusStrip1.Text = SQLiteEx;
                }
            }

            else
            {
                statusStrip1.Text = "Failed to locate the database, creating a new one.";

                DbHelper.OpenConnection();

                if (DbHelper.myConnection != null)
                {
                    statusStrip1.Text = "New database created. Connection sucessful.";
                }
                else
                {
                    statusStrip1.Text = SQLiteEx;
                }
            }

        }

        private void Type_Username(object sender, EventArgs e)
        {
            userName = textBox1.Text;
        }

        private void Type_Password(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '\u25CF';
            userPassword = textBox2.Text;
        }

        private void Sign_In_Button_Click(object sender, EventArgs e)     //  login logic
        {
            string sqlQuery = "SELECT * FROM users WHERE username = @userName AND password = @password";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, DbHelper.myConnection);
            command.Parameters.Add(new SQLiteParameter("@username", userName));
            command.Parameters.Add(new SQLiteParameter("@password", userPassword));
            SQLiteDataReader dr = command.ExecuteReader();

            if (dr.HasRows == true)
            {
                this.Hide();
                MainMenuForm mainMenuForm = new MainMenuForm();
                mainMenuForm.ShowDialog();
                this.Close();
            }

            else
            {
                string message = "Check your entries.";
                string title = "Login Failed";
                MessageBox.Show(message,title);
            }
        }

        private void Sign_Up_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.ShowDialog();
        }
    }
}
