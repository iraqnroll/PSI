using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSIShoppingEngine.Classes
{
    public class DbHelper   //Maybe change this to a static class ??
    {
        const string DBPath = ".\\PSIDB.sqlite";

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

        public bool ConnectToDB(SQLiteConnection connection, string exception)
        {
            connection = new SQLiteConnection("Data Source=.\\PSIDB.sqlite;Version=3;");
            try
            {
                connection.Open();
                return true;
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public bool CreateDB(SQLiteConnection connection, string exception)
        {
            SQLiteConnection.CreateFile(DBPath);
            connection = new SQLiteConnection("Data Source ="+DBPath+"; Version = 3;");
            try
            {
                connection.Open();
                string sqlQuery = "CREATE TABLE Receipts (receiptid INTEGER PRIMARY KEY, receiptdate TEXT, itemdata TEXT, shopname TEXT)";
                SQLiteCommand command = new SQLiteCommand(sqlQuery, connection);
                command.ExecuteNonQuery();
                //connection.Close();
                return true;
            }
            catch(SQLiteException ex)
            {
                exception = ex.Message;
                return false;
            }
        }

        public void PopulateDataGrid(DataGridView gridView, SQLiteConnection connection, string sqlQuery)
        {
            SQLiteCommand command = new SQLiteCommand(sqlQuery,connection);
            SQLiteDataReader sqldatareader = command.ExecuteReader();
            BindingSource bs = new BindingSource();
            bs.DataSource = sqldatareader;
            gridView.DataSource = bs;
        }

    }
}
