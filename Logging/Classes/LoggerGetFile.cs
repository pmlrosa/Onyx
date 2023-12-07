using Logging.Interfaces;

namespace Logging.Classes
{
    public class LoggerGetFile : ILoggerGetFile
    {
        public StreamWriter GetFile(string path)
        {
            StreamWriter writer = new StreamWriter(File.Open(path, FileMode.Append))
            {
                AutoFlush = true
            };

            return writer;
        }
    }
}
