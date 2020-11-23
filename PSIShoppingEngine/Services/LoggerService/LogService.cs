using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSIShoppingEngine.Services.LoggerService
{
    public class LogService : ILogService
    {
        public  event Action<string> OnLogEvent;

        public void startLogging(string message)
        {
            OnLogEvent?.Invoke(message);
        }
    }
}
