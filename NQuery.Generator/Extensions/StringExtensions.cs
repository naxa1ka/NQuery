using Charpoos;

namespace NQuery.Generator
{
    public static class StringExtensions
    {
        public static IText AsText(this string str) => new TextOfString(str);
    }
}