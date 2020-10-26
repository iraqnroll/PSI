using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Bcpg.Sig;
using PSIShoppingEngine.Classes;

namespace PSIShoppingEngine.Forms
{
    public partial class ShoppingCartInfoForm : Form
    {
        public ShoppingCartInfoForm()
        {
            InitializeComponent();
        }
        public List<Item> cart = new List<Item>();

        private void AddShoppingCart_Click(object sender, EventArgs e)
        {
            cart.Clear();
            ShoppingCartForm f = new ShoppingCartForm(cart);
            f.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("IKI");
            table.Columns.Add("MAXIMA");
            table.Columns.Add("LIDL");
            table.Columns.Add("NORFA");
            table.Columns.Add("RIMI");

            foreach (Item item in cart)
            {
                DataRow a = table.NewRow();
                a["Name"] = item.ItemName;
                a["IKI"] = DbHelper.SingleValueSelection("SELECT price, MAX (date) FROM iki JOIN products USING (product_id) WHERE product_name = '" + item.ItemName + "'", "price");
                a["MAXIMA"] = DbHelper.SingleValueSelection("SELECT price, MAX (date) FROM maxima JOIN products USING (product_id) WHERE product_name = '" + item.ItemName + "'", "price");
                a["LIDL"] = DbHelper.SingleValueSelection("SELECT price, MAX (date) FROM lidl JOIN products USING (product_id) WHERE product_name = '" + item.ItemName + "'", "price");
                a["NORFA"] = DbHelper.SingleValueSelection("SELECT price, MAX (date) FROM norfa JOIN products USING (product_id) WHERE product_name = '" + item.ItemName + "'", "price");
                a["RIMI"] = DbHelper.SingleValueSelection("SELECT price, MAX (date) FROM rimi JOIN products USING (product_id) WHERE product_name = '" + item.ItemName + "'", "price");
                table.Rows.Add(a);
            }
                dataGrid.DataSource = table;
                dataGrid.Columns[0].HeaderText = "Name";
                dataGrid.Columns[1].HeaderText = "IKI";
                dataGrid.Columns[2].HeaderText = "MAXIMA";
                dataGrid.Columns[3].HeaderText = "LIDL";
                dataGrid.Columns[4].HeaderText = "NORFA";
                dataGrid.Columns[5].HeaderText = "RIMI";
            dataGrid.AutoResizeColumns();
         
            



            dataGrid.Show();
            


        }
    }
}
