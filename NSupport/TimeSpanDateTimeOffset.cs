namespace NSupport {
    using System;

    /// <summary>
    /// Provides extension methods for <see cref="TimeSpan"/> for <see cref="DateTimeOffset"/> conversion.
    /// </summary>
    public static class TimeSpanDateTimeOffset {
        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> which subtract current <see cref="TimeSpan"/> ago from now.
        /// </summary>
        /// <param name="source">A <see cref="TimeSpan"/> instance.</param>
        /// <returns>Returns a <see cref="DateTimeOffset"/> which subtract current <see cref="TimeSpan"/> ago from now.</returns>
        public static DateTimeOffset Ago(this TimeSpan source) {
            return source.Until(DateTimeOffset.Now);
        }

        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> which add current <see cref="TimeSpan"/> since from now.
        /// </summary>
        /// <param name="source">A <see cref="TimeSpan"/> instance.</param>
        /// <returns>Returns a <see cref="DateTimeOffset"/> which add current <see cref="TimeSpan"/> since from now.</returns>
        public static DateTimeOffset FromNow(this TimeSpan source) {
            return source.Since(DateTimeOffset.Now);
        }

        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> which subtract current <see cref="TimeSpan"/> ago from the <paramref name="time"/>.
        /// </summary>
        /// <param name="source">A <see cref="TimeSpan"/> instance.</param>
        /// <param name="time">A <see cref="DateTimeOffset"/> ago from.</param>
        /// <returns>Returns a <see cref="DateTimeOffset"/> which subtract current <see cref="TimeSpan"/> ago from the <paramref name="time"/>.</returns>
        public static DateTimeOffset Until(this TimeSpan source, DateTimeOffset time) {
            return time.Subtract(source);
        }

        /// <summary>
        /// Returns a <see cref="DateTimeOffset"/> which add current <see cref="TimeSpan"/> since from the <paramref name="time"/>.
        /// </summary>
        /// <param name="source">A <see cref="TimeSpan"/> instance.</param>
        /// <param name="time">A <see cref="DateTimeOffset"/> since from.</param>
        /// <returns>Returns a <see cref="DateTimeOffset"/> which add current <see cref="TimeSpan"/> since from the <paramref name="time"/>.</returns>
        public static DateTimeOffset Since(this TimeSpan source, DateTimeOffset time) {
            return time.Add(source);
        }
    }
}
