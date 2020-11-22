using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PSIShoppingEngine.Data;
using PSIShoppingEngine.DTOs;
using PSIShoppingEngine.DTOs.ItemPrice;
using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace PSIShoppingEngine.Services.ItemPriceService
{
    public class ItemPriceService : IItemPriceService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ItemPriceService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;

        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        private string GetUserRole() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);

        public async Task<ServiceResponse<List<GetItemPriceDto>>> AddItemPrice(AddItemPriceDto newItemPrice)
        {
            ServiceResponse<List<GetItemPriceDto>> serviceResponse = new ServiceResponse<List<GetItemPriceDto>>();

            var item =  await _context.Items.FirstOrDefaultAsync(x => x.Id == newItemPrice.ItemId);
            var receipt = await _context.Receipts.FirstOrDefaultAsync(x => x.Id == newItemPrice.ReceiptId);

            if(item == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Item not found";
                return serviceResponse;
            }

            if (receipt == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Receipt not found";
                return serviceResponse;
            }
            
            var itemprice = _mapper.Map<ItemPrice>(newItemPrice);
            itemprice.Receipt.UserId = GetUserId();

            await _context.ItemPrices.AddAsync(itemprice);
            await _context.SaveChangesAsync();

            return await GetAllItemPrices();
        }

        public async Task<ServiceResponse<List<GetItemPriceDto>>> DeleteItemPrice(int id)
        {
            ServiceResponse<List<GetItemPriceDto>> serviceResponse = new ServiceResponse<List<GetItemPriceDto>>();
            var itemPrice = await _context.ItemPrices.FirstOrDefaultAsync(x => x.Id == id && x.Receipt.UserId == GetUserId());
            if(itemPrice == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Item price not found";
                return serviceResponse;
            }

            _context.ItemPrices.Remove(itemPrice);
            await _context.SaveChangesAsync();

            return await GetAllItemPrices();
        }

        public async Task<ServiceResponse<List<GetItemPriceDto>>> GetAllItemPrices()
        {
            ServiceResponse<List<GetItemPriceDto>> serviceResponse = new ServiceResponse<List<GetItemPriceDto>>();
            List<ItemPrice> itemPrices =
                GetUserRole().Equals("Admin") ?
                await _context.ItemPrices.Include(x => x.Item).ToListAsync() :
                await _context.ItemPrices.Include(x => x.Item).Where(c => c.Receipt.UserId == GetUserId()).ToListAsync();
            serviceResponse.Data = (itemPrices.Select(x => _mapper.Map<GetItemPriceDto>(x))).ToList();

            return serviceResponse;
        }


        public async Task<ServiceResponse<GetItemPriceDto>> GetItemPriceById(int id)
        {
            ServiceResponse<GetItemPriceDto> serviceResponse = new ServiceResponse<GetItemPriceDto>();
            var itemPrice = await _context.ItemPrices.Include(x => x.Item).FirstOrDefaultAsync(x => x.Id == id && x.Receipt.UserId == GetUserId());

            if(itemPrice != null)
            {
                serviceResponse.Data = _mapper.Map<GetItemPriceDto>(itemPrice);
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Could not found ItemPrice";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetItemPriceDto>> UpdateItemPrice(UpdateItemPriceDto newItemPrice)
        {
            ServiceResponse<GetItemPriceDto> serviceResponse = new ServiceResponse<GetItemPriceDto>();

            var itemprice = await _context.ItemPrices.FirstOrDefaultAsync(x => x.Id == newItemPrice.Id && x.Receipt.UserId == GetUserId());

            if (itemprice == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "ItemPrice not found";
                return serviceResponse;
            }


            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == newItemPrice.ItemId);
            var receipt = await _context.Receipts.FirstOrDefaultAsync(x => x.Id == newItemPrice.ReceiptId);

            if (item == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Item not found";
                return serviceResponse;
            }

            if (receipt == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Receipt not found";
                return serviceResponse;
            }

           
            itemprice.Item = item;
            itemprice.Receipt = receipt;
            itemprice.Price = newItemPrice.Price;

            _context.ItemPrices.Update(itemprice);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetItemPriceDto>(itemprice);

            return serviceResponse;

        }
    }
}
