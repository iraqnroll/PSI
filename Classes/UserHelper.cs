using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI.Common;
using MySql.Data.MySqlClient;

namespace PSIShoppingEngine.Classes
{
    public static class UserHelper
    {


        public static string RetrieveShopName(int shopID)
        {   
            
            string sqlQuery = "USE heroku_1144b6fe5f570ba; SELECT shop_name FROM shops where shop_id = " + shopID.ToString();
            MySqlCommand command = new MySqlCommand(sqlQuery, DbHelper.myConnection);
            return Convert.ToString(command.ExecuteScalar());
        }
        public static int RetrieveShopFrequency(int shopID)
        {
            string sqlQuery = "USE heroku_1144b6fe5f570ba; SELECT COUNT(shop_id) FROM receipts WHERE shop_id = " + shopID;
            MySqlCommand command = new MySqlCommand(sqlQuery, DbHelper.myConnection);
            return Convert.ToInt32(command.ExecuteScalar());
        }
        public static double RetrieveMoneySpentInShop(string shopName)
        {
            string sqlQuery = "USE heroku_1144b6fe5f570ba; SELECT SUM(price) FROM " + shopName.ToLower();
            MySqlCommand command = new MySqlCommand(sqlQuery, DbHelper.myConnection);
            var Money = command.ExecuteScalar();
            if (!(Money is DBNull))
            {
                return Convert.ToDouble(Money);
            }
            else return 0;
        }

        public static void RetrieveShopsInfo(List<Forms.UserForm.Shop>shopList)
        {
            string sqlQuery = "USE heroku_1144b6fe5f570ba; SELECT * FROM shops";
            MySqlCommand command = new MySqlCommand(sqlQuery, DbHelper.myConnection);
            MySqlDataReader reader = command.ExecuteReader();

            List<Forms.UserForm.ShopShort> shopShortList = new List<Forms.UserForm.ShopShort>();
            while (reader.Read())
            {
                Forms.UserForm.ShopShort shop = new Forms.UserForm.ShopShort();
                shop.ShopName = (string)reader["shop_name"];
                shop.shopID = Convert.ToInt32(reader["shop_id"]);
                shopShortList.Add(shop);
            }
            reader.Close();

            foreach (var shopShort in shopShortList) {
                Forms.UserForm.Shop shop = new Forms.UserForm.Shop();
                shop.ShopName = shopShort.ShopName;
                shop.shopID = shopShort.shopID;
                shop.MoneySpent = RetrieveMoneySpentInShop(shop.ShopName);
                shop.ReceiptCount = RetrieveShopFrequency(shop.shopID);
                shopList.Add(shop);

            }

        }

        public static int RetrieveItemFrequency(int itemID, List<Forms.UserForm.Shop> shopList)
        {
            int Count=0;
            foreach(var shop in shopList)   //Retrieve purchases count for each product in every shop table.
            {
                string sqlQuery = "USE heroku_1144b6fe5f570ba; SELECT COUNT(product_id) FROM " + shop.ShopName.ToLower() + " WHERE product_id = " + itemID;
                MySqlCommand command = new MySqlCommand(sqlQuery, DbHelper.myConnection);
                Count += Convert.ToInt32(command.ExecuteScalar());
            }
            return Count;
        }

        public static void RetrieveItemList(List<Forms.UserForm.Item>itemList, List<Forms.UserForm.Shop>shopList)
        {
            string sqlQuery = "USE heroku_1144b6fe5f570ba; SELECT product_id, product_name FROM products";
            MySqlCommand command = new MySqlCommand(sqlQuery, DbHelper.myConnection);
            MySqlDataReader reader = command.ExecuteReader();

            List<Forms.UserForm.ItemShort> itemShortList = new List<Forms.UserForm.ItemShort>();

            while (reader.Read())
            {
                Forms.UserForm.ItemShort item = new Forms.UserForm.ItemShort();
                item.ItemName = (string)reader["product_name"];
                item.ItemID = Convert.ToInt32(reader["product_id"]);
                //item.ItemCount += RetrieveItemFrequency(item.ItemID, shopList);
                itemShortList.Add(item);
            }
            reader.Close();

            foreach (var itemShort in itemShortList)
            {
                Forms.UserForm.Item item = new Forms.UserForm.Item();
                item.ItemName = itemShort.ItemName;
                item.ItemID = itemShort.ItemID;
                item.ItemCount += RetrieveItemFrequency(item.ItemID, shopList);
                itemList.Add(item);
            }
            
        }


        public static List<string> RetrieveShopsOfDate(string Date)
        {
            string sqlQuery = "USE heroku_1144b6fe5f570ba; SELECT shop_id FROM receipts WHERE receipt_date = '" + Date + "'";
            MySqlCommand command = new MySqlCommand(sqlQuery, DbHelper.myConnection);
            MySqlDataReader reader = command.ExecuteReader();
            List<string> shops = new List<string>();
            List<int> shopids = new List<int>();
            while(reader.Read())
            {
                int shopid = Convert.ToInt32(reader["shop_id"]);
                shopids.Add(shopid);
            }
            reader.Close();
            foreach (var id in shopids)
            {
                string shopName = RetrieveShopName(id);
                shops.Add(shopName);
            }

            
            return shops;
        }

        public static List<int> RetrieveReceiptsOfDate(string Date)
        {
            string sqlQuery = "USE heroku_1144b6fe5f570ba; SELECT receipt_id FROM receipts WHERE receipt_date = '" + Date + "'";
            MySqlCommand command = new MySqlCommand(sqlQuery, DbHelper.myConnection);
            MySqlDataReader reader = command.ExecuteReader();
            List<int> receipts = new List<int>();
            while(reader.Read())
            {
                int id = Convert.ToInt32(reader["receipt_id"]);
                receipts.Add(id);
            }
            reader.Close();
            return receipts;
        }

        public static List<Forms.UserForm.Day> RetrieveShoppingDays()
        {
            var days = new List<Forms.UserForm.Day>();
            string GetDatesQuery = "USE heroku_1144b6fe5f570ba; SELECT DISTINCT receipt_date FROM receipts";
            MySqlCommand command = new MySqlCommand(GetDatesQuery, DbHelper.myConnection);
            MySqlDataReader reader = command.ExecuteReader();

            List<DateTime> dayList = new List<DateTime>();
            while (reader.Read())
            {
                DateTime test = reader.GetDateTime(0);
                dayList.Add(test);
            }
            reader.Close();

            foreach(var d in dayList)
            {
                Forms.UserForm.Day day = new Forms.UserForm.Day();
                day.Date = d;
                day.Shops = RetrieveShopsOfDate(d.ToString("yyyy-MM-dd"));
                day.ReceiptID = RetrieveReceiptsOfDate(d.ToString("yyyy-MM-dd"));
                day.OverallPurchaseCount = day.ReceiptID.Count();
                days.Add(day);
            }

            return days;
        }

    }
}
