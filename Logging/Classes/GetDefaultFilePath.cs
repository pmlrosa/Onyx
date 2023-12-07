using Logging.Interfaces;

namespace Logging.Classes
{
    public class GetDefaultFilePath : IGetFilePath
    {
        public string GetFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt");
        }
    }
}
