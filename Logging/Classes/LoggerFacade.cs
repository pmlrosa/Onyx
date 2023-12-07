using Logging.Interfaces;

namespace Logging.Classes
{
    public class LoggerFacade : ILoggerFacade
    {        
        public ILoggerGetFile LoggerGetFile { get; }

        public ILoggerLogFile LoggerLogFile { get; }

        public IGetFilePath GetFilePath { get; }

        public string FilePath { get; private set; }

        public LoggerFacade(ILoggerGetFile loggerGetFile, 
            ILoggerLogFile loggerLogFile, IGetFilePath getFilePath)
        {
            LoggerGetFile = loggerGetFile;
            LoggerLogFile = loggerLogFile;
            GetFilePath = getFilePath;
            FilePath = GetFilePath.GetFilePath();
            LogMessage("Logger initialized");
        }

        public void LogMessage(string str)
        {
            StreamWriter writer = LoggerGetFile.GetFile(FilePath);
            LoggerLogFile.Log(str, writer);
            if (writer != null)
                writer.Close();
        }
    }
}
