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

            foreach (DataGridViewRow row in ReceiptDataGrid.Rows)   //Handle serializing null values.
            {
                Item ReceiptItem = new Item();
                ReceiptItem.ItemName = (string)row.Cells["ItemName"].Value;
                ReceiptItem.ItemPrice = (string)row.Cells["ItemPrice"].Value;
                if (row.Cells["Item Type"].Value != null)
                {
                    ReceiptItem.Type = (Item.ItemType)row.Cells["Item Type"].Value;
                    ReceiptItems.Add(ReceiptItem);
                }
            }
            string convertedReceiptItems = JsonConvert.SerializeObject(ReceiptItems);
            string sqlQuery = "INSERT INTO Receipts (receiptdate, itemdata, shopname) VALUES ('" + DateTime.Today.ToString("dd/MM/yyyy") + "','" + convertedReceiptItems + "','" + txtShop.Text + "')";

            DbHelper.InsertIntoDB(sqlQuery);
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lal = { "" };

            DataGridViewRow RowSample = new DataGridViewRow();
            DataGridViewComboBoxCell CellSample = new DataGridViewComboBoxCell();
            CellSample.DataSource = lal; // list of the string items that I want to insert in ComboBox
            CellSample.Value = lal[0]; // default value for the ComboBox
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            cell.Value = ""; // creating the text cell
            RowSample.Cells.Add(cell);
            RowSample.Cells.Add(CellSample);
            ReceiptDataGrid.Rows.Add(RowSample);
        }

        private void ReceiptDataGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            

            var newValue = ReceiptDataGrid.CurrentCell.EditedFormattedValue;
            var test = ReceiptDataGrid.CurrentCell;
           

            if (test.ColumnIndex == 2)
            {
                DataGridViewComboBoxCell itemNameBoxColumn = ReceiptDataGrid.Rows[test.RowIndex].Cells[test.ColumnIndex - 1] as DataGridViewComboBoxCell;
                ReceiptDataGrid.Rows[test.RowIndex].Cells[1].Value = "";
                switch (newValue)
                {
                    case "Electronics":
                        itemNameBoxColumn.DataSource = new string[] { "Ausines", "Blenderis", "Dziovintuvas", "Svarstykles", "Pelyte", "Klaviatura" };
                        break;
                    case "Meat":
                        itemNameBoxColumn.DataSource = new string[] { "Malta mesa", "Vistienos file", "Rukyta desra", "Pieniskos desreles", "Jautiena", "Kiauliena" };
                        break;
                    case "Dairy":
                        itemNameBoxColumn.DataSource = new string[] { "Pienas", "Sviestas", "Grietine", "Kefyras", "Suris", "Surelis" };
                        break;
                    case "Beverage":
                        itemNameBoxColumn.DataSource = new string[] { "Cola", "Sprite", "Alus", "Sultys", "Gira", "Fanta" };
                        break;
                    case "Pastry":
                        itemNameBoxColumn.DataSource = new string[] { "Bandeles", "Tortas", "Pyragas", "Keksas", "Vyniotinis", "Spurgos" };
                        break;
                    case "Vegetables":
                        itemNameBoxColumn.DataSource = new string[] { "Morkos", "Bulves", "Kopustas", "Pomidoras", "Agurkas", "Rope" };
                        break;
                    default:
                        itemNameBoxColumn.DataSource = new string[] { "random", "random", "random", "random", "random", "random" };
                        break;
                }
            }

        }
    }
}
