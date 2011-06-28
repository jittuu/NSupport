namespace NSupport {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides extension methods for <see cref="IEnumerable{T}"/> for from/to conversion.
    /// </summary>
    public static class EnumerableAccess {
        /// <summary>
        /// Returns the tail of the element sequence from position.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return elements from.</param>
        /// <param name="index">The index no to start from.</param>
        /// <returns>Returns the tail of the element sequence from position.</returns>
        public static IEnumerable<T> From<T>(this IEnumerable<T> source, int index) {
            return source.Skip(index);
        }

        /// <summary>
        /// Returns the beginning of the array up to position.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to return elements from.</param>
        /// <param name="index">The index no to stop at.</param>
        /// <returns>Returns the beginning of the array up to position.</returns>
        public static IEnumerable<T> To<T>(this IEnumerable<T> source, int index) {
            return source.Take(++index);
        }
    }
}
