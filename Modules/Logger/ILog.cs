using System;

namespace Draper.Logger
{
    public enum LogTrace
    {
        na,
        Entry,
        Exit
    }

    public enum LogLevel
    {
        Trace = 1,
        Info = 2,
        Warning = 3,
        Error = 4,
        Critical = 5
    }

    public interface ILog
    {
        void TraceEntry(string className, string methodName);

        void TraceExit(string className, string methodName);

        void Info(string className, string methodName, string message);

        void Warning(string className, string methodName, string message);

        void Error(string className, string methodName, string message, Exception ex);

        void Error(string className, string methodName, Exception ex);

        void Critical(string className, string methodName, string message, Exception ex);
    }
}
