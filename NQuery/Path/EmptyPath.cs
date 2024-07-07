using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Charpoos;

namespace NQuery
{
    public class EmptyPath : IPath
    {
        public IEnumerable<IText> Paths => Enumerable.Empty<IText>();
 
        [Pure]
        public IPath WithSubPath(IPath path) => new Path(path);

        [Pure]
        public IPath WithSubPath(string path) => new Path(path);
    }
}