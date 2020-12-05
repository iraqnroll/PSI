using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.DTOs.ShoppingCart
{
    public class GetCartPricesDto
    {
        public int Id { get; set; }
        public Shop Shop { get; set; }
        public DateTime Date { get; set; }
        public Double Price { get; set; }
    }
}
