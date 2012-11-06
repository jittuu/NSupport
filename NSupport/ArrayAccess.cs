namespace NSupport {
    using System;

    /// <summary>
    /// Provide access methods for <see cref="Array"/>
    /// </summary>
    public static class ArrayAccess {
        /// <summary>
        /// The zero-based index of the first occurrence of value within the entire <paramref name="source"/>, if found; otherwise, –1.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An instance of <see cref="Array"/>.</param>
        /// <param name="value">The object to locate in <paramref name="source"/>.</param>
        /// <returns>The zero-based index of the first occurrence of value within the entire <paramref name="source"/>, if found; otherwise, –1.</returns>
        public static int IndexOf<T>(this T[] source, T value) {
            Guard.ArgumentNotNull("source", source);

            return Array.IndexOf<T>(source, value);
        }

        /// <summary>
        /// The zero-based index of the last occurrence of value within the entire <paramref name="source"/>, if found; otherwise, –1.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An instance of <see cref="Array"/>.</param>
        /// <param name="value">The object to locate in <paramref name="source"/>.</param>
        /// <returns>The zero-based index of the last occurrence of value within the entire <paramref name="source"/>, if found; otherwise, –1.</returns>
        public static int LastIndexOf<T>(this T[] source, T value) {
            Guard.ArgumentNotNull("source", source);

            return Array.LastIndexOf<T>(source, value);
        }

        /// <summary>
        /// Create empty array of T without modifying <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An instance of <see cref="Array"/>.</param>
        /// <returns>Empty array of T.</returns>
        public static T[] Empty<T>(this T[] source) {
            Guard.ArgumentNotNull("source", source);
            source = new T[] { };            
            return source;
        }
    }
}
