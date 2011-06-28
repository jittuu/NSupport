namespace NSupport {
    using System;

    /// <summary>
    /// Provides extension methods for <see cref="TimeSpan"/> for <see cref="DateTime"/> conversion.
    /// </summary>
    public static class TimeSpanDateTime {
        /// <summary>
        /// Returns a <see cref="DateTime"/> which subtract current <see cref="TimeSpan"/> ago from now.
        /// </summary>
        /// <param name="source">A <see cref="TimeSpan"/> instance.</param>
        /// <returns>Returns a <see cref="DateTime"/> which subtract current <see cref="TimeSpan"/> ago from now.</returns>
        public static DateTime Ago(this TimeSpan source) {
            return source.Until(DateTime.Now);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> which add current <see cref="TimeSpan"/> since from now.
        /// </summary>
        /// <param name="source">A <see cref="TimeSpan"/> instance.</param>
        /// <returns>Returns a <see cref="DateTime"/> which add current <see cref="TimeSpan"/> since from now.</returns>
        public static DateTime FromNow(this TimeSpan source) {
            return source.Since(DateTime.Now);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> which subtract current <see cref="TimeSpan"/> ago from the <paramref name="time"/>.
        /// </summary>
        /// <param name="source">A <see cref="TimeSpan"/> instance.</param>
        /// <param name="time">A <see cref="DateTime"/> ago from.</param>
        /// <returns>Returns a <see cref="DateTime"/> which subtract current <see cref="TimeSpan"/> ago from the <paramref name="time"/>.</returns>
        public static DateTime Until(this TimeSpan source, DateTime time) {
            return time.Subtract(source);
        }

        /// <summary>
        /// Returns a <see cref="DateTime"/> which add current <see cref="TimeSpan"/> since from the <paramref name="time"/>.
        /// </summary>
        /// <param name="source">A <see cref="TimeSpan"/> instance.</param>
        /// <param name="time">A <see cref="DateTime"/> since from.</param>
        /// <returns>Returns a <see cref="DateTime"/> which add current <see cref="TimeSpan"/> since from the <paramref name="time"/>.</returns>
        public static DateTime Since(this TimeSpan source, DateTime time) {
            return time.Add(source);
        }
    }
}
