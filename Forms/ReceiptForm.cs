using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSIShoppingEngine.Classes;
using PSIShoppingEngine.Forms;

namespace PSIShoppingEngine
{
    public partial class Form1 : Form
    {
        SQLiteConnection connection;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string SQLiteEx = null;
            DbHelper DbHelper = new DbHelper();
            if(DbHelper.ValidateDB())
            {
                connection = DbHelper.ConnectToDB(SQLiteEx);
                if(connection != null)
                {
                    DbHelper.PopulateDataGrid(receiptListGridView, connection,"SELECT receiptid, receiptdate, shopname FROM Receipts");
                    stripStatus.Text = "Populated the grid with stored receipts.";
                }
                else
                {
                    stripStatus.Text = SQLiteEx;
                }
            }
            else
            {
                stripStatus.Text = "Failed to locate the database, creating a new one.";
                connection = DbHelper.CreateDB(SQLiteEx);
                if(connection != null)
                {
                    stripStatus.Text = "New database created. Connection sucessful.";
                }
                else
                {
                    stripStatus.Text = SQLiteEx;
                }
            }

        }

        private void btnAddManually_Click_1(object sender, EventArgs e)
        {
            NewReceipt newReceiptForm = new NewReceipt();
            newReceiptForm.OCR = false;
            newReceiptForm.connection = connection;
            newReceiptForm.Show();
        }

        private void btnAddOCR_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ReceiptDialog = new OpenFileDialog())
            {
                ReceiptDialog.Filter = "Image Files (*.TIFF;*.JPG;*.PNG)|*.TIFF;*.JPG;*.PNG|All files (*.*)|*.*";
                ReceiptDialog.FilterIndex = 2;
                ReceiptDialog.RestoreDirectory = true;

                if (ReceiptDialog.ShowDialog() == DialogResult.OK)
                {
                    NewReceipt newReceiptForm = new NewReceipt();
                    newReceiptForm.ReceiptFilePath = ReceiptDialog.FileName;
                    newReceiptForm.OCR = true;
                    newReceiptForm.connection = connection;
                    newReceiptForm.Show();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DbHelper dbHelper = new DbHelper();
            if (connection != null)
            {
                dbHelper.PopulateDataGrid(receiptListGridView, connection, "SELECT receiptid, receiptdate, shopname FROM Receipts");
                stripStatus.Text = "Refreshed the grid with stored receipts.";
            }
            else stripStatus.Text = "Could not establish a connection with a database.";
        }
    }
}
