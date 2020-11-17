using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PSIShoppingEngine.Data;
using PSIShoppingEngine.DTOs.Reciept;
using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Services.ReceiptService
{
    public class ReceiptService : IReceiptService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ReceiptService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;

        }
        async public Task<ServiceResponse<List<GetReceiptDto>>> AddReceipt(AddReceiptDto newReceipt)
        {
            ServiceResponse<List<GetReceiptDto>> serviceResponse = new ServiceResponse<List<GetReceiptDto>>();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == newReceipt.UserId);

            if(user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User nor found";
                return serviceResponse;
            }

            var receipt = _mapper.Map<Receipt>(newReceipt);
            await _context.Receipts.AddAsync(receipt);
            await _context.SaveChangesAsync();

            return await GetAllReceipts();
        }

        async public Task<ServiceResponse<List<GetReceiptDto>>> DeleteReceipt(int id)
        {
            ServiceResponse<List<GetReceiptDto>> serviceResponse = new ServiceResponse<List<GetReceiptDto>>();
            var receipt = await _context.Receipts.FirstOrDefaultAsync(x => x.Id == id);
            if (receipt == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Receipt not found";
                return serviceResponse;
            }
             _context.Receipts.Remove(receipt);
            await _context.SaveChangesAsync();

            return await GetAllReceipts();

        }

        async public Task<ServiceResponse<List<GetReceiptDto>>> GetAllReceipts()
        {
            ServiceResponse<List<GetReceiptDto>> serviceResponse = new ServiceResponse<List<GetReceiptDto>>();

            var receipts = await _context.Receipts.Include(x => x.ItemPrices).ThenInclude(xs => xs.Item).ToListAsync();
            serviceResponse.Data = receipts.Select(x => _mapper.Map<GetReceiptDto>(x)).ToList();

            return serviceResponse;
        }

        async public Task<ServiceResponse<GetReceiptDto>> GetReceiptById(int id)
        {
            ServiceResponse<GetReceiptDto> serviceResponse = new ServiceResponse<GetReceiptDto>();
            var receipt = await _context.Receipts.Include(x => x.ItemPrices).ThenInclude(xs => xs.Item).FirstOrDefaultAsync(x => x.Id == id);

            if(receipt == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Receipt not found";
                return serviceResponse;
            }
            serviceResponse.Data = _mapper.Map<GetReceiptDto>(receipt);

            return serviceResponse;
           
        }

        async public Task<ServiceResponse<GetReceiptDto>> UpdateReceipt(UpdateReceiptDto newReceipt)
        {
            ServiceResponse<GetReceiptDto> serviceResponse = new ServiceResponse<GetReceiptDto>();
            var receipt = await _context.Receipts.Include(x => x.ItemPrices).ThenInclude(xs => xs.Item).FirstOrDefaultAsync(x => x.Id == newReceipt.Id);
            if(receipt == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Receipt not found";
                return serviceResponse;
            }

            receipt.Shop = newReceipt.Shop;
             _context.Receipts.Update(receipt);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetReceiptDto>(receipt);

            return serviceResponse;
        }
    }
}
