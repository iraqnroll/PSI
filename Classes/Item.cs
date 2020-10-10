using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Classes
{
    
    public class Item
    {
        public enum ItemType
        {
            Electronics,
            Meat,
            Dairy,
            Beverage,
            Pastry,
            Vegetables,
            Other
        }
        public string ItemName { get; set; }
        public ItemType Type { get; set; }
        public string ItemPrice { get; set; }
    }
}
