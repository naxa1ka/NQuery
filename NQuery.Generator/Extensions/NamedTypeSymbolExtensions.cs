using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace NQuery.Generator
{
    public static class NamedTypeSymbolExtensions
    {
        public static IEnumerable<IPropertySymbol> SelectAttributes(
            this INamedTypeSymbol classSymbol,
            INamedTypeSymbol attributeSymbol
        )
    {
        return classSymbol
            .GetMembers()
            .OfType<IPropertySymbol>()
            .Where(property => property.HasAttribute(attributeSymbol));
    }
    }
}