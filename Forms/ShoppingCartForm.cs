using PSIShoppingEngine.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using System.Windows.Forms;
using System.Data.SQLite;
using Newtonsoft.Json;

namespace PSIShoppingEngine.Forms
{
    public partial class ShoppingCartForm : Form
    {
        public string ReceiptFilePath { get; set; }
        public Receipt rec { get; set; }
        private List<Item> ReceiptItems = new List<Item>();
        public ShoppingCartForm(List<Item> cart)
        {
            InitializeComponent();
            ReceiptItems = cart;
        }
       

        private void NewReceipt_Load(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn TypeCol = new DataGridViewComboBoxColumn();
            TypeCol.Name = "Item Type";
            TypeCol.DataSource = DbHelper.SingleColumSelection("SELECT type_name FROM types", "type_name");  
            ReceiptDataGrid.Columns.Add(TypeCol);

            
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            string[] empty = { "" };

            DataGridViewRow RowSample = new DataGridViewRow();
            DataGridViewComboBoxCell productComboBox = new DataGridViewComboBoxCell();
            productComboBox.DataSource = empty;
            productComboBox.Value = empty[0]; 
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            
            RowSample.Cells.Add(productComboBox);
            ReceiptDataGrid.Rows.Add(RowSample);
        }

        private void ReceiptDataGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
    
            var cell = ReceiptDataGrid.CurrentCell; 

            if (cell.ColumnIndex == 1)
            {
                DataGridViewComboBoxCell itemNameBoxColumn = ReceiptDataGrid.Rows[cell.RowIndex].Cells[cell.ColumnIndex - 1] as DataGridViewComboBoxCell;
                ReceiptDataGrid.Rows[cell.RowIndex].Cells[0].Value = "";

              itemNameBoxColumn.DataSource = DbHelper.SingleColumSelection("SELECT product_name FROM products JOIN types USING(type_id) WHERE type_name = \"" + cell.EditedFormattedValue + "\"" , "product_name");

            }

        }

        private void btnSaveReceipt_Click_1(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in ReceiptDataGrid.Rows)
            {
                ReceiptItems.Add(new Item { ItemName = (string)row.Cells["ItemName"].Value, ItemPrice = "", Type = Item.ItemType.Other });
            }
            Close();
        }

        private void ReceiptDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
