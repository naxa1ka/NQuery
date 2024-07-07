using Microsoft.CodeAnalysis;

namespace NQuery.Generator
{
    public static class SymbolExtensions
    {
        public static bool AreSymbolsEqual(this ISymbol? symbol, ISymbol? other) =>
            SymbolEqualityComparer.Default.Equals(symbol, other);
    }
}