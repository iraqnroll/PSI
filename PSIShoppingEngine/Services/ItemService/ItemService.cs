using Microsoft.EntityFrameworkCore;
using PSIShoppingEngine.Data;
using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Services.ItemService
{
    public class ItemService : IItemService
    {
       

        private readonly DataContext _context;

        public ItemService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Item>>> AddItem(Item newItem)
        {
            ServiceResponse<List<Item>> serviceResponse = new ServiceResponse<List<Item>>();

            await _context.Items.AddAsync(new Item {Name = newItem.Name, Type = newItem.Type });
            await _context.SaveChangesAsync();
            List<Item> items = await _context.Items.ToListAsync();
            serviceResponse.Data = items;

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Item>>> DeleteItem(int id)
        {
            ServiceResponse<List<Item>> serviceResponse = new ServiceResponse<List<Item>>();

            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if(item == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Item not found";
                
            }
            else
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Items.ToListAsync();
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Item>>> GetAllItems()
        {
            ServiceResponse<List<Item>> serviceResponse = new ServiceResponse<List<Item>>();
            List<Item> items = await _context.Items.ToListAsync();
            serviceResponse.Data = items;

            return serviceResponse;

        }
        public async Task<ServiceResponse<Item>> GetItemById(int id)
        {
            ServiceResponse<Item> serviceResponse = new ServiceResponse<Item>();

            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if(item == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Item not found";
                return serviceResponse;
            }

            serviceResponse.Data = item;
            return serviceResponse;

        }

        public async Task<ServiceResponse<Item>> UpdateItem(Item newItem)
        {
            ServiceResponse<Item> serviceResponse = new ServiceResponse<Item>();
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == newItem.Id);

            if(item == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Item not found";

            }
            else
            {
                item.Name = newItem.Name;
                item.Type = newItem.Type;
                 _context.Items.Update(item);
                await _context.SaveChangesAsync();

                serviceResponse.Data = item;
            }

            return serviceResponse;
        }
    }
}
