using System;
using NLog;

namespace Task1.Library
{
    class NloggerAdapter : ILogger
    {
        private Logger logger = new Logger();

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            logger.Error(message, exception)
        }

        public void Fatal(string message)
        {
            logger.Error(message);
        }

        public void Fatal(string message, Exception exception)
        {
            logger.Fatal(message, exception);
        }
    }
}
