using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace FRS.Common
{
    public class CustomDebugLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new CustomDebugLogger();
        }

        public void Dispose()
        {
        }
    }

    internal class CustomDebugLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return new FakeDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (state.GetType().Name.StartsWith("LogValues`") || logLevel.In(LogLevel.Warning, LogLevel.Error, LogLevel.Critical))
            {
                var str = formatter(state, exception);
                if (str.StartsWith("Sending file. Request path") ||
                    str.StartsWith("Executing") ||
                    str.StartsWith("Entity Framework Core"))
                    return;

                if (str.StartsWith("Executed DbCommand"))
                {
                    str = "\nInformation: " + str + "\n";
                }
                RegexHelper.Replace(ref str, @"\[(\w*)\]", m => RegexHelper.Capture(m));
                Debug.WriteLine(str);
            }
        }

        private static string SqlEncode(object value)
        {
            if (value == null)
                return "null";
            else if (value is DBNull)
                return "null";
            else if (value is DateTime?)
                return "'" + ((DateTime?)value).Value.ToString("yyyy-MM-ddThh:mm:ss.fff") + "'";
            else if (value is string)
                return "N'" + value.ToString().Replace("'", "''") + "'";
            else if (value is Enum)
                return (int)value + "/*" + value + "*/";
            else // bool, int
            {
                var s = value.ToString();
                if (s == "True")
                    s = "1";
                if (s == "False")
                    s = "0";
                return s;
            }
        }
    }

    internal class FakeDisposable : IDisposable
    {
        public void Dispose()
        {
        }
    }
}
