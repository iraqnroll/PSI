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
using MySql.Data.MySqlClient;

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
            string sqlQuery = "USE heroku_1144b6fe5f570ba; SELECT * FROM users WHERE username = @userName AND password = @password";
            MySqlCommand command = new MySqlCommand(sqlQuery, DbHelper.myConnection);
            command.Parameters.Add(new MySqlParameter("@username", userName));
            command.Parameters.Add(new MySqlParameter("@password", userPassword));
            MySqlDataReader dr = command.ExecuteReader();

            if (dr.HasRows)
            {
                this.Hide();
                dr.Close();
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
