using System;
using NLog;

namespace ParkingWebTool.Common
{
    public class TextLogger : ILogService
    {
        private readonly Logger _nLogSyncLogger = LogManager.GetCurrentClassLogger();
        private readonly Logger _nLogAsyncLogger = LogManager.GetLogger("AsyncLogger");

        public void Write(string message, LogSeverity severity)
        {
            Check.ForEmptyString(message);
            Check.ForNullReference(message);

            Log(severity, _nLogSyncLogger)(message);
        }

        public void WriteAsync(string message, LogSeverity severity)
        {
            Check.ForEmptyString(message);
            Check.ForNullReference(message);

            Log(severity, _nLogAsyncLogger)(message);
        }

        private Action<String> Log(LogSeverity severity, Logger logger)
        {
            switch (severity)
            {
                case LogSeverity.Info:
                    return logger.Info;
                case LogSeverity.Trace:
                    return logger.Trace;
                case LogSeverity.Warning:
                    return logger.Warn;
                case LogSeverity.Debug:
                    return logger.Debug;
                case LogSeverity.Error:
                    return logger.Error;
                case LogSeverity.Fatal:
                    return logger.Fatal;
                default:
                    throw new NotSupportedException("Unsupported type of severity");
            }
        }

    }
}
