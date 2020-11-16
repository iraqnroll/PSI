using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Models
{
    public class ItemPrice
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Price { get; set; }
        public int ReceiptId { get; set; }
        public Receipt Receipt { get; set; }

    }
}
