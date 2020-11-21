using PSIShoppingEngine.Models;

namespace PSIShoppingEngine.DTOs.UserStats
{
    public class GetFreqItemsDto
    {
        public Item FrequentItem {get; set;}
        public int ItemFrequency {get; set;}
    }
}