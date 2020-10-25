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
        public static int RetrieveShopFrequency(int shopID)
        {
            string sqlQuery = "SELECT COUNT(shop_id) FROM receipts WHERE shop_id = " + shopID;
            SQLiteCommand command = new SQLiteCommand(sqlQuery, DbHelper.myConnection);
            int result = Convert.ToInt32(command.ExecuteScalar());
            return result;
        }
        public static void RetrieveShopsInfo(List<Forms.UserForm.Shop>shopList)
        {
            DbHelper.OpenConnection();
            string sqlQuery = "SELECT * FROM shops";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, DbHelper.myConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Forms.UserForm.Shop shop = new Forms.UserForm.Shop();
                shop.ShopName = (string)reader["shop_name"];
                shop.shopID = Convert.ToInt32(reader["shop_id"]);
                shop.ReceiptCount = RetrieveShopFrequency(shop.shopID);
                shopList.Add(shop);
            }
            reader.Close();
            DbHelper.CloseConnection();
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
            DbHelper.OpenConnection();
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
        
    }
}
