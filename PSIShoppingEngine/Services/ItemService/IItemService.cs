using PSIShoppingEngine.DTOs;
using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Services.ItemService
{
    public interface IItemService
    {
        Task<ServiceResponse<List<GetItemDto>>> GetAllItems();
        Task<ServiceResponse<GetItemDto>> GetItemById(int id);
        Task<ServiceResponse<List<GetItemDto>>> AddItem(AddItemDto newItem);
        Task<ServiceResponse<List<GetItemDto>>> DeleteItem(int id);
        Task<ServiceResponse<GetItemDto>> UpdateItem(AddItemDto newItem);
    }
}
