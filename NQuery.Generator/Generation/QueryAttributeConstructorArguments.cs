using Charpoos;
using Microsoft.CodeAnalysis;

namespace NQuery.Generator
{
    public class QueryAttributeConstructorArguments
    {
        private readonly AttributeData _attributeData;
        public IText Path => new TextOfString((string)_attributeData.ConstructorArguments[0].Value!);

        public QueryAttributeConstructorArguments(AttributeData attributeData)
        {
            _attributeData = attributeData;
        }
    }
}