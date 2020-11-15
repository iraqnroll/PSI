using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Services.ItemService
{
    public interface IItemService
    {
        List<Item> GetAllItems();
        Item GetItemById(int id);
        List<Item> AddItem(Item newItem);
        List<Item> DeleteItem(int id);
        Item UpdateItem(Item newItem);

    }
}
