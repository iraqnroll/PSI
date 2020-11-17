using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.DTOs.Reciept
{
    public class GetReceiptDto
    {
        public int Id { get; set; }
        public Shop Shop { get; set; }
        public DateTime Date { get; set; }
        public List<GetItemPriceDto> ItemPrices { get; set; }
    }
}
