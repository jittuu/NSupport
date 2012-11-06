namespace NSupport {
    using System.Collections.Generic;

    /// <summary>
    ///  Provides extension methods for <see cref="ICollection{T}"/>.
    /// </summary>
    public static class CollectionAccess {
        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An instance of <see cref="ICollection{T}"/>.</param>
        /// <param name="values">The collection whose elements should be added to the end of the <see cref="ICollection{T}"/>. 
        /// The collection can be null. If null, it won't add anything.
        /// </param>
        /// <returns></returns>
        public static ICollection<T> AddRange<T>(this ICollection<T> source, IEnumerable<T> values) {
            Guard.ArgumentNotNull("source", source);
            if (values.IsEmpty()) {
                return source;
            }

            foreach (var item in values) {
                source.Add(item);
            }

            return source;
        }
    }
}
