using PSIShoppingEngine.DTOs;
using PSIShoppingEngine.DTOs.ItemPrice;
using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Services.ItemPriceService
{
    public interface IItemPriceService
    {
        Task<ServiceResponse<List<GetItemPriceDto>>> GetAllItemPrices();
        Task<ServiceResponse<GetItemPriceDto>> GetItemPriceById(int id);
        Task<ServiceResponse<List<GetItemPriceDto>>> AddItemPrice(AddItemPriceDto newItemPrice);
        Task<ServiceResponse<List<GetItemPriceDto>>> DeleteItemPrice(int id);
        Task<ServiceResponse<GetItemPriceDto>> UpdateItemPrice(UpdateItemPriceDto newItemPrice);
        Task<ServiceResponse<GetPriceOfItemDto>> GetAllPricesOfItem(int id);
    }
}
