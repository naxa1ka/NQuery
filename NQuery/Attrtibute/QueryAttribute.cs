using System;

namespace NQuery
{
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryAttribute : Attribute
    {
        public readonly string Path;
                                         
        public QueryAttribute(string path)
        {
            Path = path;
        }
    }
}