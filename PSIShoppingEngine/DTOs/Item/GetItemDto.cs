using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Type = PSIShoppingEngine.Models.Type;

namespace PSIShoppingEngine.DTOs
{
    public class GetItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Type Types { get; set; }

    }
}
