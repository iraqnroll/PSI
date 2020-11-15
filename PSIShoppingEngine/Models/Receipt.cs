using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public Shop Shop { get; set; }
        public DateTime Date { get; set; }
        public List<ItemPrice> ItemPrices { get; set; }
    }
}
