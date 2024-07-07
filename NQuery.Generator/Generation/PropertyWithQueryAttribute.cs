using System.Linq;
using Charpoos;
using Microsoft.CodeAnalysis;

namespace NQuery.Generator
{
    public class PropertyWithQueryAttribute
    {
        private readonly IPropertySymbol _property;
        private readonly QueryAttributeType _queryAttributeType;

        private AttributeData AttributeData =>
            _property
                .SelectAttributes(_queryAttributeType.NamedTypeSymbol).Single();
        private QueryAttributeConstructorArguments ConstructorArguments => new(AttributeData);

        public string Name => _property.Name;
        public IText Path => ConstructorArguments.Path;

        public PropertyWithQueryAttribute(
            IPropertySymbol property,
            QueryAttributeType queryAttributeType
        )
    {
        _queryAttributeType = queryAttributeType;
        _property = property;
    }
    }
}