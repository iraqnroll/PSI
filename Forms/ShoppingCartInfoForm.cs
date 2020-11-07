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
            if (cart.Any())
            {
                DataTable table = new DataTable();
                table.Columns.Add("Name");
                table.Columns.Add("IKI", typeof(double));
                table.Columns.Add("MAXIMA", typeof(double));
                table.Columns.Add("LIDL", typeof(double));
                table.Columns.Add("NORFA", typeof(double));
                table.Columns.Add("RIMI", typeof(double));
                table.Columns.Add("BEST STORE");


                foreach (Item item in cart)
                {
                    DataRow a = table.NewRow();
                    a["Name"] = item.ItemName;
                    a["IKI"] = lowestPrice(item.ItemName, "iki");
                    a["MAXIMA"] = lowestPrice(item.ItemName, "maxima");
                    a["LIDL"] = lowestPrice(item.ItemName, "lidl");
                    a["NORFA"] = lowestPrice(item.ItemName, "norfa");
                    a["RIMI"] = lowestPrice(item.ItemName, "rimi");
                    string query = @"USE heroku_1144b6fe5f570ba; SELECT productname, MIN(price) FROM
                    ( SELECT 'IKI' AS productname, price, MAX(date) FROM iki JOIN products USING(product_id) WHERE product_name = '" + item.ItemName + @"'
                    UNION     
                    SELECT 'NORFA' AS productname, price, MAX(date) FROM norfa JOIN products USING(product_id) WHERE product_name = '" + item.ItemName + @"'
                    UNION
                    SELECT 'MAXIMA' AS productname, price, MAX(date) FROM maxima JOIN products USING(product_id) WHERE product_name = '" + item.ItemName + @"'
                    UNION
                    SELECT 'LIDL' AS productname, price, MAX(date) FROM lidl JOIN products USING(product_id) WHERE product_name = '" + item.ItemName + @"'
                    UNION
                    SELECT 'RIMI' AS productname, price, MAX(date) FROM rimi JOIN products USING(product_id) WHERE product_name = '" + item.ItemName + @"') AS T WHERE price IS NOT NULL";
                    a["BEST STORE"] = DbHelper.SingleValueSelection(query,"productname");
                    table.Rows.Add(a);
                }
                DataRow sum = table.NewRow();
                sum["Name"] = "Total: ";
                sum["IKI"] = Math.Round((double)table.Compute("SUM(IKI)", ""), 2);
                sum["MAXIMA"] = Math.Round((double)table.Compute("SUM(MAXIMA)", ""), 2);
                sum["LIDL"] = Math.Round((double)table.Compute("SUM(LIDL)", ""), 2);
                sum["NORFA"] = Math.Round((double)table.Compute("SUM(NORFA)", ""), 2);
                sum["RIMI"] = Math.Round((double)table.Compute("SUM(RIMI)", ""), 2);
                string best = table.AsEnumerable().Max(row => row["BEST STORE"]).ToString();
                sum["BEST STORE"] = "";
                table.Rows.Add(sum);
                dataGrid.DataSource = table;
                dataGrid.AutoResizeColumns();
                dataGrid.Show();
                bestStoreLabel.Text = "Cheapest place to shop: " + best; 

            }
            else
                MessageBox.Show("Please create a shopping cart");
           

        }
        private double lowestPrice (string itemname, string storename)
        {
            String temp = DbHelper.SingleValueSelection("USE heroku_1144b6fe5f570ba; SELECT price, MAX(date) FROM " + storename + " JOIN products USING (product_id) WHERE product_name = '" + itemname + "'", "price");
            if (temp == "")
                return 0;
            else
                return Double.Parse(temp);
        }

    }
}
