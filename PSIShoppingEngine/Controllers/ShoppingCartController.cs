using Microsoft.AspNetCore.Mvc;
using PSIShoppingEngine.DTOs.ShoppingCart;
using PSIShoppingEngine.Models;
using PSIShoppingEngine.Services.ShoppingCartService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _ShoppingCartService;

        public ShoppingCartController(IShoppingCartService ShoppingCartService)
        {
            _ShoppingCartService = ShoppingCartService;
        }
        [HttpGet]
        public async Task<IActionResult> ViewShoppingCart(SendShoppingCartDto cart)
        {
            return Ok(await _ShoppingCartService.GetItemList(cart));
        }
        [HttpPost("best")]
        public async Task<IActionResult> BestStore(SendShoppingCartDto cart)
        {
            return Ok(await _ShoppingCartService.BestStore(cart));
        }
        [HttpPost("bestC")]
        public async Task<IActionResult> BestStore([FromQuery(Name = "shops")]Shop[] shop, [FromBody]SendShoppingCartDto cart)
        {
            return Ok(await _ShoppingCartService.BestStoreCustom(shop,cart));
        }
        [HttpGet("deals")]
        public async Task<IActionResult> BestDeals()
        {
            return Ok(await _ShoppingCartService.BestDeal());
        }

    }
}
