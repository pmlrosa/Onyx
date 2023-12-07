using Logging.Interfaces;

namespace Logging.Classes
{
    public class LoggerGetDate : ILoggerGetDate
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
