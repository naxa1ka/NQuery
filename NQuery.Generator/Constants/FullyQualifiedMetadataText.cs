using Charpoos;

namespace NQuery.Generator
{
    public class FullyQualifiedMetadataText : TextEnvelope
    {
        public FullyQualifiedMetadataText(IText namespaceText, IText classText)
            : base(new Joined(new Dot(), namespaceText, classText)) { }
    }
}
