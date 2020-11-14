using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI.Common;
using MySql.Data.MySqlClient;

namespace PSIShoppingEngine.Classes
{
    public static class DbHelper  
    {
        public static MySqlConnection myConnection = new MySqlConnection("Data Source=eu-cdbr-west-03.cleardb.net;port=3306;username=b55b69df8855db;password=5b4f6d2d;convert zero datetime=True");

        public static bool ValidateDB()
        {
            if(File.Exists(".\\TestDB.db"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public static void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }

        public static void InsertIntoDB(string sqlQuery)
        {
            OpenConnection();

            MySqlCommand command = new MySqlCommand(sqlQuery, myConnection);
           
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public static DataTable PopulateDataGrid( string sqlQuery)
        {
            OpenConnection();

            MySqlCommand command = new MySqlCommand(sqlQuery, myConnection);
            using (MySqlDataReader sqldatareader = command.ExecuteReader())
            {
                DataTable myDataTable = new DataTable();
                myDataTable.Load(sqldatareader);
                CloseConnection();
                return myDataTable;
            }
        }

        public static List<String> SingleColumSelection(string sqlQuery, string name)
        {
            List<String> shopNames = new List<String>();
            OpenConnection();

            MySqlCommand command = new MySqlCommand(sqlQuery, myConnection);

            using (MySqlDataReader sqldatareader = command.ExecuteReader())
            {

                while (sqldatareader.Read())
                {
                    shopNames.Add(Convert.ToString(sqldatareader[name]));
                }

            }
            CloseConnection();
            return shopNames;
        }

        public static string SingleValueSelection(string sqlQuery, string name)
        {
            string result;
            OpenConnection();
            MySqlCommand command = new MySqlCommand(sqlQuery, myConnection);
            using (MySqlDataReader sqldatareader = command.ExecuteReader())
            {
               sqldatareader.Read();
                result = sqldatareader[name].ToString();
                   
            }

            CloseConnection();
            return result;

        }
        

    }
}
