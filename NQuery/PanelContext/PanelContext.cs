using System;

namespace NQuery
{
    public class PanelContext : IPanelContext
    {
        private readonly Lazy<VisualElement> _context;

        public VisualElement Context => _context.Value;

        public PanelContext(UIDocument uiDocument)
            : this(new SafetyUIDocument(uiDocument)) { }

        public PanelContext(SafetyUIDocument uiDocument)
            : this(new Lazy<VisualElement>(() => uiDocument.RootVisualElement)) { }

        public PanelContext(VisualElement visualElement)
            : this(new Lazy<VisualElement>(() => visualElement)) { }

        public PanelContext(Lazy<VisualElement> visualElement)
        {
            _context = visualElement;
        }
    }
}
