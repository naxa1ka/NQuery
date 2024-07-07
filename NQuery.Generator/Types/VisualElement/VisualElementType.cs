using Microsoft.CodeAnalysis;

namespace NQuery.Generator
{
    public class VisualElementType : IType
    {
        private readonly NamedTypeEnvelope _inner;

        public INamedTypeSymbol NamedTypeSymbol => _inner.NamedTypeSymbol;

        public VisualElementType(Compilation compilation)
        {
            _inner = new NamedTypeEnvelope(compilation, new VisualElementTypeName());
        }

        public bool IsInheritsFrom(IPropertySymbol property) => _inner.IsInheritsFrom(property);
    }
}
