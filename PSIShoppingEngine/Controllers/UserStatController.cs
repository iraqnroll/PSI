using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSIShoppingEngine.DTOs.UserStats;
using PSIShoppingEngine.Models;
using PSIShoppingEngine.Services.UserStatsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Controllers
{
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("[controller]")]
    public class UserStatController : ControllerBase
    {
        private readonly IUserStatsService _statsService;

        public UserStatController(IUserStatsService statsService)
        {
            _statsService = statsService;
        }

        [HttpGet("Shops")]
        public async Task<IActionResult> GetFrequentShops()
        {
            return Ok(await _statsService.GetFrequentShops());
        }
        [HttpGet("Items")]
        public async Task<IActionResult> GetFrequentItems()
        {
            return Ok(await _statsService.GetFrequentItems());
        }
        [HttpGet("Dates")]
        public async Task<IActionResult> GetShoppingDates()
        {
            return Ok(await _statsService.GetShoppingDates());
        }
    }
}