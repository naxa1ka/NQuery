using Microsoft.CodeAnalysis;

namespace NQuery.Generator
{
    public interface IType
    {
        INamedTypeSymbol NamedTypeSymbol { get; }
        bool IsInheritsFrom(IPropertySymbol property);
    }
}