using PSIShoppingEngine.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PSIShoppingEngine.Forms
{
    public partial class UserForm : Form
    {
        public struct Shop
        {
            public string ShopName { get; set; }
            public int shopID { get; set; }
            public double MoneySpent { get; set; }
            public int ReceiptCount { get; set; }
        }

        public struct Item
        {
            public string ItemName { get; set; }
            public int ItemID { get; set; }
            public int ItemCount { get; set; }
        }


        public const int TakeItems = 5;
        public List<Shop> shops = new List<Shop>();
        public List<Item> items = new List<Item>();


        public UserForm()
        {
            InitializeComponent();
        }

        private void PrepareMoneySpentPanel()
        {
            ListBox moneyview = new ListBox { Name = "moneySpent", Parent = MoneySpentPanel, Size = MoneySpentPanel.Size};
            double totalSum = 0;
            foreach(var shop in shops)
            {
                if(shop.MoneySpent > 0)
                {
                    moneyview.Items.Add(shop.ShopName + " : " + shop.MoneySpent.ToString());
                    totalSum += shop.MoneySpent;
                }
            }
            moneyview.Items.Add("TOTAL : " + totalSum.ToString());
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            DbHelper.OpenConnection();
            //Retrieve shops:
            UserHelper.RetrieveShopsInfo(shops);
            //Retrieve products:
            UserHelper.RetrieveItemList(items,shops);


            //Populate the shop pie-chart:
            string[] shopNames = (from shop in shops where shop.ReceiptCount>0 select shop.ShopName).ToArray();
            int[] shopFrequencies = (from shop in shops where shop.ReceiptCount > 0 select shop.ReceiptCount).ToArray();

            FrequentShopPieChart.Series[0].ChartType = SeriesChartType.Pie;
            FrequentShopPieChart.Series[0].Points.DataBindXY(shopNames,shopFrequencies);
            FrequentShopPieChart.Legends[0].Enabled = true;

            //Populate the item pie-chart:
            string[] itemNames = (from item in items orderby item.ItemCount descending where item.ItemCount > 0 select item.ItemName).Take(TakeItems).ToArray();
            int[] itemFrequencies = (from item in items orderby item.ItemCount descending where item.ItemCount > 0 select item.ItemCount).Take(TakeItems).ToArray();

            FrequentlyBoughItemsPieChart.Series[0].ChartType = SeriesChartType.Pie;
            FrequentlyBoughItemsPieChart.Series[0].Points.DataBindXY(itemNames, itemFrequencies);
            FrequentlyBoughItemsPieChart.Legends[0].Enabled = true;

            PrepareMoneySpentPanel();
        }
    }
}
