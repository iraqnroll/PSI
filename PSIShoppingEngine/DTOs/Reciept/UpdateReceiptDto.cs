using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.DTOs.Reciept
{
    public class UpdateReceiptDto
    {
        public int Id { get; set; }
        public Shop Shop { get; set; }
       // public int UserId { get; set; }
    }
}
