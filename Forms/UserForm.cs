using PSIShoppingEngine.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public List<Shop> shops = new List<Shop>();

        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            //Retrieve most frequent shops info:
            UserHelper.RetrieveShopsInfo(shops);


        }
    }
}
