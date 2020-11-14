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
      

        public Form1()
        {
            InitializeComponent();
        }

        private string selectReceipts = @"USE heroku_1144b6fe5f570ba;	SELECT r.receipt_id, shop_name, date, ROUND( SUM(price),2)
                                            FROM receipts r
                                            JOIN shops USING(shop_id)
                                            JOIN norfa USING(receipt_id)
                                            GROUP BY r.receipt_id
                                        UNION

                                            SELECT r.receipt_id, shop_name, date, ROUND( SUM(price),2)
                                            FROM receipts r
                                            JOIN shops USING(shop_id)
                                            JOIN iki USING(receipt_id)
                                            GROUP BY r.receipt_id
                                        UNION

                                            SELECT r.receipt_id, shop_name, date, ROUND( SUM(price),2)
                                            FROM receipts r
                                            JOIN shops USING(shop_id)
                                            JOIN rimi USING(receipt_id)
                                            GROUP BY r.receipt_id
                                        UNION

                                            SELECT r.receipt_id, shop_name, date, ROUND( SUM(price),2)
                                            FROM receipts r
                                            JOIN shops USING(shop_id)
                                            JOIN lidl USING(receipt_id)
                                            GROUP BY r.receipt_id
                                        UNION

                                            SELECT r.receipt_id, shop_name, date, ROUND( SUM(price),2)
                                            FROM receipts r
                                            JOIN shops USING(shop_id)
                                            JOIN maxima USING(receipt_id)
                                            GROUP BY r.receipt_id
                                            ORDER BY receipt_id";


        private void Form1_Load(object sender, EventArgs e)
        {
            selectedReceiptGridView.Hide();
            string SQLiteEx = null;
            
            if (DbHelper.ValidateDB())
            {
                
                if (DbHelper.myConnection != null)
                {

                    receiptListGridView.DataSource = DbHelper.PopulateDataGrid(selectReceipts);


                    receiptListGridView.Columns[0].HeaderText = "ID";
                    receiptListGridView.Columns[1].HeaderText = "Shop name";
                    receiptListGridView.Columns[2].HeaderText = "Date";
                    receiptListGridView.Columns[3].HeaderText = "Total price";

                    receiptListGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    receiptListGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    receiptListGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    receiptListGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


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
                receiptListGridView.DataSource = DbHelper.PopulateDataGrid(selectReceipts);
                stripStatus.Text = "Refreshed the grid with stored receipts.";
            }
            else stripStatus.Text = "Could not establish a connection with a database.";
        }

        private void selectedRowsButton_Click(object sender, System.EventArgs e)
        {
          

            string SelectedReceiptID = receiptListGridView.CurrentRow.Cells[0].Value.ToString();
            string SelectedShopName = receiptListGridView.CurrentRow.Cells[1].Value.ToString();
            
            string sqlQuery = @" USE heroku_1144b6fe5f570ba; SELECT product_name, price, type_name
                            FROM " + SelectedShopName+
                            @" JOIN products USING(product_id)
                            JOIN types USING(type_id)
                            WHERE receipt_id = " + SelectedReceiptID;

            selectedReceiptGridView.DataSource = DbHelper.PopulateDataGrid(sqlQuery);

            selectedReceiptGridView.Columns[0].HeaderText = "Name";
            selectedReceiptGridView.Columns[1].HeaderText = "Price";
            selectedReceiptGridView.Columns[2].HeaderText = "Type";

            selectedReceiptGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            selectedReceiptGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            selectedReceiptGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            selectedReceiptGridView.Show();

        }
        
    }
}
