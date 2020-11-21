using PSIShoppingEngine.DTOs;
using PSIShoppingEngine.DTOs.Reciept;
using PSIShoppingEngine.DTOs.ShoppingCart;
using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Services.ShoppingCartService
{
    public interface IShoppingCartService
    {
        Task<ServiceResponse<List<GetItemDto>>> GetItemList(SendShoppingCartDto cart);
        Task<ServiceResponse<List<GetCartPricesDto>>> BestStore(SendShoppingCartDto cart);

        Task<ServiceResponse<List<GetCartPricesDto>>> BestStoreCustom(Shop[] filter, SendShoppingCartDto cart);
    }
}
