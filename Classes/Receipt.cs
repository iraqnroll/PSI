using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesseract;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Classes
{
    public class Receipt
    {
        public enum Stores
        {
            Maxima,
            Norfa,
            Lidl,
            Rimi,
            
        }
        public List<Item> Groceries { get; set; }
        public char Currency { get; set; }
        public double TotalPrice { get; set; }
    }
}
