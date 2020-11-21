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
            var Items = await _context.ItemPrices.Where(b => ReceiptIDs.Contains((int)b.ReceiptId)).Select(b => b.Item).ToListAsync();

            var DtoItems = Items.GroupBy(x => x).Select(g => new GetFreqItemsDto { FrequentItem = g.Key, ItemFrequency = g.Count()}).ToList();
            serviceResponse.Data = DtoItems;
            return serviceResponse;
        }
        async public Task<ServiceResponse<List<GetFreqShopsDto>>> GetFrequentShops()
        {
            ServiceResponse<List<GetFreqShopsDto>> serviceResponse = new ServiceResponse<List<GetFreqShopsDto>>();
            var Shops = await _context.Receipts.Where(b => b.User.Id == GetUserId()).Select(b => b.Shop).ToListAsync();
            var DtoShops = Shops.GroupBy(x => x).Select(g => new GetFreqShopsDto {FrequentShop = g.Key, ShopFrequency = g.Count()}).ToList();

            serviceResponse.Data = DtoShops;
            return serviceResponse;
        }
    }
}