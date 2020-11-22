using System;
using System.Collections.Generic;

namespace PSIShoppingEngine.Models
{
    public class UserStats
    {
       public Shop FrequentShop {get; set;}
       public int ShopFrequency {get; set;}
       public Item FrequentItem {get; set;}
       public int ItemFrequency {get; set;}
       public User User {get; set;}
    }
}