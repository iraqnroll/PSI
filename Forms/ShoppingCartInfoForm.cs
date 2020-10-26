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

            foreach (Item item in cart)
            {
                DataRow a = table.NewRow();
                a["Name"] = item.ItemName;
                a["IKI"] = DbHelper.SingleValueSelection("SELECT price, MAX (date) FROM iki JOIN products USING (product_id) WHERE product_name = '" + item.ItemName + "'", "price");
                a["MAXIMA"] = DbHelper.SingleValueSelection("SELECT price, MAX (date) FROM maxima JOIN products USING (product_id) WHERE product_name = '" + item.ItemName + "'", "price");
                a["LIDL"] = DbHelper.SingleValueSelection("SELECT price, MAX (date) FROM lidl JOIN products USING (product_id) WHERE product_name = '" + item.ItemName + "'", "price");
                a["NORFA"] = DbHelper.SingleValueSelection("SELECT price, MAX (date) FROM norfa JOIN products USING (product_id) WHERE product_name = '" + item.ItemName + "'", "price");
                // var calculated = CalculateShoppingCart(item);
                // object[] info = { calculated[0], calculated[1], calculated[2] };
                table.Rows.Add(a);
            }
                dataGrid.DataSource = table;
                dataGrid.Columns[0].HeaderText = "Name";
                dataGrid.Columns[1].HeaderText = "IKI";
                dataGrid.Columns[2].HeaderText = "MAXIMA";
                dataGrid.Columns[3].HeaderText = "LIDL";
                dataGrid.Columns[4].HeaderText = "NORFA";
            


                dataGrid.Show();
            


        }
        private List<String> CalculateShoppingCart(Item item)
        {

            List<String> i = new List<String>();
            i.Add(item.ItemName);
            var rating = new List<Tuple<string, string>>();

            rating.Add(new Tuple<string, string>("iki", TestDB("iki", item)));
            rating.Add(new Tuple<string, string>("maxima", TestDB("maxima", item)));
            rating.Add(new Tuple<string, string>("norfa", TestDB("norfa", item)));
            rating.Add(new Tuple<string, string>("lidl", TestDB("lidl", item)));
            //rating.RemoveAll(t => t.Item2 == "0");
           // rating = rating.OrderBy(t => Double.Parse(t.Item2)).ToList();
            i.Add(rating[0].Item2);
            i.Add(rating[0].Item1);

            return i;
        }
        private String TestDB(String name, Item item)
        {
            String temp = DbHelper.SingleValueSelection
                ("SELECT max date) FROM " + name + " JOIN products USING (product_id) WHERE product_name = '" + item.ItemName + "'", "price");
            if (temp == "")
                 return "0";
             else {
                 Regex pattern = new Regex(".");
                 pattern.Replace(temp, ",");
                 return temp;
                 }
    

        }


    }
}
