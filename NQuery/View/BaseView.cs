using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace NQuery
{
    public abstract class BaseView : IView
    {
        private readonly List<IView> _children = new();

        public IPanelContext PanelContext { get; }
        public IPath PathToParent { get; }
        public IEnumerable<IView> Children => _children;

        public BaseView(UIDocument uiDocument, IPath pathToParent)
            : this(new PanelContext(uiDocument), pathToParent) { }

        public BaseView(UIDocument uiDocument)
            : this(new PanelContext(uiDocument), new EmptyPath()) { }

        public BaseView(VisualElement visualElement, IPath pathToParent)
            : this(new PanelContext(visualElement), pathToParent) { }

        public BaseView(VisualElement visualElement)
            : this(new PanelContext(visualElement), new EmptyPath()) { }

        public BaseView(Lazy<VisualElement> visualElement, IPath pathToParent)
            : this(new PanelContext(visualElement), pathToParent) { }

        public BaseView(Lazy<VisualElement> visualElement)
            : this(new PanelContext(visualElement), new EmptyPath()) { }

        private BaseView(IPanelContext panelContext, IPath pathToParent)
        {
            PanelContext = panelContext;
            PathToParent = pathToParent;
        }

        [Pure]
        protected IPath WithSubPathRelativeParent(string path) => new Path(PathToParent.WithSubPath(path));
        
        [Pure]
        protected IPath WithSubPathRelativeParent(IPath path) => new Path(PathToParent.WithSubPath(path));

        protected T AddAsChild<T>(T view) where T : IView
        {
            _children.Add(view);
            return view;
        }

        public void Initialize()
        {
            BeforeChildrenInitialize();
            foreach (var child in _children)
                child.Initialize();
            AfterChildrenInitialize();
        }

        protected virtual void BeforeChildrenInitialize(){}
        protected virtual void AfterChildrenInitialize() {}
    }
}
