namespace SchoolHRAdministration.DelegateFunction
{
    public class EnterpriseLoggingDemo
    {
        public delegate void LogHandler(string message);

        public class Logger(LogHandler _logHandler)
        {
            public void Log(string message)
            {
                _logHandler?.Invoke(message);
            }
        }

        public static void ConsoleLog(string message)
        {
            Console.WriteLine(message);
        }

        public static void FileLog(string message)
        {
            File.AppendAllText("App.Log", message + Environment.NewLine);
        }
    }
}
