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
using System.Diagnostics;
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
            var userReceipts = await _context.Receipts.Where(b => b.User.Id == GetUserId()).ToListAsync();
            var GroupedReceipts = userReceipts.GroupBy(x => x.Shop);
            var freqShopsDto = new List<GetFreqShopsDto>();

            foreach(IGrouping<Shop, Receipt> grp in GroupedReceipts)
            {
                var freqShop = new GetFreqShopsDto();
                freqShop.FrequentShop = grp.Key;
                freqShop.ShopFrequency = grp.Count();
                foreach(Receipt rec in grp)
                {
                    var ItemPrices = await _context.ItemPrices.Where(b => b.ReceiptId == rec.Id).ToListAsync();
                    if (ItemPrices != null)
                    {
                        freqShop.MoneySpent += ItemPrices.Sum(x => x.Price);
                    }
                    else freqShop.MoneySpent += 0;
                }
                freqShopsDto.Add(freqShop);
            }

            serviceResponse.Data = freqShopsDto;
            return serviceResponse;
        }
        async public Task<ServiceResponse<List<GetShoppingDatesDto>>> GetShoppingDates()
        {
            ServiceResponse<List<GetShoppingDatesDto>> serviceResponse = new ServiceResponse<List<GetShoppingDatesDto>>();
            var userReceipts = await _context.Receipts.Where(b => b.User.Id == GetUserId()).ToListAsync();
            var groupedReceipts = userReceipts.GroupBy(x => x.Date.Date);
            var shoppingDatesDto = new List<GetShoppingDatesDto>();

            foreach(IGrouping<DateTime, Receipt> grp in groupedReceipts)
            {
                var shopDate = new GetShoppingDatesDto();
                shopDate.Date = grp.Key;
                shopDate.ShopsVisited = new List<visitedShops>();

                var receiptsInDate = userReceipts.Where(x => x.Date.Date == grp.Key).GroupBy(x => x.Shop);
                foreach(IGrouping<Shop, Receipt> recgrp in receiptsInDate)
                {
                    var visitedShop = new visitedShops();
                    visitedShop.shop = recgrp.Key;
                    visitedShop.Amount = recgrp.Count();
                    shopDate.ShopsVisited.Add(visitedShop);
                }
                shoppingDatesDto.Add(shopDate);
            }
            serviceResponse.Data = shoppingDatesDto;
            return serviceResponse;
        }
    }
}