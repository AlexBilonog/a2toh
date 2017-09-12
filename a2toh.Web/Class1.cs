using System.Text.RegularExpressions;

namespace Project2
{
    class Class1
    {
        void F()
        {
            var group = new Regex(@"\..*").Replace("asdfa.sadfasd", "");
        }
    }
}
