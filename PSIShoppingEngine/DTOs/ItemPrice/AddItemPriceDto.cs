using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.DTOs
{
    public class AddItemPriceDto
    {
        public int ItemId { get; set; }
        public double Price { get; set; }
        public int ReceiptId { get; set; }

    }
}
