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

namespace PSIShoppingEngine.Forms
{
    public partial class UserForm : Form
    {
        public struct Shop
        {
            public string ShopName { get; set; }
            public int shopID { get; set; }
            public int ReceiptCount { get; set; }
        }

        public struct Item
        {
            public string ItemName { get; set; }
            public int ItemID { get; set; }
            public int ItemCount { get; set; }
        }

        public List<Shop> shops = new List<Shop>();
        public List<Item> items = new List<Item>();

        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            //Retrieve most frequent shops info:
            UserHelper.RetrieveShopsInfo(shops);

            /*foreach(var shop in shops)
            {
                Debug.WriteLine(shop.ShopName + " - " + shop.ReceiptCount);
            }*/

            //Retrieve 5 most frequent products:
            UserHelper.RetrieveItemList(items, shops);

            /*foreach(var item in items)
            {
               if(item.ItemCount > 0)Debug.WriteLine(item.ItemName + " - " + item.ItemCount);
            }*/
        }
    }
}
