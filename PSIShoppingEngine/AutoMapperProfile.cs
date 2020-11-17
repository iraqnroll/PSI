using AutoMapper;
using PSIShoppingEngine.Data;
using PSIShoppingEngine.DTOs;
using PSIShoppingEngine.DTOs.Reciept;
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
            CreateMap<AddReceiptDto, Receipt>();
        }   
    }
}
