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
        public  IActionResult GetAllItems()
        {
            return Ok(_itemService.GetAllItems());
        }

        [HttpPost]
        public IActionResult AddItem(Item newItem)
        {
            return Ok(_itemService.AddItem(newItem));
        }

        [HttpGet("{id}")]
        public IActionResult GetItemById(int id)
        {
            var response = _itemService.GetItemById(id);
            
            if(response == null) 
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
            
        }

        [HttpPut]
        public IActionResult UpdateItem(Item newItem)
        {
            var response = _itemService.UpdateItem(newItem);

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var response = _itemService.DeleteItem(id);

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }


    }
}
