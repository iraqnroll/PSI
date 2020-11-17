using PSIShoppingEngine.DTOs.Reciept;
using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Services.ReceiptService
{
    public interface IReceiptService
    {
        Task<ServiceResponse<List<GetReceiptDto>>> GetAllReceipts();
        Task<ServiceResponse<GetReceiptDto>> GetReceiptById(int id);
        Task<ServiceResponse<List<GetReceiptDto>>> AddReceipt(AddReceiptDto newReceipt);
        Task<ServiceResponse<List<GetReceiptDto>>> DeleteReceipt(int id);
        Task<ServiceResponse<GetReceiptDto>> UpdateReceipt(UpdateReceiptDto newReceipt);
    }
}
