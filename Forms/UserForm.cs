using PSIShoppingEngine.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PSIShoppingEngine.Forms
{
    public partial class UserForm : Form
    {
        public struct ShopShort 
        {
            public string ShopName { get; set; }
            public int shopID { get; set; }

        }

        public struct ItemShort 
        {
            public string ItemName { get; set; }
            public int ItemID { get; set; }

        }
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
            public DateTime Date { get; set; }
            public List<string> Shops { get; set; }
            public List<int> ReceiptID { get; set; }
            public int OverallPurchaseCount { get; set; }
        }

        public const int TakeItems = 5;
        public List<Shop> shops = new List<Shop>();
        public List<Item> items = new List<Item>();
        public List<Day> days = new List<Day>();



        public UserForm()
        {
            InitializeComponent();
        }

        private void PrepareMoneySpentPanel()
        {
            var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ListBox moneyview = new ListBox { Name = "moneySpent", Parent = MoneySpentPanel };
            double totalSum = 0;
            foreach (var shop in shops)
            {
                if (shop.MoneySpent > 0)
                {
                    moneyview.Items.Add(shop.ShopName + " : " + shop.MoneySpent.ToString("C", culture));
                    totalSum += shop.MoneySpent;
                }
            }
            moneyview.Size = MoneySpentPanel.Size;
            moneyview.Items.Add("TOTAL : " + totalSum.ToString("C", culture));
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
            FrequentShopPieChart.Series[0].IsValueShownAsLabel = true;

            //Populate the item pie-chart:
            string[] itemNames = (from item in items orderby item.ItemCount descending where item.ItemCount > 0 select item.ItemName).Take(TakeItems).ToArray();
            int[] itemFrequencies = (from item in items orderby item.ItemCount descending where item.ItemCount > 0 select item.ItemCount).Take(TakeItems).ToArray();

            FrequentlyBoughItemsPieChart.Series[0].ChartType = SeriesChartType.Pie;
            FrequentlyBoughItemsPieChart.Series[0].Points.DataBindXY(itemNames, itemFrequencies);
            FrequentlyBoughItemsPieChart.Legends[0].Enabled = true;
            FrequentlyBoughItemsPieChart.Series[0].IsValueShownAsLabel = true;

            PrepareMoneySpentPanel();



            days = UserHelper.RetrieveShoppingDays();
            var distinctMonths = (from day in days select day.Date.Month).Distinct();   //Get all distinct months from shopping days.

            var ShoppingMonths = from month in distinctMonths
                                 join day in days on month equals day.Date.Month into g
                                 select new { DistinctMonth = month, days = g };       //group join the days with their respective months.

            //Populating the combobox with month names :
            MonthSelect.Items.AddRange((from month in ShoppingMonths select month.DistinctMonth.ToString()).ToArray());


            DbHelper.CloseConnection();
        }


        private void ShoppingPerMonthChart_CursorPositionChanged(object sender, CursorEventArgs e)
        {
            MonthChartListView.Items.Clear();
            DataPoint pt = ShoppingPerMonthChart.Series[0].Points[(int)Math.Max(e.ChartArea.CursorX.Position - 1, 0)];
            pt.MarkerStyle = MarkerStyle.Square;

            foreach(var day in days)
            {
                if(String.Equals(pt.AxisLabel,day.Date.ToString("dd/MM/yyyy")))
                {
                    foreach(var shop in day.Shops)
                    {
                        ListViewItem item = new ListViewItem(shop);
                        MonthChartListView.Items.Add(item);
                    }
                }
            }
        }

        private void MonthSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            MonthChartListView.Items.Clear();
            string selectedMonth = MonthSelect.SelectedItem.ToString();
            var dates = (from day in days where day.Date.Month.ToString() == selectedMonth select day.Date.ToString("dd/MM/yyyy")).ToArray();
            var receiptCount = (from day in days where day.Date.Month.ToString() == selectedMonth select day.OverallPurchaseCount).ToArray();

            ShoppingPerMonthChart.Series[0].Points.DataBindXY(dates, receiptCount);
            ShoppingPerMonthChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            ShoppingPerMonthChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            ShoppingPerMonthChart.Series[0].BorderWidth = 3;
            ShoppingPerMonthChart.Legends[0].Enabled = false;

            //Prepare the chart for user interaction.
            ShoppingPerMonthChart.ChartAreas["ChartArea1"].CursorX.IsUserEnabled = true;
            ShoppingPerMonthChart.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = true;
            ShoppingPerMonthChart.ChartAreas["ChartArea1"].CursorX.SelectionColor = System.Drawing.Color.Transparent;
        }
    }
}
