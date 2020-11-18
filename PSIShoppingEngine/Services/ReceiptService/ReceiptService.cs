using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PSIShoppingEngine.Data;
using PSIShoppingEngine.DTOs.Reciept;
using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Services.ReceiptService
{
    public class ReceiptService : IReceiptService
    {

        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public ReceiptService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        async public Task<ServiceResponse<List<GetReceiptDto>>> AddReceipt(AddReceiptDto newReceipt)
        {
            ServiceResponse<List<GetReceiptDto>> serviceResponse = new ServiceResponse<List<GetReceiptDto>>();
            
            var receipt = _mapper.Map<Receipt>(newReceipt);
            await _context.Receipts.AddAsync(receipt);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Receipts.Where(c => c.User.Id == GetUserId()).Select(c => _mapper.Map<GetReceiptDto>(c))).ToList();
            return serviceResponse;
        }

        async public Task<ServiceResponse<List<GetReceiptDto>>> DeleteReceipt(int id)
        {
            ServiceResponse<List<GetReceiptDto>> serviceResponse = new ServiceResponse<List<GetReceiptDto>>();

            try
            {
                var receipt = await _context.Receipts.FirstOrDefaultAsync(x => x.Id == id && x.User.Id == GetUserId());
                if (receipt != null)
                {
                    _context.Receipts.Remove(receipt);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = (_context.Receipts.Where(c => c.User.Id ==  GetUserId())
                    .Select(c => _mapper.Map<GetReceiptDto>(c))).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Receipt not found.";
                }
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }

        async public Task<ServiceResponse<List<GetReceiptDto>>> GetAllReceipts()
        {
            ServiceResponse<List<GetReceiptDto>> serviceResponse = new ServiceResponse<List<GetReceiptDto>>();
            try
            {
                var receipts = await _context.Receipts.Include(x => x.ItemPrices).ThenInclude(xs => xs.Item).Where(c => c.User.Id == GetUserId()).ToListAsync();
                if (receipts != null)
                {
                    serviceResponse.Data = receipts.Select(x => _mapper.Map<GetReceiptDto>(x)).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Receipts not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
       
        async public Task<ServiceResponse<GetReceiptDto>> GetReceiptById(int id)
        {
            ServiceResponse<GetReceiptDto> serviceResponse = new ServiceResponse<GetReceiptDto>();
            try
            {
                var receipt = await _context.Receipts.Include(x => x.ItemPrices).ThenInclude(xs => xs.Item).FirstOrDefaultAsync(x => x.Id == id && x.User.Id == GetUserId());
                if (receipt != null)
                {
                    serviceResponse.Data = _mapper.Map<GetReceiptDto>(receipt);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Receipt not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        async public Task<ServiceResponse<GetReceiptDto>> UpdateReceipt(UpdateReceiptDto newReceipt)
        {
            ServiceResponse<GetReceiptDto> serviceResponse = new ServiceResponse<GetReceiptDto>();
            try
            {
                var receipt = await _context.Receipts.Include(x => x.ItemPrices).ThenInclude(xs => xs.Item).FirstOrDefaultAsync(x => x.Id == newReceipt.Id && x.User.Id == GetUserId());
                if (receipt != null)
                {
                    receipt.Shop = newReceipt.Shop;
                    _context.Receipts.Update(receipt);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _mapper.Map<GetReceiptDto>(receipt);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Receipt not found.";
                }
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
