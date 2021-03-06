﻿using AutoMapper;
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
            try 
            { 
                foreach (var itemId in cart.Cart)
                {
                    var item = await _context.Items.FirstOrDefaultAsync(a => a.Id == itemId);
                    items.Add(_mapper.Map<GetItemDto>(item));
                }

                serviceResponse.Data = items;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCartPricesDto>>> BestStore(SendShoppingCartDto cart)
        {
            ServiceResponse<List<GetCartPricesDto>> serviceResponse = new ServiceResponse<List<GetCartPricesDto>>();
            List<GetCartPricesDto> a = new List<GetCartPricesDto>();
            try
            {

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
                                      }).OrderByDescending(x => x.Date).FirstOrDefaultAsync(x => x.Id == itemID);
                   
                        a.Add(info);
          
                }
                serviceResponse.Data = a;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCartPricesDto>>> BestStoreCustom(Shop[] filter, SendShoppingCartDto cart)
        {
            ServiceResponse<List<GetCartPricesDto>> serviceResponse = new ServiceResponse<List<GetCartPricesDto>>();
            List<GetCartPricesDto> a = new List<GetCartPricesDto>();
            try
            { foreach (var itemID in cart.Cart)
                    {
                        var list = await _context.ItemPrices.Include(x => x.Receipt).Where(x => x.ReceiptId == x.Receipt.Id).Select(x => new GetCartPricesDto
                        {
                            Id = x.ItemId,
                            Price = x.Price,
                            Shop = x.Receipt.Shop,
                            Date = x.Receipt.Date.Date

                        }).ToListAsync();

                        List<GetCartPricesDto> prices = new List<GetCartPricesDto>();
                        foreach (var shop in filter)
                        {
                            var info = list.OrderByDescending(x => x.Date).FirstOrDefault(x => x.Id == itemID && x.Shop == shop);

                           if(info != null) { 
                                prices.Add(info);
                        }

                    }
                        if (prices != null)
                        {
                            var b = prices.OrderBy(x => x.Price).FirstOrDefault();
                            a.Add(b);
                        }
                    }
                    if (a != null)
                    {
                        serviceResponse.Data = a;

                    }
                    else
                    {
                        serviceResponse.Message = "Did not find any item prices";
                        serviceResponse.Success = false;
                    }
                    return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }   
        public async Task<ServiceResponse<List<GetCartPricesDto>>> BestDeal()
        {
            ServiceResponse<List<GetCartPricesDto>> serviceResponse = new ServiceResponse<List<GetCartPricesDto>>();
            try
            {
                {
                    var a = DateTime.UtcNow.Date;
                    var item = await _context.ItemPrices.Include(x => x.Receipt).Where(x => x.ReceiptId == x.Receipt.Id).Select(x => new GetCartPricesDto
                    {
                        Id = x.ItemId,
                        Price = x.Price,
                        Shop = x.Receipt.Shop,
                        Date = x.Receipt.Date.Date

                    }).ToListAsync();

                    var itemYes = item.OrderByDescending(x => x.Date).Distinct().GroupBy(x => new { x.Id, x.Shop }).Where(x => x.Skip(1).Any()).Select(x => new GetCartPricesDto
                    {
                        Id = x.First().Id,
                        Shop = x.First().Shop,
                        Date = x.Skip(1).First().Date,
                        Price = Math.Round((x.Skip(1).First().Price - x.First().Price), 2)
                    }).ToList();
                    if (itemYes != null)
                    {
                        serviceResponse.Data = itemYes;
                        return serviceResponse;
                    }
                    else
                    {
                        serviceResponse.Message = "Did not find any data";
                        serviceResponse.Success = false;
                    }


                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }
    }
}
