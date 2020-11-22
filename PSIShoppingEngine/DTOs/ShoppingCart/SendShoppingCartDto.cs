using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.DTOs.ShoppingCart
{
    public class SendShoppingCartDto
    {
        public List<int> Cart { get; set; }
    }
}
