using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Services
{
    public class ExceptionService : Exception
    {
        private StackTrace _stackTrace = new StackTrace();
        private LoggingService loggingService = new LoggingService();
        public string Error { get; set; }
        public ExceptionService(string error)
        {
            Error = error + _stackTrace;
            loggingService.LogError(Error);
        }
    }
}
