namespace NSupport {
    using System;

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

        /// <summary>
        /// Encode string as url string.
        /// </summary>
        /// <param name="source"><see cref="string"/> instance to encode.</param>
        /// <returns>Encoded url string.</returns>
        public static string UrlEncode(this string source) {
            Guard.ArgumentNotNull("source", source);

            return Uri.EscapeDataString(source);
        }

        /// <summary>
        /// Decode url string to original string.
        /// </summary>
        /// <param name="source"><see cref="string"/> instance to decode.</param>
        /// <returns>Original string of url string.</returns>
        public static string UrlDecode(this string source) {
            Guard.ArgumentNotNull("source", source);

            return Uri.UnescapeDataString(source.Replace("+", "%20"));
        }
    }
}
