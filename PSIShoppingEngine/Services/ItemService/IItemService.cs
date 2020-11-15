using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Services.ItemService
{
    public interface IItemService
    {
        Task<ServiceResponse<List<Item>>> GetAllItems();
        Task<ServiceResponse<Item>> GetItemById(int id);
        Task<ServiceResponse<List<Item>>> AddItem(Item newItem);
        Task<ServiceResponse<List<Item>>> DeleteItem(int id);
        Task<ServiceResponse<Item>> UpdateItem(Item newItem);

    }
}
