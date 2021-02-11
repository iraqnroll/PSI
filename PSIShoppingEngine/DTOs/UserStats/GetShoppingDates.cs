using PSIShoppingEngine.Models;
using PSIShoppingEngine.DTOs.Reciept;
using System.Collections.Generic;
using System;

namespace PSIShoppingEngine.DTOs.UserStats
{
    public struct visitedShops
    {
        public Shop shop { get; set; }
        public int Amount { get; set; }
    }
    public class GetShoppingDatesDto
    {
        public DateTime Date {get; set;}
        public List<visitedShops> ShopsVisited {get; set;}
    }
}