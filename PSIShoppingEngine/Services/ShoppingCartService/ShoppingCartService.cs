using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PSIShoppingEngine.Data;
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
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ShoppingCartService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<ServiceResponse<List<GetItemDto>>> GetItemList(SendShoppingCartDto cart)
        {
            ServiceResponse<List<GetItemDto>> serviceResponse = new ServiceResponse<List<GetItemDto>>();

            List<GetItemDto> items = new List<GetItemDto>();
            foreach(var itemId in cart.Cart)
            {
                var item = await _context.Items.FirstOrDefaultAsync(a => a.Id == itemId);
                items.Add(_mapper.Map<GetItemDto>(item));
            }
            
            serviceResponse.Data = items;
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCartPricesDto>>> BestStore(SendShoppingCartDto cart)
        {
            ServiceResponse < List <GetCartPricesDto >>serviceResponse = new ServiceResponse<List<GetCartPricesDto>>();
            List<GetCartPricesDto> a = new List<GetCartPricesDto>();
            foreach (var itemID in cart.Cart)
            {
                var info = await (from price in _context.ItemPrices
                            join rec in _context.Receipts on price.ReceiptId equals rec.Id
                            select new GetCartPricesDto
                            {
                                Id = price.ItemId,
                                Price = price.Price,
                                Date = rec.Date,
                                Shop = rec.Shop
                            }).OrderByDescending(x => x.Date).FirstOrDefaultAsync( x => x.Id == itemID);
                if (info != null)
                {
                    a.Add(info);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Could not find specified item price";
                    return serviceResponse;
                }
            }
            serviceResponse.Data = a;
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCartPricesDto>>> BestStoreCustom(Shop[] filter, SendShoppingCartDto cart)
        {
            ServiceResponse<List<GetCartPricesDto>> serviceResponse = new ServiceResponse<List<GetCartPricesDto>>();
            List<GetCartPricesDto> a = new List<GetCartPricesDto>();
            foreach (var itemID in cart.Cart)
            {
                var list = (from price in _context.ItemPrices
                                   join rec in _context.Receipts on price.ReceiptId equals rec.Id
                                   select new GetCartPricesDto
                                   {
                                       Id = price.ItemId,
                                       Price = price.Price,
                                       Date = rec.Date,
                                       Shop = rec.Shop
                                   });
                List<GetCartPricesDto> prices = new List<GetCartPricesDto>();
                foreach (var shop in filter)
                {
                    var info = await list.OrderByDescending(x => x.Date).FirstOrDefaultAsync(x => x.Id == itemID && x.Shop == shop);

                    if (info != null)
                    {
                        prices.Add(info);
                    }
                }
                var b = prices.OrderBy(x => x.Price).FirstOrDefault();
                a.Add(b);


            }
            serviceResponse.Data = a;
            return serviceResponse;
        }

    }
}
