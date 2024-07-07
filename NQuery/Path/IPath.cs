using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Charpoos;

namespace NQuery
{
    public interface IPath
    {
        IEnumerable<IText> Paths { get; }
        [Pure]
        IPath WithSubPath(IPath path);
        [Pure]
        IPath WithSubPath(string path);
    }
}