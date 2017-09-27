using System;
using System.Text.RegularExpressions;

namespace FRS.Common
{
    public class RegexHelper
    {
        public static void Replace(ref string str, string pattern, string replacement)
        {
            var regex = new Regex(pattern);
            str = regex.Replace(str, replacement);
        }

        public static void Replace(ref string str, string pattern, MatchEvaluator evaluator)
        {
            var regex = new Regex(pattern);
            str = regex.Replace(str, evaluator);
        }

        public static string Capture(Match m)
        {
            if (m.Groups[1].Captures.Count > 1)
                throw new Exception();

            return m.Groups[1].Value;
        }
    }
}
