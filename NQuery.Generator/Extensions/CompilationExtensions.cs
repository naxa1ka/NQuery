using System;
using Charpoos;
using Microsoft.CodeAnalysis;

namespace NQuery.Generator
{
    public static class CompilationExtensions
    {
        public static INamedTypeSymbol GetTypeByMetadataNameOrThrowException(this Compilation compilation, string fullyQualifiedMetadataName)
        {
            var namedTypeSymbol = compilation.GetTypeByMetadataName(fullyQualifiedMetadataName);
            if (namedTypeSymbol == null)
                throw new ArgumentNullException(nameof(fullyQualifiedMetadataName));
            return namedTypeSymbol;
        }

        public static INamedTypeSymbol MetadataNameOrThrowException(this Compilation compilation,
            IText fullyQualifiedMetadataText)
        {
            var fullyQualifiedMetadataName = fullyQualifiedMetadataText.AsString();
            var namedTypeSymbol = compilation.GetTypeByMetadataName(fullyQualifiedMetadataName);
            if (namedTypeSymbol == null)
                throw new ArgumentNullException(nameof(fullyQualifiedMetadataName));
            return namedTypeSymbol;
        }
    }
}