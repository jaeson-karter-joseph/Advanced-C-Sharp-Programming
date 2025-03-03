using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHRAdministration.Generics
{
    public class Generics
    {
        public interface ILogger
        {
            void Log(string message);
        }

        public class FileLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine($"FileLogger: {message}");
            }
        }

        public class ConsoleLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine($"ConsoleLogger: {message}");
            }
        }

        public class LoggerService<T>(T Logger) where T : ILogger
        {
            public void WriteLog(string message)
            {
                Logger.Log(message);
            }
        }

    }
}
