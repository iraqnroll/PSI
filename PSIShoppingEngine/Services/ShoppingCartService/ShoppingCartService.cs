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
            foreach (var itemId in cart.Cart)
            {
                var item = await _context.Items.FirstOrDefaultAsync(a => a.Id == itemId);
                items.Add(_mapper.Map<GetItemDto>(item));
            }

            serviceResponse.Data = items;
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCartPricesDto>>> BestStore(SendShoppingCartDto cart)
        {
            ServiceResponse<List<GetCartPricesDto>> serviceResponse = new ServiceResponse<List<GetCartPricesDto>>();
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
                                  }).OrderByDescending(x => x.Date).FirstOrDefaultAsync(x => x.Id == itemID);
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
        public async Task<ServiceResponse<List<GetCartPricesDto>>> BestDeal()
        {
            /*
                    SELECT Pnew.ref
            , Pnew.storeid
            , Pnew.mgr
            , Pnew.price as `NewPrice
            , Pold.price as `OldPrice
        FROM prices Pnew
        INNER JOIN prices Pold
            ON Pnew.ref = Pold.ref
                AND DATE(Pnew.datetime) = CURDATE()
                AND DATE(Pold.datetime) = SUBDATE(CURDATE(), 1)
        WHERE Pnew.price<> Pold.price;*/
            ServiceResponse<List<GetCartPricesDto>> serviceResponse = new ServiceResponse<List<GetCartPricesDto>>();
            {
                var a = DateTime.UtcNow.Date;
                var item = await (from price in _context.ItemPrices
                                  join rec in _context.Receipts on price.ReceiptId equals rec.Id
                                  select new GetCartPricesDto
                                  {
                                      Id = price.ItemId,
                                      Price = price.Price,
                                      Date = rec.Date.Date,
                                      Shop = rec.Shop
                                  }).ToListAsync();
                //  var itemNow = item.Where(x => x.Date == a).Distinct().ToList();
                /*  var itemYes = item.Where(x => x.Date < a).OrderByDescending(x => x.Date).Distinct().ToList();
                  var prices = (from price in itemNow
                                join rec in itemYes on new { shop = price.Shop, itemId = price.Id } equals new { shop = rec.Shop, itemId = rec.Id }
                                select new GetCartPricesDto
                                {
                                        Id = price.Id,
                                        Price = price.Price - rec.Price,
                                        Date = rec.Date,
                                        Shop = rec.Shop
                                }).GroupBy(x => x.Id).Select(y => y.FirstOrDefault()).ToList();*/
                var itemYes = item.OrderByDescending(x => x.Date).Distinct().GroupBy(x => new { x.Id, x.Shop }).Where(x => x.Skip(1).Any()).Select(x => new GetCartPricesDto
                {
                    Id = x.First().Id,
                    Shop = x.First().Shop,
                    Date = x.Skip(1).First().Date,
                    Price = Math.Round((x.Skip(1).First().Price - x.First().Price),2)
                }).ToList();
                

                serviceResponse.Data = itemYes;
                return serviceResponse;


            }

        }
    }
}
