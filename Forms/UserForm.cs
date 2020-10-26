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
        public struct Day
        {
            public string Date { get; set; }
            public List<string> Shops { get; set; }
            public List<int> ReceiptID { get; set; }
            public int OverallPurchaseCount { get; set; }
        }

        public const int TakeItems = 5;
        public List<Shop> shops = new List<Shop>();
        public List<Item> items = new List<Item>();
        public List<Day> shopmonth = new List<Day>();
        


        public UserForm()
        {
            InitializeComponent();
        }

        private void PrepareMoneySpentPanel()
        {
            ListBox moneyview = new ListBox { Name = "moneySpent", Parent = MoneySpentPanel };
            double totalSum = 0;
            foreach (var shop in shops)
            {
                if (shop.MoneySpent > 0)
                {
                    moneyview.Items.Add(shop.ShopName + " : " + shop.MoneySpent.ToString());
                    totalSum += shop.MoneySpent;
                }
            }
            moneyview.Items.Add("TOTAL : " + totalSum.ToString());
            MoneySpentPanel.Size = moneyview.Size;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            DbHelper.OpenConnection();
            //Retrieve shops:
            UserHelper.RetrieveShopsInfo(shops);
            //Retrieve products:
            UserHelper.RetrieveItemList(items, shops);


            //Populate the shop pie-chart:
            string[] shopNames = (from shop in shops where shop.ReceiptCount > 0 select shop.ShopName).ToArray();
            int[] shopFrequencies = (from shop in shops where shop.ReceiptCount > 0 select shop.ReceiptCount).ToArray();

            FrequentShopPieChart.Series[0].ChartType = SeriesChartType.Pie;
            FrequentShopPieChart.Series[0].Points.DataBindXY(shopNames, shopFrequencies);
            FrequentShopPieChart.Legends[0].Enabled = true;

            //Populate the item pie-chart:
            string[] itemNames = (from item in items orderby item.ItemCount descending where item.ItemCount > 0 select item.ItemName).Take(TakeItems).ToArray();
            int[] itemFrequencies = (from item in items orderby item.ItemCount descending where item.ItemCount > 0 select item.ItemCount).Take(TakeItems).ToArray();

            FrequentlyBoughItemsPieChart.Series[0].ChartType = SeriesChartType.Pie;
            FrequentlyBoughItemsPieChart.Series[0].Points.DataBindXY(itemNames, itemFrequencies);
            FrequentlyBoughItemsPieChart.Legends[0].Enabled = true;

            PrepareMoneySpentPanel();

            UserHelper.RetrieveShoppingMonths(shopmonth);

            //Populate the shopping-per-month line chart.
            string[] dates = (from month in shopmonth select month.Date).ToArray();
            int[] receiptCount = (from month in shopmonth select month.OverallPurchaseCount).ToArray();
            ShoppingPerMonthChart.Series[0].Points.DataBindXY(dates, receiptCount);
            ShoppingPerMonthChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            ShoppingPerMonthChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            ShoppingPerMonthChart.Series[0].BorderWidth = 3;
            ShoppingPerMonthChart.Legends[0].Enabled = false;

            //Prepare the chart for user interaction.
            ShoppingPerMonthChart.ChartAreas["ChartArea1"].CursorX.IsUserEnabled = true;
            ShoppingPerMonthChart.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = true;
            ShoppingPerMonthChart.ChartAreas["ChartArea1"].CursorX.SelectionColor = System.Drawing.Color.Transparent;

            DbHelper.CloseConnection();
        }


        private void ShoppingPerMonthChart_CursorPositionChanged(object sender, CursorEventArgs e)
        {
            MonthChartListView.Items.Clear();
            DataPoint pt = ShoppingPerMonthChart.Series[0].Points[(int)Math.Max(e.ChartArea.CursorX.Position - 1, 0)];
            pt.MarkerStyle = MarkerStyle.Square;
            foreach(var date in  shopmonth)
            {
                if(String.Equals(pt.AxisLabel,date.Date))
                {
                    foreach(var shop in date.Shops)
                    {
                        ListViewItem item = new ListViewItem(shop);
                        MonthChartListView.Items.Add(item);
                    }
                }
            }
        }

        private void ShoppingPerMonthChart_Click(object sender, EventArgs e)
        {

        }

        private void MonthChartListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
