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
    public class DbHelper   //Maybe change this to a static class ??
    {
        const string DBPath = ".\\TestDB.db";

        public bool ValidateDB()
        {
            if(File.Exists(DBPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SQLiteConnection ConnectToDB(string exception)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=.\\TestDB.db");
            try
            {
                connection.Open();
                return connection;
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }
        public SQLiteConnection CreateDB(string exception)
        {
            SQLiteConnection.CreateFile(DBPath);
            SQLiteConnection connection = new SQLiteConnection("Data Source ="+DBPath);
            try
            {
                connection.Open();
                string sqlQuery = "CREATE TABLE Receipts (receiptid INTEGER PRIMARY KEY, receiptdate TEXT, itemdata TEXT, shopname TEXT)";
                SQLiteCommand command = new SQLiteCommand(sqlQuery, connection);
                command.ExecuteNonQuery();
                return connection;
            }
            catch(SQLiteException ex)
            {
                exception = ex.Message;
                return null;
            }
        }

        public void InsertIntoDB(SQLiteConnection connection, string sqlQuery)
        {
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection);
            command.ExecuteNonQuery();
        }

        public void PopulateDataGrid(DataGridView gridView, SQLiteConnection connection, string sqlQuery)
        {
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection);
            using (SQLiteDataReader sqldatareader = command.ExecuteReader())
            {
                DataTable dt = new DataTable();
                dt.Load(sqldatareader);
                gridView.DataSource = dt;
            }
        }

    }
}
