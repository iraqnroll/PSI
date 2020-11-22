using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PSIShoppingEngine.Data;
using PSIShoppingEngine.DTOs.UserStats;
using PSIShoppingEngine.DTOs;
using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MoreLinq;

namespace PSIShoppingEngine.Services.UserStatsService
{
    public class UserStatsService : IUserStatsService
    {
        private readonly DataContext _context;
        public delegate int GetId();
        public GetId GetUserId;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper; 
        
        public UserStatsService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            GetUserId = delegate(){
                return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            };
        }

        async public Task<ServiceResponse<List<GetFreqItemsDto>>> GetFrequentItems()
        {
            ServiceResponse<List<GetFreqItemsDto>> serviceResponse = new ServiceResponse<List<GetFreqItemsDto>>();
            
            var ReceiptIDs = await _context.Receipts.Where(b => b.User.Id == GetUserId()).Select(b => b.Id).ToListAsync();
            var Items = await _context.ItemPrices.Where(b => ReceiptIDs.Contains((int)b.ReceiptId)).Select(x => new {x.Item, x.Price}).ToListAsync();

            var DtoItems = Items.GroupBy(x => x.Item).Select(g => new GetFreqItemsDto { FrequentItem = _mapper.Map<GetItemDto>(g.Key), ItemFrequency = g.Count(), MoneySpent = g.Sum(x => x.Price)}).ToList();
            serviceResponse.Data = DtoItems;
            return serviceResponse;
        }
        async public Task<ServiceResponse<List<GetFreqShopsDto>>> GetFrequentShops()
        {
            ServiceResponse<List<GetFreqShopsDto>> serviceResponse = new ServiceResponse<List<GetFreqShopsDto>>();
            var ReceiptIDs = await _context.Receipts.Where(b => b.User.Id == GetUserId()).Select(b => b.Id).ToListAsync();
            var GroupedItemPrices = await _context.ItemPrices.Where(x => ReceiptIDs.Contains((int)x.ReceiptId)).GroupBy(x => x.ReceiptId).Select(g => new {ReceiptId = (int)g.Key, MoneySpent = g.Sum(x => x.Price)}).ToListAsync();

            var Shops = await _context.Receipts.Where(x => ReceiptIDs.Contains((int)x.Id)).Select(g => new {Shop = g.Shop, ReceiptId = g.Id }).ToListAsync();
            var GroupedShops = Shops.Where(x => Shops.Any(c => c.ReceiptId == x.ReceiptId)).Select(g => new {Shop = g.Shop, ReceiptId = g.ReceiptId, ShopFrequency = Shops.Where(x => g.Shop == x.Shop).Count()});

            var DtoShops = GroupedItemPrices.Join(GroupedShops,
            price => price.ReceiptId,
            shop => shop.ReceiptId,
            (price, shop) => 
                new GetFreqShopsDto {FrequentShop = shop.Shop, MoneySpent = price.MoneySpent, ShopFrequency = shop.ShopFrequency}).ToList();

            serviceResponse.Data = DtoShops;
            return serviceResponse;
        }
        async public Task<ServiceResponse<List<GetShoppingDatesDto>>> GetShoppingDates()
        {
            ServiceResponse<List<GetShoppingDatesDto>> serviceResponse = new ServiceResponse<List<GetShoppingDatesDto>>();
            var Dates = await _context.Receipts.Where(b => b.User.Id == GetUserId()).Select(g => new {Date = g.Date, ItemPrices = g.ItemPrices, Shop = g.Shop}).ToListAsync();
            var DtoDates = Dates.GroupBy(x => x.Date).Select(g => new GetShoppingDatesDto { Date = g.Key, AmountBought = g.Sum(x => x.ItemPrices.Count()), ShopsVisited = g.Select(x => x.Shop).ToList()}).ToList();
            serviceResponse.Data = DtoDates;

            return serviceResponse;
        }
    }
}