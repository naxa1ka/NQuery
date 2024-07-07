using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace NQuery.Generator
{
    public static class PropertySymbolExtensions
    {
        public static bool HasAttribute(this IPropertySymbol property, INamedTypeSymbol attributeSymbol)
    {
        return property
            .GetAttributes()
            .Select(attributeData => attributeData.AttributeClass)
            .Any(namedTypeSymbol => namedTypeSymbol.AreSymbolsEqual(attributeSymbol));
    }
    
        public static IEnumerable<AttributeData> SelectAttributes(this IPropertySymbol propertySymbol, INamedTypeSymbol attributeSymbol)
    {
        return propertySymbol
            .GetAttributes()
            .Where(attributeData => attributeData.AttributeClass.AreSymbolsEqual(attributeSymbol));
    }
    }
}