using System;

namespace NQuery
{
    public class SafetyUIDocument
    {
        private readonly UIDocument _uiDocument;

        public SafetyUIDocument(UIDocument uiDocument) => _uiDocument = uiDocument;

        public VisualElement RootVisualElement
        {
            get
            {
                if (IsRootVisualElementNull())
                    RecreateUI();
                if (IsRootVisualElementNull())
                    throw new InvalidOperationException("The UI document still is not initialized!");
                return _uiDocument.rootVisualElement;
            }
        }

        private bool IsRootVisualElementNull() => _uiDocument.rootVisualElement == null;

        private void RecreateUI() => _uiDocument.visualTreeAsset = _uiDocument.visualTreeAsset;
    }
}