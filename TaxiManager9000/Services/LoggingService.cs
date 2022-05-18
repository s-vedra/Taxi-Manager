using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LoggingService : ILoggingService
    {
        private string _errorFolderPath = @"..\..\..\Errors";
        private string _errorFilePath = $@"\logs{DateTime.Today.Date.ToString("dd-MM-yyyy")}.log";
        public LoggingService()
        {
            if (!Directory.Exists(_errorFolderPath))
            { 
                Directory.CreateDirectory(_errorFolderPath);
            }
            if (!File.Exists(_errorFolderPath + _errorFilePath))
            {
                File.Create(_errorFolderPath + _errorFilePath).Close();
            }
        }
        public void LogError(string message)
        {
            using (StreamWriter writer = new StreamWriter(_errorFolderPath + _errorFilePath, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
