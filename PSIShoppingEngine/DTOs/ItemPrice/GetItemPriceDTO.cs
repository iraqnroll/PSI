using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.DTOs
{
    public class GetItemPriceDTO
    {
        public int Id { get; set; }
        public GetItemDto ItemId { get; set; }
        public int Price { get; set; }
        public int ReceiptId { get; set; }

    }
}
