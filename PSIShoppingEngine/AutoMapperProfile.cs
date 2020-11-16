using AutoMapper;
using PSIShoppingEngine.Data;
using PSIShoppingEngine.DTOs;
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

        }   
    }
}
