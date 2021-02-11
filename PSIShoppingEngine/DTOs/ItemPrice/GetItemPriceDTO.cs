using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.DTOs
{
    public class GetItemPriceDto
    {
        public int Id { get; set; }
        public GetItemDto Item { get; set; }
        public double Price { get; set; }
        public int ReceiptId { get; set; }

    }
}
