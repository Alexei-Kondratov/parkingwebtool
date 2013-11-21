
namespace ParkingWebTool.Common
{
    public interface ILogService
    {
        void Write(string message, LogSeverity severity);
        void WriteAsync(string message, LogSeverity severity);
    }
}
