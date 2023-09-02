using log4net;
using log4net.Config;
using System.Reflection;

namespace EP.Srv.Cliente.LogUtility
{
    public class LoggerHelper : ILoggerHelper
    {
        private readonly ILog _logger;

        public LoggerHelper()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()!.DeclaringType);
        }

        public void Debug(string message) => _logger.Debug(message);

        public void Info(string message)
        {
            try
            {
                _logger.Info(message);
            }
            catch(Exception ex)
            {

            }
            
        }

        public void Error(string message, Exception? ex = null) => _logger.Error(message, ex?.InnerException);
    }
}