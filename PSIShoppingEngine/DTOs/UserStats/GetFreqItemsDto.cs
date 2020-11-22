using PSIShoppingEngine.Models;

namespace PSIShoppingEngine.DTOs.UserStats
{
    public class GetFreqItemsDto
    {
        public GetItemDto FrequentItem {get; set;}
        public int ItemFrequency {get; set;}
        public double MoneySpent {get; set;}
    }
}