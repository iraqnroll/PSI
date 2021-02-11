using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSIShoppingEngine.DTOs.Reciept;
using PSIShoppingEngine.Models;
using PSIShoppingEngine.Services.ReceiptService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [ApiController]
    [Route("[controller]")]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllReceipts()
        {
            return Ok(await _receiptService.GetAllReceipts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceiptById(int id)
        {
            var serviceResponse = await _receiptService.GetReceiptById(id);

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
        public async Task<IActionResult> AddReceipt(AddReceiptDto newReceipt)
        {
            var serviceResponse = await _receiptService.AddReceipt(newReceipt);

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
        public async Task<IActionResult> AddReceipt(int id)
        {
            ServiceResponse<List<GetReceiptDto>> response = await _receiptService.DeleteReceipt(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }
            else
            {
                return Ok(response);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateReceipt(UpdateReceiptDto newReceipt)
        {
             ServiceResponse<GetReceiptDto> response = await _receiptService.UpdateReceipt(newReceipt);

            if (response.Data == null)
            {
                return NotFound(response);
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
