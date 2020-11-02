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
    public partial class NewReceipt : Form
    {
        public string ReceiptFilePath { get; set; }
        public bool OCR { get; set; }
        public Receipt rec { get; set; }
        public NewReceipt()
        {
            InitializeComponent();
        }

        private void NewReceipt_Load(object sender, EventArgs e)
        {
            shopNameComboBox.DataSource = DbHelper.SingleColumSelection("SELECT shop_name FROM shops", "shop_name");

            if (OCR)
            {
                rec = new Receipt();
                rec.Groceries = new List<Item>();

                Pix ReceiptImg = Pix.LoadFromFile(ReceiptFilePath);      //Load our receipt image.
                var TessEng = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
                var page = TessEng.Process(ReceiptImg);

                Classes.ParseOCR parser = new Classes.ParseOCR();
                parser.Parse(page, rec);

                DataGridViewComboBoxColumn TypeCol = new DataGridViewComboBoxColumn();
                TypeCol.Name = "Item Type";
                
                TypeCol.DataSource = DbHelper.SingleColumSelection("SELECT type_name FROM types", "type_name");
               
                ReceiptDataGrid.Columns.Add(TypeCol);

                foreach (var item in rec.Groceries)
                {
                    ReceiptDataGrid.Rows.Add(item.ItemName, item.ItemPrice, item.Type);
                }
            }
            else
            {

                DataGridViewComboBoxColumn TypeCol = new DataGridViewComboBoxColumn();
                TypeCol.Name = "Item Type";
                TypeCol.DataSource = DbHelper.SingleColumSelection("SELECT type_name FROM types", "type_name");
               
                ReceiptDataGrid.Columns.Add(TypeCol);

            }
        }

        private void btnSaveReceipt_Click(object sender, EventArgs e)
        {


            string shopId = DbHelper.SingleValueSelection("SELECT shop_id FROM shops WHERE shop_name = \"" + shopNameComboBox.Text + "\"", "shop_id");
            DbHelper.InsertIntoDB("INSERT INTO receipts(shop_id, receipt_date) VALUES('" + shopId + "','"+ DateTime.Today.ToString("dd/MM/yyyy")+"')");

            string receiptId = DbHelper.SingleValueSelection("SELECT receipt_id FROM receipts ORDER BY  receipt_id DESC LIMIT 1", "receipt_id");


            
            
            List<Item> ReceiptItems = new List<Item>();

            foreach (DataGridViewRow row in ReceiptDataGrid.Rows)  
            {

                if (row.Cells["ItemPrice"].Value != null)
                {

                    string productId = DbHelper.SingleValueSelection("SELECT product_id FROM products WHERE product_name = \""+ (string)row.Cells["ItemName"].Value +"\"", "product_id");

                    DbHelper.InsertIntoDB("INSERT INTO "+ shopNameComboBox.Text + " (product_id, date, price, receipt_id) VALUES('" + productId + "','" + DateTime.Today.ToString(@"dd\/MM\/yyyy") + "','"+ (string)row.Cells["ItemPrice"].Value +"','"+receiptId+"')");
                }
            }
            
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] empty = { "" };

            DataGridViewRow RowSample = new DataGridViewRow();
            DataGridViewComboBoxCell productComboBox = new DataGridViewComboBoxCell();
            productComboBox.DataSource = empty;
            productComboBox.Value = empty[0]; 
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            cell.Value = ""; 
            RowSample.Cells.Add(cell);
            RowSample.Cells.Add(productComboBox);
            ReceiptDataGrid.Rows.Add(RowSample);
        }

        private void ReceiptDataGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
    
            var cell = ReceiptDataGrid.CurrentCell; 

            if (cell.ColumnIndex == 2)
            {
                DataGridViewComboBoxCell itemNameBoxColumn = ReceiptDataGrid.Rows[cell.RowIndex].Cells[cell.ColumnIndex - 1] as DataGridViewComboBoxCell;
                ReceiptDataGrid.Rows[cell.RowIndex].Cells[1].Value = "";

              itemNameBoxColumn.DataSource = DbHelper.SingleColumSelection("SELECT product_name FROM products JOIN types USING(type_id) WHERE type_name = \"" + cell.EditedFormattedValue + "\"" , "product_name");

            }

        }
    }
}
