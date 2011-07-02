namespace NSupport {
    using System;
    using System.Threading;

    /// <summary>
    /// Provides extension methods for <see cref="string"/> for fomatting.
    /// </summary>
    public static class StringFormatting {
        /// <summary>
        /// Replaces one or more format items in a specified string with the string representation of a specified object.
        /// This method uses <see cref="String.Format(string, object[])"/> method intenally.
        /// </summary>
        /// <param name="source">A <see cref="string"/> instance.</param>
        /// <param name="args">An object array that contains zero or more objects to format. </param>
        /// <returns>A copy of <paramref name="source"/> in which the format items have been replaced by the string representation of the corresponding objects in <paramref name="args"/>.</returns>
        public static string FormatWith(this string source, params object[] args) {
            return source.FormatWith(Thread.CurrentThread.CurrentCulture, args);
        }

        /// <summary>
        /// Replaces one or more format items in a specified string with the string representation of a specified object.
        /// This method uses <see cref="String.Format(IFormatProvider, string, object[])"/> method intenally.
        /// </summary>
        /// <param name="source">A <see cref="string"/> instance.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="args">An object array that contains zero or more objects to format. </param>
        /// <returns>A copy of <paramref name="source"/> in which the format items have been replaced by the string representation of the corresponding objects in <paramref name="args"/>.</returns>
        public static string FormatWith(this string source, IFormatProvider provider, params object[] args) {
            return String.Format(provider, source, args);

        }
    }
}
