using Microsoft.Extensions.Logging;
using System;

namespace FRS.Common
{
    public class DebugLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new DebugLogger();
        }

        public void Dispose()
        {
        }
    }

    internal class DebugLogger : ILogger
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
            /*if (formatter != null)
            {
                var str = formatter(state, exception);
                if (str.Contains("Optimized query model:"))
                    Debug.WriteLine(str);
            }*/

            //TODO
            //if (state is DbCommandLogData)
            //{
            //    var command = (DbCommandLogData)(object)state;
            //    var strBuilder = new StringBuilder(command.CommandText);

            //    foreach (var parameter in command.Parameters.Reverse())
            //    {
            //        strBuilder.Replace(parameter.Name, SqlEncode(parameter.Value));
            //    }

            //    var str = strBuilder.ToString();
            //    RegexHelper.Replace(ref str, @"\[(\w*)\]", m => RegexHelper.Capture(m));
            //    Debug.WriteLine(str);
            //    Debug.WriteLine("    --" + command.ElapsedMilliseconds + " ms\n");
            //}
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
