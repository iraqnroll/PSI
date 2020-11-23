using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Services.LoggerService
{
    public static class ConsoleLogger 
    {
        
        public static void Log(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
