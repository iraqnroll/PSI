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
        public SQLiteConnection connection { get; set; }
        public string ReceiptFilePath { get; set; }
        public bool OCR { get; set; }
        public Receipt rec { get; set; }
        public NewReceipt()
        {
            InitializeComponent();
        }

        private void NewReceipt_Load(object sender, EventArgs e)
        {
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
                TypeCol.DataSource = Enum.GetValues(typeof(Item.ItemType));
                TypeCol.ValueType = typeof(Item.ItemType);
                ReceiptDataGrid.Columns.Add(TypeCol);

                foreach (var item in rec.Groceries)
                {
                    ReceiptDataGrid.Rows.Add(item.ItemName, item.ItemPrice, item.Type);
                }
            }
            else
            {
                rec = new Receipt();
                rec.Groceries = new List<Item>();

                DataGridViewComboBoxColumn TypeCol = new DataGridViewComboBoxColumn();
                TypeCol.Name = "Item Type";
                TypeCol.DataSource = Enum.GetValues(typeof(Item.ItemType));
                TypeCol.ValueType = typeof(Item.ItemType);
                ReceiptDataGrid.Columns.Add(TypeCol);

            }
        }

        private void btnSaveReceipt_Click(object sender, EventArgs e)
        {
           List<Item> ReceiptItems = new List<Item>();
           Item ReceiptItem = new Item();
           foreach (DataGridViewRow row in ReceiptDataGrid.Rows)
           {
                ReceiptItem.ItemName = (string)row.Cells["ItemName"].Value;
                ReceiptItem.ItemPrice = (string)row.Cells["ItemPrice"].Value;
                if(row.Cells["Item Type"].Value != null)
                {
                    ReceiptItem.Type = (Item.ItemType)row.Cells["Item Type"].Value;
                    ReceiptItems.Add(ReceiptItem);
                }
           }
           string convertedReceiptItems = JsonConvert.SerializeObject(ReceiptItems);
            string sqlQuery = "INSERT INTO Receipts (receiptdate, itemdata, shopname) VALUES ('"+ DateTime.Today.ToString("dd/MM/yyyy")+"','"+convertedReceiptItems+"','"+txtShop.Text+"')";
            DbHelper dbHelper = new DbHelper();
            dbHelper.InsertIntoDB(connection, sqlQuery);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
