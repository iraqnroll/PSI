using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Services.ItemService
{
    public class ItemService : IItemService
    {
        private static readonly List<Item> items = new List<Item> {
            new Item{Id = 1, Name = "Paukstiena", Type = Models.Type.Mesos_gaminiai},
            new Item{Id = 2, Name = "Jautiena", Type = Models.Type.Mesos_gaminiai},
            new Item{Id = 3, Name = "Desreles", Type = Models.Type.Mesos_gaminiai}
        };

        public List<Item> AddItem(Item newItem)
        {
            newItem.Id = items.Select(x => x.Id).Max() + 1;
            items.Add(newItem);

            return items;
        }

        public List<Item> DeleteItem(int id)
        {
            var item = items.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return null;
            }
            else
            {
                items.Remove(item);
            }

            return items;

        }

        public List<Item> GetAllItems()
        {
            return items;
        }

        public Item GetItemById(int id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        public Item UpdateItem(Item newItem)
        {
            var item = items.FirstOrDefault(x => x.Id == newItem.Id);
            if(item == null)
            {
                return item;
            }
            else
            {
                item.Name = newItem.Name;
                item.Type = newItem.Type;
            }

            return item;
        }
    }
}
