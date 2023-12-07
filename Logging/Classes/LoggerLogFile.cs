using Logging.Interfaces;

namespace Logging.Classes
{
    public class LoggerLogFile : ILoggerLogFile
    {
        public ILoggerGetDate LoggerGetDate { get; }

        public LoggerLogFile(ILoggerGetDate loggerGetDate)
        {
            LoggerGetDate = loggerGetDate;
        }

        public void Log(string str, StreamWriter writer)
        {
            writer.WriteLine(string.Format("[{0:dd.MM.yy HH:mm:ss}] {1}", 
                LoggerGetDate.GetCurrentDate(), str));
        }
    }
}
