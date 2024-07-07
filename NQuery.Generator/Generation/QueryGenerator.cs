using System.Text;
using Charpoos;
using Microsoft.CodeAnalysis;

namespace NQuery.Generator
{
    [Generator]
    public class QueryGenerator : ISourceGenerator
    {
        private static IText GeneratedClassPostfix => new TextOfString(".g.cs");
        private static readonly Encoding Encoding = Encoding.UTF8;

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new QuerySyntaxContextReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxContextReceiver is not QuerySyntaxContextReceiver receiver)
                return;
            foreach (var classNamedSymbol in receiver.ClassesWithQueryProperties)
            {
                new ClassWithQueryAttributes(
                    context.Compilation,
                    classNamedSymbol,
                    GeneratedClassPostfix,
                    Encoding
                ).AddAsSource(context);
            }
        }
    }
}
