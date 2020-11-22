using PSIShoppingEngine.Models;
using PSIShoppingEngine.DTOs.Reciept;
using System.Collections.Generic;
using System;

namespace PSIShoppingEngine.DTOs.UserStats
{
    public class GetShoppingDatesDto
    {
        public DateTime Date {get; set;}
        public int AmountBought {get; set;}
        public List<Shop> ShopsVisited {get; set;}
    }
}