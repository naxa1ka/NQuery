using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace NQuery.Generator
{
    public class TargetClass
    {
        private readonly INamedTypeSymbol _classSymbol;
        private readonly QueryAttributeType _queryAttributeType;

        public IEnumerable<PropertyWithQueryAttribute> QueryAttributes =>
            _classSymbol
                .SelectAttributes(_queryAttributeType.NamedTypeSymbol)
                .Select(
                    propertySymbol =>
                        new PropertyWithQueryAttribute(propertySymbol, _queryAttributeType)
                );

        public TargetClass(INamedTypeSymbol classSymbol, QueryAttributeType queryAttributeType)
    {
        _queryAttributeType = queryAttributeType;
        _classSymbol = classSymbol;
    }
    }
}