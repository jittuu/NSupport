namespace NSupport {
    using System.Globalization;

    /// <summary>
    /// Provides extension methods for converting to another string which is better for human rather than machine.
    /// </summary>
    public static class StringHumanization {
        /// <summary>
        /// Converts the specified string to titlecase.
        /// We are using <see cref="TextInfo.ToTitleCase"/> method after making lower case.
        /// </summary>
        /// <param name="source">The <see cref="string"/> to convert to titlecase</param>
        /// <returns>The specified <see cref="string"/> converted to titlecase.</returns>
        public static string ToTitleCase(this string source) {
            Guard.ArgumentNotNull("source", source);

            var lower = source.ToLower(CultureInfo.CurrentCulture);
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lower);
        }
    }
}
