using PSIShoppingEngine.Models;

namespace PSIShoppingEngine.DTOs.UserStats
{
    public class GetFreqShopsDto
    {
        public Shop FrequentShop {get; set;}
        public int ShopFrequency {get; set;}
        public double MoneySpent {get; set;}
    }
}