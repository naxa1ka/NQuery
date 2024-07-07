using System;
using System.Text;
using Charpoos;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace NQuery.Generator
{
    public class SourceCode
    {
        private readonly Lazy<IText> _hintName;
        private readonly Lazy<SourceText> _sourceText;

        public SourceCode(IText className, IText generatedPostfix, IText sourceCode, Encoding encoding)
            : this(new Concatenated(className, generatedPostfix), sourceCode, encoding) { }

        public SourceCode(IText hintName, IText sourceCode, Encoding encoding)
            : this(() => hintName, () => SourceText.From(sourceCode.AsString(), encoding)) { }

        public SourceCode(IText hintName, SourceText sourceText)
            : this(() => hintName, () => sourceText) { }

        public SourceCode(Func<IText> hintName, Func<SourceText> sourceText)
            : this(new Lazy<IText>(hintName), new Lazy<SourceText>(sourceText)) { }

        private SourceCode(Lazy<IText> hintName, Lazy<SourceText> sourceText)
    {
        _hintName = hintName;
        _sourceText = sourceText;
    }

        public void AddTo(GeneratorExecutionContext context)
    {
        context.AddSource(
            _hintName.Value.AsString(),
            _sourceText.Value
        );
    }
    }
}
