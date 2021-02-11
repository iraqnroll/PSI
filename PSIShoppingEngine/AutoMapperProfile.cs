using AutoMapper;
using PSIShoppingEngine.Data;
using PSIShoppingEngine.DTOs;
using PSIShoppingEngine.DTOs.Reciept;
using PSIShoppingEngine.DTOs.User;
using PSIShoppingEngine.DTOs.ShoppingCart;
using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Item, GetItemDto>();
            CreateMap<AddItemDto, Item>();
            CreateMap<ItemPrice, GetItemPriceDto>();
            CreateMap<AddItemPriceDto, ItemPrice>();
            CreateMap<Receipt, GetReceiptDto>();
            //CreateMap<Receipt, GetCartPricesDto>().ForMember(x => x.Price, cd => cd.MapFrom(a => a.ItemPrices.FirstOrDefault().Price));
            CreateMap<AddReceiptDto, Receipt>();
            CreateMap<GetUserDto, User>();
            CreateMap<User, GetUserDto>();
        }   
    }
}
