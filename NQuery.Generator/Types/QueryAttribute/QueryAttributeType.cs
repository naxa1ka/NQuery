using Microsoft.CodeAnalysis;

namespace NQuery.Generator
{
    public class QueryAttributeType : IType
    {
        private readonly NamedTypeEnvelope _inner;

        public INamedTypeSymbol NamedTypeSymbol => _inner.NamedTypeSymbol;

        public QueryAttributeType(Compilation compilation)
        {
            _inner = new NamedTypeEnvelope(compilation, new QueryAttributeTypeName());
        }

        public bool IsInheritsFrom(IPropertySymbol property) => _inner.IsInheritsFrom(property);
    }
}
