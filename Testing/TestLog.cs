using Logging.Classes;
using Logging.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Testing
{
    public class TestLog
    {
        public LoggerFacade LoggerFacade { get; set; }

        public Mock<ILoggerGetDate> LoggerGetDateMock { get; set; }
        
        public Mock<ILoggerGetFile> LoggerGetFileMock { get; set; }
        
        public Mock<ILoggerLogFile> LoggerLogFileMock { get; set; }

        [SetUp]
        public void Setup()
        {
            LoggerGetFileMock = new Mock<ILoggerGetFile>();
            LoggerLogFileMock = new Mock<ILoggerLogFile>();
            LoggerGetDateMock = new Mock<ILoggerGetDate>();

            ServiceCollection sc = new ServiceCollection();
            sc.AddScoped<IGetFilePath, GetDefaultFilePath>();
            sc.AddScoped(q => LoggerGetDateMock.Object);
            sc.AddScoped<ILoggerFacade, LoggerFacade>();            

            IServiceProvider sp = sc.BuildServiceProvider();

            LoggerFacade = new LoggerFacade(LoggerGetFileMock.Object,
                LoggerLogFileMock.Object, sp.GetService<IGetFilePath>());
        }

        [Test]
        public void TestLogStartsWithDateAndTime()
        {
            LoggerFacade.LogMessage("Write something");
            Assert.Pass();
        }
    }
}