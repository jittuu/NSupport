namespace NSupport {

    /// <summary>
    /// Provide access methods for <see cref="string"/>.
    /// </summary>
    public static class StringAccess {

        /// <summary>
        /// Check whether given <see cref="string"/> is null or empty.
        /// </summary>
        /// <param name="source">An instance of <see cref="string"/>.</param>
        /// <returns>true if <paramref name="source"/> is null or empty, otherwise false.</returns>
        public static bool IsNullOrEmpty(this string source) {
            return string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// Check whether given <see cref="string"/> is null or empty or only whitespace.
        /// </summary>
        /// <param name="source">An instance of <see cref="string"/>.</param>
        /// <returns>true if <paramref name="source"/> is null or empty or only whitespace, otherwise false.</returns>
        public static bool IsBlank(this string source) {
            return string.IsNullOrWhiteSpace(source);
        }
    }
}
