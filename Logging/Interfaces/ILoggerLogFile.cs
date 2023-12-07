
namespace Logging.Interfaces
{
    public interface ILoggerLogFile
    {
        public void Log(string str, StreamWriter writer);
    }
}
