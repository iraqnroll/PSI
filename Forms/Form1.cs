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

        private void btnAddOCR_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ReceiptDialog = new OpenFileDialog())
            {
                ReceiptDialog.Filter = "Image Files (*.TIFF;*.JPG;*.PNG)|*.TIFF;*.JPG;*.PNG|All files (*.*)|*.*";
                ReceiptDialog.FilterIndex = 2;
                ReceiptDialog.RestoreDirectory = true;

                if(ReceiptDialog.ShowDialog() == DialogResult.OK)
                {
                    NewReceipt newReceiptForm = new NewReceipt();
                    newReceiptForm.ReceiptFilePath = ReceiptDialog.FileName;
                    newReceiptForm.OCR = true;
                    newReceiptForm.Show();
                }
            }
        }
        private void btnAddManually_Click(object sender, EventArgs e)
        {
            NewReceipt newReceiptForm = new NewReceipt();
            newReceiptForm.OCR = false;
            newReceiptForm.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string SQLiteEx = null;
            DbHelper DbHelper = new DbHelper();
            if(DbHelper.ValidateDB())
            {
                if (DbHelper.ConnectToDB(connection, SQLiteEx))
                {
                    stripStatus.Text = "Connection to the database sucessful.";
                    DbHelper.PopulateDataGrid(receiptListGridView, connection, "SELECT receiptid, receiptdate, shopname FROM Receipts");
                }
                else
                {
                    stripStatus.Text = "Failed to connect to the database : " + SQLiteEx;
                }
            }
            else
            {
                stripStatus.Text = "Failed to locate the database, creating a new one.";
                if(DbHelper.CreateDB(connection, SQLiteEx))
                {
                    stripStatus.Text = "Connection to the database sucessful.";
                }
                else
                {
                    stripStatus.Text = "Failed to create a new database: " + SQLiteEx;
                }
            }

        }
    }
}
