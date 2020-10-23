using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSIShoppingEngine.Classes
{
    public static class DbHelper  
    {
        public static SQLiteConnection myConnection = new SQLiteConnection("Data Source=TestDB.db");

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

            SQLiteCommand command = new SQLiteCommand(sqlQuery, myConnection);
            command.ExecuteNonQuery();

            CloseConnection();
        }

        public static DataTable PopulateDataGrid( string sqlQuery)
        {
            OpenConnection();

            SQLiteCommand command = new SQLiteCommand(sqlQuery, myConnection);
            using (SQLiteDataReader sqldatareader = command.ExecuteReader())
            {
                DataTable myDataTable = new DataTable();
                myDataTable.Load(sqldatareader);
                CloseConnection();
                return myDataTable;
            }
        }

        public static List<String> SingleColumSelection(string query, string name)
        {
            List<String> shopNames = new List<String>();
            DbHelper.OpenConnection();

            using (SQLiteCommand command = DbHelper.myConnection.CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                SQLiteDataReader r = command.ExecuteReader();
                while (r.Read())
                {
                    shopNames.Add(Convert.ToString(r[name]));
                }
            }
            DbHelper.CloseConnection();
            return shopNames;
        }

    }
}
