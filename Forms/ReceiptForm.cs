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
using Newtonsoft.Json;

namespace PSIShoppingEngine
{
    public partial class Form1 : Form
    {
      
        string SelectedReceiptID = "1";

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            selectedReceiptGridView.Hide();
            string SQLiteEx = null;
            
            if (DbHelper.ValidateDB())
            {
                
                if (DbHelper.myConnection != null)
                {
                    
                    DbHelper.PopulateDataGrid(receiptListGridView,  "SELECT receiptid, receiptdate, shopname FROM Receipts");

                    //VERY UGLY EW
                    receiptListGridView.Columns[0].HeaderText = "ID";
                    receiptListGridView.Columns[1].HeaderText = "Date";
                    receiptListGridView.Columns[2].HeaderText = "Shop";
                    receiptListGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    receiptListGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    receiptListGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
              
                if (DbHelper.myConnection != null)
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
                  
                    newReceiptForm.Show();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           
            if (DbHelper.myConnection != null)
            {
                DbHelper.PopulateDataGrid(receiptListGridView, "SELECT receiptid, receiptdate, shopname FROM Receipts");
                stripStatus.Text = "Refreshed the grid with stored receipts.";
            }
            else stripStatus.Text = "Could not establish a connection with a database.";
        }

        private void selectedRowsButton_Click(object sender, System.EventArgs e)
        {
            selectedReceiptGridView.Rows.Clear();
            
            foreach (DataGridViewRow row in receiptListGridView.SelectedRows)
            {
                SelectedReceiptID = row.Cells[0].Value.ToString();
            }
          
            string sqlQuery = "SELECT itemdata, shopname FROM Receipts WHERE receiptid = "+SelectedReceiptID;
            DbHelper.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sqlQuery, DbHelper.myConnection);
            string Items = (string)command.ExecuteScalar();

            List<Item> ItemList = JsonConvert.DeserializeObject<List<Item>>(Items);

            foreach (var item in ItemList)
            {
                selectedReceiptGridView.Rows.Add(item.ItemName, item.ItemPrice, item.Type);
            }
            selectedReceiptGridView.Show();
            DbHelper.CloseConnection();
        }
        
    }
}
