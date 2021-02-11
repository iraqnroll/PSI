using Microsoft.EntityFrameworkCore;
using PSIShoppingEngine.DTOs;
using PSIShoppingEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ItemPrice> ItemPrices { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
    }
}
