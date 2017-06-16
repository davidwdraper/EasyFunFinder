using EasyFunFinder.Data.Logger;
using System;

namespace Draper.Logger
{
    public class Log : ILog
    {
        protected LoggerContext _dc;
        protected string _moduleName;
        protected string _userID = null;

        public Log(string moduleName)
        {
            _dc = new LoggerContext();
            _moduleName = moduleName;
        }

        public Log(string moduleName, string userID) : this(moduleName)
        {
            _userID = userID;
        }

        public void Critical(string className, string methodName, string message, Exception ex)
        {
            Insert(LogLevel.Critical, className, methodName, message, ex);
        }

        public void Error(string className, string methodName, Exception ex)
        {
            Insert(LogLevel.Error, className, methodName, string.Empty, ex);
        }

        public void Error(string className, string methodName, string message, Exception ex)
        {
            Insert(LogLevel.Error, className, methodName, message, ex);
        }

        public void Info(string className, string methodName, string message)
        {
            Insert(LogLevel.Info, className, methodName, message);
        }

        public void TraceEntry(string className, string methodName)
        {
            Insert(LogLevel.Trace, className, methodName, string.Empty, null, LogTrace.Entry);
        }

        public void TraceExit(string className, string methodName)
        {
            Insert(LogLevel.Trace, className, methodName, string.Empty, null, LogTrace.Exit);
        }

        public void Warning(string className, string methodName, string message)
        {
            Insert(LogLevel.Warning, className, methodName, message, null, LogTrace.na);
        }

        protected void Insert(LogLevel category, string className, string methodName, string message, Exception ex = null, LogTrace traceType = LogTrace.na)
        {
            var logger = new LogEntry
            {
                TraceType = traceType == LogTrace.na ? null : (int?)traceType,
                CategoryId = (int)category,
                UserId = _userID,
                ModuleName = _moduleName,
                ClassName = className,
                MethodName = methodName,
                Message = message,
                ExceptionText = ex?.ToString(),
                EntryDateTime = DateTime.UtcNow
            };
            _dc.Add(logger);
            _dc.SaveChanges();
        }
    }
}