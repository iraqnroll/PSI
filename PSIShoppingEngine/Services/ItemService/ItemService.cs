using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PSIShoppingEngine.Data;
using PSIShoppingEngine.DTOs;
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
        private readonly IMapper _mapper;
        public ItemService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
            
        }

        public async Task<ServiceResponse<List<GetItemDto>>> AddItem(AddItemDto newItem)
        {
            ServiceResponse<List<GetItemDto>> serviceResponse = new ServiceResponse<List<GetItemDto>>();

            await _context.Items.AddAsync(_mapper.Map<Item>(newItem));
            await _context.SaveChangesAsync();
            List<GetItemDto> items = await (_context.Items.Select(c => _mapper.Map<GetItemDto>(c))).ToListAsync();
            serviceResponse.Data = items;

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetItemDto>>> DeleteItem(int id)
        {
            ServiceResponse<List<GetItemDto>> serviceResponse = new ServiceResponse<List<GetItemDto>>();

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
                serviceResponse.Data = await (_context.Items.Select(c => _mapper.Map<GetItemDto>(c))).ToListAsync();
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetItemDto>>> GetAllItems()
        {
            ServiceResponse<List<GetItemDto>> serviceResponse = new ServiceResponse<List<GetItemDto>>();
            List<Item> items = await _context.Items.ToListAsync();
            serviceResponse.Data = await (_context.Items.Select(c => _mapper.Map<GetItemDto>(c))).ToListAsync();

            return serviceResponse;

        }
        public async Task<ServiceResponse<GetItemDto>> GetItemById(int id)
        {
            ServiceResponse<GetItemDto> serviceResponse = new ServiceResponse<GetItemDto>();

            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if(item == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Item not found";
                return serviceResponse;
            }

            serviceResponse.Data = _mapper.Map<GetItemDto>(item);
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetItemDto>> UpdateItem(AddItemDto newItem)
        {
            ServiceResponse<GetItemDto> serviceResponse = new ServiceResponse<GetItemDto>();
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == _mapper.Map<Item>(newItem).Id);

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

                serviceResponse.Data = _mapper.Map<GetItemDto>(item);
            }

            return serviceResponse;
        }
    }
}
