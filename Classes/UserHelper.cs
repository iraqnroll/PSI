using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlX.XDevAPI.Common;

namespace PSIShoppingEngine.Classes
{
    public static class UserHelper
    {


        public static string RetrieveShopName(int shopID)
        {
            string sqlQuery = "SELECT shop_name FROM shops where shop_id = " + shopID.ToString();
            SQLiteCommand command = new SQLiteCommand(sqlQuery, DbHelper.myConnection);
            return Convert.ToString(command.ExecuteScalar());
        }
        public static int RetrieveShopFrequency(int shopID)
        {
            string sqlQuery = "SELECT COUNT(shop_id) FROM receipts WHERE shop_id = " + shopID;
            SQLiteCommand command = new SQLiteCommand(sqlQuery, DbHelper.myConnection);
            return Convert.ToInt32(command.ExecuteScalar());
        }
        public static double RetrieveMoneySpentInShop(string shopName)
        {
            string sqlQuery = "SELECT SUM(price) FROM " + shopName.ToLower();
            SQLiteCommand command = new SQLiteCommand(sqlQuery, DbHelper.myConnection);
            var Money = command.ExecuteScalar();
            if (!(Money is DBNull))
            {
                return Convert.ToDouble(Money);
            }
            else return 0;
        }

        public static void RetrieveShopsInfo(List<Forms.UserForm.Shop>shopList)
        {
            string sqlQuery = "SELECT * FROM shops";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, DbHelper.myConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Forms.UserForm.Shop shop = new Forms.UserForm.Shop();
                shop.ShopName = (string)reader["shop_name"];
                shop.shopID = Convert.ToInt32(reader["shop_id"]);
                shop.MoneySpent = RetrieveMoneySpentInShop(shop.ShopName);
                shop.ReceiptCount = RetrieveShopFrequency(shop.shopID);
                shopList.Add(shop);
            }
            reader.Close();
        }

        public static int RetrieveItemFrequency(int itemID, List<Forms.UserForm.Shop> shopList)
        {
            int Count=0;
            foreach(var shop in shopList)   //Retrieve purchases count for each product in every shop table.
            {
                string sqlQuery = "SELECT COUNT(product_id) FROM " + shop.ShopName.ToLower() + " WHERE product_id = " + itemID;
                SQLiteCommand command = new SQLiteCommand(sqlQuery, DbHelper.myConnection);
                Count += Convert.ToInt32(command.ExecuteScalar());
            }
            return Count;
        }

        public static void RetrieveItemList(List<Forms.UserForm.Item>itemList, List<Forms.UserForm.Shop>shopList)
        {
            string sqlQuery = "SELECT product_id, product_name FROM products";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, DbHelper.myConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Forms.UserForm.Item item = new Forms.UserForm.Item();
                item.ItemName = (string)reader["product_name"];
                item.ItemID = Convert.ToInt32(reader["product_id"]);
                item.ItemCount += RetrieveItemFrequency(item.ItemID, shopList);
                itemList.Add(item);
            }
        }


        public static List<string> RetrieveShopsOfDate(string Date)
        {
            string sqlQuery = "SELECT shop_id FROM receipts WHERE receipt_date = '" + Date + "'";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, DbHelper.myConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<string> shops = new List<string>();
            while(reader.Read())
            {
                string shopName = RetrieveShopName(Convert.ToInt32(reader["shop_id"]));
                shops.Add(shopName);
            }
            return shops;
        }

        public static List<int> RetrieveReceiptsOfDate(string Date)
        {
            string sqlQuery = "SELECT receipt_id FROM receipts WHERE receipt_date = '" + Date + "'";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, DbHelper.myConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<int> receipts = new List<int>();
            while(reader.Read())
            {
                int id = Convert.ToInt32(reader["receipt_id"]);
                receipts.Add(id);
            }
            return receipts;
        }

        public static void RetrieveShoppingMonths(List<Forms.UserForm.Day> month)
        {
            string GetDatesQuery = "SELECT DISTINCT receipt_date FROM receipts";
            SQLiteCommand command = new SQLiteCommand(GetDatesQuery, DbHelper.myConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Forms.UserForm.Day day = new Forms.UserForm.Day();
                day.Date = Convert.ToString(reader["receipt_date"]);      //Kazkodel gaudo nullus.
                day.Shops = RetrieveShopsOfDate(day.Date);
                day.ReceiptID = RetrieveReceiptsOfDate(day.Date);
                day.OverallPurchaseCount = day.ReceiptID.Count();
                month.Add(day);
            }
        }
        
    }
}
