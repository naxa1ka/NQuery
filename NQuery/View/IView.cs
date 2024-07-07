using System.Collections.Generic;

namespace NQuery
{
    public interface IView
    {
        IPanelContext PanelContext { get; }
        IPath PathToParent { get; }
        IEnumerable<IView> Children { get;}
        void Initialize();
    }
}