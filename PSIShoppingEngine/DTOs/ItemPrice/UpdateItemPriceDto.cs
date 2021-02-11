using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.DTOs.ItemPrice
{
    public class UpdateItemPriceDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public double Price { get; set; }
        public int ReceiptId { get; set; }
    }
}
