using FRS.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace FRS.Common
{
    public static class CodeHelpers
    {
        public static bool In<T>(this T obj, params T[] arguments)
        {
            return arguments.Any(a => a.Equals(obj));
        }

        public static bool In(this int obj, params Enum[] arguments)
        {
            return arguments.Cast<int>().Any(a => a.Equals(obj));
        }

        public static bool In(this int? obj, params Enum[] arguments)
        {
            return arguments.Cast<int>().Cast<int?>().Any(a => a.Equals(obj));
        }

        public static bool Between<T>(this IComparable<T> val, T fromVal, T toVal)
        {
            return
                val.CompareTo(fromVal) >= 0 &&
                val.CompareTo(toVal) <= 0;
        }

        public static bool Between(this IComparable val, IComparable fromVal, IComparable toVal)
        {
            return
                val.CompareTo(fromVal) >= 0 &&
                val.CompareTo(toVal) <= 0;
        }

        public static T CloneSimpleProperties<T>(this T source, bool copyId = true) where T : class
        {
            var dest = (T)Activator.CreateInstance(source.GetType());
            source.CopySimplePropertiesTo(dest, copyId);
            return dest;
        }

        public static void CopySimplePropertiesTo<TSource, TDest>(this TSource source, TDest dest, bool copyId = true, bool copyEmpty = true)
        {
            var sourceProps = source.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance);
            var destProps = dest.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance);

            foreach (var sourceProp in sourceProps)
            {
                if (!copyId && GetNormName(sourceProp.Name) == "Id") continue;
                if (sourceProp.PropertyType.GetInterfaces().Contains(typeof(IEntity))) continue;
                if (sourceProp.PropertyType.IsGenericType &&
                    (sourceProp.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) ||
                    sourceProp.PropertyType.GetGenericTypeDefinition() == typeof(IList<>)))
                    continue;

                var destProp = destProps.FirstOrDefault(r =>
                    GetNormName(r.Name) == GetNormName(sourceProp.Name) && r.CanWrite && (
                        r.PropertyType == sourceProp.PropertyType ||
                        Nullable.GetUnderlyingType(r.PropertyType) == sourceProp.PropertyType
                    ));

                if (destProp == null) continue;

                var sourceValue = sourceProp.GetValue(source);

                if (!copyEmpty)
                {
                    if (sourceValue == null ||
                        sourceValue is string && string.IsNullOrWhiteSpace((string)sourceValue))
                        continue;
                }

                destProp.SetValue(dest, sourceValue, null);
            }
        }

        private static string GetNormName(string name)
        {
            return name.EndsWith("ID")
                ? name.Substring(0, name.Length - 2) + "Id"
                : name;
        }

        public static void TrimStringPropertiesToNull<T>(IEnumerable<T> objects)
        {
            var props = typeof(T)
                .GetProperties(BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance)
                .Where(r => r.PropertyType == typeof(string))
                .ToList();

            foreach (var obj in objects)
            {
                foreach (var prop in props)
                {
                    var value = (string)prop.GetValue(obj);
                    if (value == null)
                        continue;

                    prop.SetValue(obj, value.TrimToNull());
                }
            }
        }

        public static T Convert<T>(this object source)
        {
            var underType = Nullable.GetUnderlyingType(typeof(T));
            return (source == null && underType != null) // if it's nullable type, then default value is null
                ? default(T)
                : (T)System.Convert.ChangeType(source, underType ?? typeof(T));
        }

        public static T ConvertOrDefault<T>(this object source)
        {
            var dest = default(T);
            if (source == null)
                return dest;
            try
            {
                dest = Convert<T>(source);
            }
            catch
            {
            }
            return dest;
        }

        /// <summary>Works with "null" values</summary>
        public static string SafeTrim(this string s)
        {
            if (s != null)
                s = s.Trim();

            return s;
        }

        /// <summary>Works with "null" values. And trims empty to "null"</summary>
        public static string TrimToNull(this string s)
        {
            if (s != null)
                s = s.Trim();

            if (s == "")
                return null;

            return s;
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static string Format(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static SqlTransaction GetTransaction(this IDbConnection conn)
        {
            var connectionInfo = typeof(SqlConnection).GetProperty("InnerConnection", BindingFlags.NonPublic | BindingFlags.Instance);
            var internalConn = connectionInfo.GetValue(conn, null);
            var currentTransactionProperty = internalConn.GetType().GetProperty("CurrentTransaction", BindingFlags.NonPublic | BindingFlags.Instance);
            var currentTransaction = currentTransactionProperty.GetValue(internalConn, null);
            var realTransactionProperty = currentTransaction.GetType().GetProperty("Parent", BindingFlags.NonPublic | BindingFlags.Instance);
            var realTransaction = realTransactionProperty.GetValue(currentTransaction, null);
            return (SqlTransaction)realTransaction;
        }

        /// <summary>Works with "null" values</summary>
        public static bool SafeContains(this string s, string value)
        {
            if (s == null)
                return false;

            return s.Contains(value);
        }

        //http://stackoverflow.com/questions/1044688/add-business-days-and-getbusinessdays
        public static int GetWorkingDaysCountInDateRange(DateTime startDate, DateTime endDate)
        {
            switch (startDate.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    startDate = startDate.AddDays(2);
                    break;
                case DayOfWeek.Sunday:
                    startDate = startDate.AddDays(1);
                    break;
            }

            switch (endDate.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    endDate = endDate.AddDays(-1);
                    break;
                case DayOfWeek.Sunday:
                    endDate = endDate.AddDays(-2);
                    break;
            }

            var diff = (int)endDate.Subtract(startDate).TotalDays;

            var result = diff / 7 * 5 + diff % 7;

            if (endDate.DayOfWeek < startDate.DayOfWeek)
            {
                return result - 2;
            }

            return result;
        }

        public static string NormalizeEmailPart(this string s)
        {
            if (s == null)
                return s;

            s = s.ToLower();
            RegexHelper.Replace(ref s, @"\s", "-");
            RegexHelper.Replace(ref s, @"\.", "");
            RegexHelper.Replace(ref s, "ü", "ue");
            RegexHelper.Replace(ref s, "ä", "ae");
            RegexHelper.Replace(ref s, "ö", "oe");
            RegexHelper.Replace(ref s, "ß", "ss");
            return s;
        }
    }
}
