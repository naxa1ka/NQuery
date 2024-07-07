using System.Linq;
using System.Text;
using Charpoos;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using NQuery.Generator.Keywords;

namespace NQuery.Generator
{
    public class ClassWithQueryAttributes
    {
        private readonly INamedTypeSymbol _classSymbol;
        private readonly Compilation _compilation;
        private readonly IText _generatedClassPostfix;
        private readonly Encoding _encoding;

        public ClassWithQueryAttributes(
            Compilation compilation,
            INamedTypeSymbol classNamedSymbol,
            IText generatedClassPostfix,
            Encoding encoding
        )
        {
            _encoding = encoding;
            _generatedClassPostfix = generatedClassPostfix;
            _compilation = compilation;
            _classSymbol = classNamedSymbol;
        }

        public void AddAsSource(GeneratorExecutionContext context)
        {
            new SourceCode(
                new TextOfString(_classSymbol.Name),
                _generatedClassPostfix,
                SourceCode(),
                _encoding
            ).AddTo(context);
        }

        private IText SourceCode()
        {
            var namespaceName = _classSymbol.ContainingNamespace.ToDisplayString();
            var className = _classSymbol.Name;
            const string quotationMark = "\"";
            const string initializeMethodName = "InitializeComponents";
            const string queryElementMethodName = "Q";
            const string contextParam = "_uiDocument";

            var queryAttributeType = new QueryAttributeType(_compilation);
            var targetClass = new TargetClass(_classSymbol, queryAttributeType);
            return new Joined(
                new NextLine(),
                new Concatenated(new NamespaceKeyword(), new Space(), new TextOfString(namespaceName)),
                new OpeningCurlyBracket(),
                new Concatenated(
                    new Tab(),
                    new PublicKeyword(),
                    new Space(),
                    new PartialKeyword(),
                    new Space(),
                    new ClassKeyword(),
                    new Space(),
                    new TextOfString(className)
                ),
                new Concatenated(new Tab(), new OpeningCurlyBracket()),
                new Concatenated(
                    new Repeated(new Tab(), 2),
                    new PublicKeyword(),
                    new Space(),
                    new VoidKeyword(),
                    new Space(),
                    new TextOfString(initializeMethodName),
                    new OpeningBracket(),
                    new ClosingBracket()
                ),
                new Concatenated(new Repeated(new Tab(), 2), new OpeningCurlyBracket()),
                new Joined(
                    new NextLine(),
                    targetClass.QueryAttributes.Select(
                        property =>
                            new Concatenated(
                                new Repeated(new Tab(), 3),
                                new TextOfString(property.Name),
                                new Space(),
                                new Equal(),
                                new Space(),
                                new TextOfString(contextParam),
                                new Dot(),
                                new TextOfString(queryElementMethodName),
                                new OpeningBracket(),
                                new TextOfString(quotationMark),
                                property.Path,
                                new TextOfString(quotationMark),
                                new ClosingBracket(),
                                new Semicolon()
                            )
                    )
                ),
                new Concatenated(new Repeated(new Tab(), 2), new ClosingCurlyBracket()),
                new Concatenated(new Tab(), new ClosingCurlyBracket()),
                new ClosingCurlyBracket()
            );
        }
    }
}
