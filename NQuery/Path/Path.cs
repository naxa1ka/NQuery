using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Charpoos;

namespace NQuery
{
    public class Path : IPath
    {
        /// <summary>
        /// Represents the full path with path separators.
        /// </summary>
        /// <example>
        /// Hierarchy:
        /// <code>
        /// - parent
        ///   - sub-parent
        ///     - name-label
        /// </code>
        /// In this case, the full path will be:
        /// <code>parent.sub-parent.name-label</code>
        /// </example>
        private readonly IText _fullPath;

        public Path(IText fullPath)
        {
            _fullPath = fullPath;
        }

        public Path(IPath path)
            : this(new Joined(new PathSeparator(), path.Paths)) { }

        public Path(string fullPath)
            : this(new TextOfString(fullPath)) { }

        public IEnumerable<IText> Paths => new Split(_fullPath, new PathSeparator());

        [Pure]
        public IPath WithSubPath(IPath path) => new Path(new Concatenated(Paths, path.Paths));

        [Pure]
        public IPath WithSubPath(string path) =>
            new Path(new Concatenated(Paths, new TextOfString(path)));
    }
}
