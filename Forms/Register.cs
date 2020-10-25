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
    public partial class Register : Form
    {
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string confirmUserPassword { get; set; }

        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
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

        private void Confirm_Password(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '\u25CF';
            confirmUserPassword = textBox3.Text;
        }

        private void Sign_Up_Button_Click(object sender, EventArgs e)
        {
            if (confirmUserPassword == string.Empty || userPassword == string.Empty || userName == string.Empty)
            {
                if (userPassword == confirmUserPassword)
                {
                    string sqlQuery = "SELECT * FROM users WHERE username = @userName";
                    SQLiteCommand command = new SQLiteCommand(sqlQuery, DbHelper.myConnection);
                    command.Parameters.Add(new SQLiteParameter("@username", userName));
                    SQLiteDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username already taken.");
                    }

                    else
                    {
                        dr.Close();
                        string sqlQuery1 = "INSERT INTO users(username,password) VALUES(@username,@password)";
                        SQLiteCommand command1 = new SQLiteCommand(sqlQuery1, DbHelper.myConnection);
                        command1.Parameters.AddWithValue("username", userName);
                        command1.Parameters.AddWithValue("password", userPassword);
                        command1.ExecuteNonQuery();      
                        MessageBox.Show("Account successfully created.");
                    }
                }

                else
                {
                    MessageBox.Show("Passwords do not match.");
                }
            }

            else
            {
                MessageBox.Show("Check your entries.");
            }
        }

        private void Sign_In_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

    }
}
