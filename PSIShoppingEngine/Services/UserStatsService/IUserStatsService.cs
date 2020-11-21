using System.Threading.Tasks;
using PSIShoppingEngine.DTOs.UserStats;
using System.Collections.Generic;
using PSIShoppingEngine.Models;

namespace PSIShoppingEngine.Services.UserStatsService
{
    public interface IUserStatsService
    {
         Task<ServiceResponse<List<GetFreqItemsDto>>> GetFrequentItems();
         Task<ServiceResponse<List<GetFreqShopsDto>>> GetFrequentShops();
    }
}