using Microsoft.CodeAnalysis;

namespace NQuery.Generator
{
    public class ViewType : IType
    {
        private readonly NamedTypeEnvelope _inner;

        public INamedTypeSymbol NamedTypeSymbol => _inner.NamedTypeSymbol;

        public ViewType(Compilation compilation)
        {
            _inner = new NamedTypeEnvelope(compilation, new ViewTypeName());
        }

        public bool IsInheritsFrom(IPropertySymbol property) => _inner.IsInheritsFrom(property);
    }
}