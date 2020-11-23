using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Services.LoggerService
{
    public interface ILogService
    {
        public event Action<string> OnLogEvent;
        void startLogging(string message);
    }  
}
