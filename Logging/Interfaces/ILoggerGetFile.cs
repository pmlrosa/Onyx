
namespace Logging.Interfaces
{
    public interface ILoggerGetFile
    {
        public StreamWriter GetFile(string path);
    }
}
