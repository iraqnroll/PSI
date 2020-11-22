using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSIShoppingEngine.DTOs;
using PSIShoppingEngine.DTOs.ItemPrice;
using PSIShoppingEngine.Services.ItemPriceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [ApiController]
    [Route("[controller]")]
    public class ItemPriceController : ControllerBase
    {
        private readonly IItemPriceService _itemPriceService;

        public ItemPriceController(IItemPriceService itemPriceService)
        {
            _itemPriceService = itemPriceService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllItemPrices()
        {
            return Ok(await _itemPriceService.GetAllItemPrices());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemPriceById(int id)
        {
            var serviceResponse = await _itemPriceService.GetItemPriceById(id);

            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            else
            {
                return Ok(serviceResponse);
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddItemPrice(AddItemPriceDto newItemPrice)
        {
            var serviceResponse = await _itemPriceService.AddItemPrice(newItemPrice);

            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            else
            {
                return Ok(serviceResponse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemPrice(int id)
        {
            var serviceResponse = await _itemPriceService.DeleteItemPrice(id);

            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            else
            {
                return Ok(serviceResponse);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItemPrice(UpdateItemPriceDto newItemPrice)
        {
            var serviceResponse = await _itemPriceService.UpdateItemPrice(newItemPrice);

            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            else
            {
                return Ok(serviceResponse);
            }
        }

    }
}
