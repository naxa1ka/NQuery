using Charpoos;
using Microsoft.CodeAnalysis;

namespace NQuery.Generator
{
    public class NamedTypeEnvelope : IType
    {
        private readonly Compilation _compilation;
        private readonly IText _classText;

        public INamedTypeSymbol NamedTypeSymbol =>
            _compilation.MetadataNameOrThrowException(
                new FullyQualifiedMetadataText(new QueryNamespace(), _classText)
            );

        public NamedTypeEnvelope(Compilation compilation, IText classText)
        {
            _compilation = compilation;
            _classText = classText;
        }

        public bool IsInheritsFrom(IPropertySymbol property)
        {
            var typeSymbolInner = property.Type;
            while (typeSymbolInner != null)
            {
                if (property.Type.AreSymbolsEqual(NamedTypeSymbol))
                    return true;
                typeSymbolInner = typeSymbolInner.BaseType;
            }
            return false;
        }
    }
}