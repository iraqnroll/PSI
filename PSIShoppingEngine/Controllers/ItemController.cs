using Microsoft.AspNetCore.Mvc;
using PSIShoppingEngine.Models;
using PSIShoppingEngine.Services.ItemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllItems()
        {
            return Ok(await _itemService.GetAllItems());
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(Item newItem)
        {
            return Ok(await _itemService.AddItem(newItem));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var serviceResponse = await _itemService.GetItemById(id);
            
            if(serviceResponse.Success == false) 
            {
                return NotFound(serviceResponse);
            }
            else
            {
                return Ok(serviceResponse);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(Item newItem)
        {
            var serviceResponse = await _itemService.UpdateItem(newItem);

            if (serviceResponse == null)
            {
                return NotFound(serviceResponse);
            }
            else
            {
                return Ok(serviceResponse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var serviceResponse = await _itemService.DeleteItem(id);

            if (serviceResponse == null)
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
