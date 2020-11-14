using Newtonsoft.Json;
using Org.BouncyCastle.Math.EC.Multiplier;
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


        [JsonProperty]
        public string ItemName { get; set; }
        [JsonProperty]
        public ItemType Type { get; set; }
        [JsonProperty]
        public string ItemPrice { get; set; }
    }
}
