using System;
using System.Text;

namespace ParkingWebTool.Common
{
    public static class LogServiceExtensions
    {
        public static void Debug(this ILogService service, string message, params object[] args)
        {
            Check.ForNullReference(service);

            service.Write(String.Format(message, args), LogSeverity.Debug);
        }
        public static void Trace(this ILogService service, string message, params object[] args)
        {
            Check.ForNullReference(service);

            service.Write(String.Format(message, args), LogSeverity.Trace);
        }
        public static void Info(this ILogService service, string message, params object[] args)
        {
            Check.ForNullReference(service);

            service.Write(String.Format(message, args), LogSeverity.Info);
        }
        public static void Warning(this ILogService service, string message, params object[] args)
        {
            Check.ForNullReference(service);

            service.Write(String.Format(message, args), LogSeverity.Warning);
        }
        public static void Error(this ILogService service, string message, params object[] args)
        {
            Check.ForNullReference(service);

            service.Write(String.Format(message, args), LogSeverity.Error);
        }
        public static void Fatal(this ILogService service, string message, params object[] args)
        {
            Check.ForNullReference(service);

            service.Write(String.Format(message, args), LogSeverity.Fatal);
        }
        public static void Exception(this ILogService service, Exception exception)
        {
            Check.ForNullReference(service, "service");
            Check.ForNullReference(exception, "exception");

            var body = new StringBuilder();
            body.AppendLine();
            body.Append("Unexpected exception was thrown during application work.").AppendLine()
                .AppendFormat("Exception details: {0}", exception).AppendLine().AppendLine();

            service.Write(body.ToString(), LogSeverity.Error);
        }

        public static void Crash(this ILogService service, Exception exception)
        {
            Check.ForNullReference(service, "service");
            Check.ForNullReference(exception, "exception");

            var body = new StringBuilder();
            body.AppendLine();
            body.Append("Fatal exception was thrown during application work. Application is crashed.").AppendLine()
                .AppendFormat("Exception details: {0}", exception).AppendLine().AppendLine();

            service.Write(body.ToString(), LogSeverity.Fatal);
        }

        #region Async methods
        public static void InfoAsync(this ILogService service, string message, params object[] args)
        {
            Check.ForNullReference(service);

            service.WriteAsync(String.Format(message, args), LogSeverity.Info);
        }

        public static void DebugAsync(this ILogService service, string message, params object[] args)
        {
            Check.ForNullReference(service);

            service.WriteAsync(String.Format(message, args), LogSeverity.Debug);
        }
        public static void TraceAsync(this ILogService service, string message, params object[] args)
        {
            Check.ForNullReference(service);

            service.WriteAsync(String.Format(message, args), LogSeverity.Trace);
        }

        public static void WarningAsync(this ILogService service, string message, params object[] args)
        {
            Check.ForNullReference(service);

            service.WriteAsync(String.Format(message, args), LogSeverity.Warning);
        }
        public static void ErrorAsync(this ILogService service, string message, params object[] args)
        {
            Check.ForNullReference(service);

            service.WriteAsync(String.Format(message, args), LogSeverity.Error);
        }
        public static void FatalAsync(this ILogService service, string message, params object[] args)
        {
            Check.ForNullReference(service);

            service.WriteAsync(String.Format(message, args), LogSeverity.Fatal);
        }
        public static void ExceptionAsync(this ILogService service, Exception exception)
        {
            Check.ForNullReference(service, "service");
            Check.ForNullReference(exception, "exception");

            var body = new StringBuilder();
            body.AppendLine();
            body.Append("Unexpected exception was thrown during application work.").AppendLine()
                .AppendFormat("Exception details: {0}", exception).AppendLine().AppendLine();

            service.WriteAsync(body.ToString(), LogSeverity.Error);
        }

        public static void CrashAsync(this ILogService service, Exception exception)
        {
            Check.ForNullReference(service, "service");
            Check.ForNullReference(exception, "exception");

            var body = new StringBuilder();
            body.AppendLine();
            body.Append("Fatal exception was thrown during application work. Application is crashed.").AppendLine()
                .AppendFormat("Exception details: {0}", exception).AppendLine().AppendLine();

            service.WriteAsync(body.ToString(), LogSeverity.Fatal);
        }
        #endregion
    }
}
