using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NQuery.Generator
{
    public class QuerySyntaxContextReceiver : ISyntaxContextReceiver
    {
        private readonly List<INamedTypeSymbol> _classesWithQueryProperties = new();

        public IReadOnlyList<INamedTypeSymbol> ClassesWithQueryProperties =>
            _classesWithQueryProperties;

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if (context.Node is not ClassDeclarationSyntax classDeclaration)
                return;
            if (
                context.SemanticModel.GetDeclaredSymbol(classDeclaration)
                is not INamedTypeSymbol classSymbol
            )
                return;
            var compilation = context.SemanticModel.Compilation;
            var viewType = new ViewType(compilation);
            var visualElementType = new VisualElementType(compilation);
            var queryAttributeType = new QueryAttributeType(compilation);
            if (!classSymbol.AllInterfaces.Contains(viewType.NamedTypeSymbol))
                return;
            var propertiesWithQueryAttribute = classSymbol
                .SelectAttributes(queryAttributeType.NamedTypeSymbol)
                .Where(
                    property =>
                        viewType.IsInheritsFrom(property) || visualElementType.IsInheritsFrom(property)
                );
            if (propertiesWithQueryAttribute.Any())
                _classesWithQueryProperties.Add(classSymbol);
        }
    }
}
