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
using System.Data.SqlClient;
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
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
