namespace NSupport {
    using System;
    using System.Linq;

    /// <summary>
    /// Provides extension methods for <see cref="DateTimeOffset"/> for calcualtions.
    /// </summary>
    public static class DateTimeOffsetCalculations {
        /// <summary>
        /// Returns a new <see cref="System.DateTimeOffset" /> that adds one day to the value of this instance.
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTimeOffset" /> that adds one day to the value of this instance.</returns>
        public static DateTimeOffset Tomorrow(this DateTimeOffset source) {
            return source.AddDays(1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTimeOffset" /> that minus one day to the value of this instance.
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTimeOffset" /> that minus one day to the value of this instance.</returns>
        public static DateTimeOffset Yesterday(this DateTimeOffset source) {
            return source.AddDays(-1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTimeOffset" /> that adds one year to the value of this instance.
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTimeOffset" /> that adds one year to the value of this instance.</returns>
        public static DateTimeOffset NextYear(this DateTimeOffset source) {
            return source.AddYears(1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTimeOffset" /> that minus one year to the value of this instance.
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTimeOffset" /> that minus one year to the value of this instance.</returns>
        public static DateTimeOffset PreviousYear(this DateTimeOffset source) {
            return source.AddYears(-1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTimeOffset" /> that adds one month to the value of this instance.
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTimeOffset" /> that adds one month to the value of this instance.</returns>
        public static DateTimeOffset NextMonth(this DateTimeOffset source) {
            return source.AddMonths(1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTimeOffset" /> that minus one month to the value of this instance.
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTimeOffset" /> that minus one month to the value of this instance.</returns>
        public static DateTimeOffset PreviousMonth(this DateTimeOffset source) {
            return source.AddMonths(-1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTimeOffset" /> with the time value set to 12:00:00 midnight (00:00:00).
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTimeOffset" /> with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTimeOffset BeginningOfDay(this DateTimeOffset source) {
            return new DateTimeOffset(source.Year, source.Month, source.Day, 0, 0, 0, source.Offset);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTimeOffset" /> with the time value set to 12:00:00 midnight (00:00:00).
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTimeOffset" /> with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTimeOffset Midnight(this DateTimeOffset source) {
            return source.BeginningOfDay();
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTimeOffset" /> with the time value set to (23:59:59).
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTimeOffset" /> with the time value set to (23:59:59).</returns>
        public static DateTimeOffset EndOfDay(this DateTimeOffset source) {
            return source.Tomorrow().BeginningOfDay().AddSeconds(-1);
        }

        /// <summary>
        /// Returns the first day of the current month with the time value set to 12:00:00 midnight (00:00:00).
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns the first day of the current month with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTimeOffset BeginningOfMonth(this DateTimeOffset source) {
            return new DateTimeOffset(source.Year, source.Month, 1, 0, 0, 0, source.Offset);
        }

        /// <summary>
        /// Returns the last day of the current month with the time value set to (23:59:59).
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns the last day of the current month with the time value set to (23:59:59).</returns>        
        public static DateTimeOffset EndOfMonth(this DateTimeOffset source) {
            return source.NextMonth().BeginningOfMonth().AddSeconds(-1);
        }

        /// <summary>
        /// Returns the first day of the current year with the time value set to 12:00:00 midnight (00:00:00).
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns the first day of the current year with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTimeOffset BeginningOfYear(this DateTimeOffset source) {
            return new DateTimeOffset(source.Year, 1, 1, 0, 0, 0, source.Offset);
        }

        /// <summary>
        /// Returns the last day of the current year with the time value set to (23:59:59).
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns the last day of the current year with the time value set to (23:59:59).</returns>   
        public static DateTimeOffset EndOfYear(this DateTimeOffset source) {
            return source.NextYear().BeginningOfYear().AddSeconds(-1);
        }

        /// <summary>
        /// Returns the first day of the current week with the time value set to 12:00:00 midnight (00:00:00).
        /// This method is culture-aware method which calculates based on <see cref="System.Globalization.DateTimeFormatInfo.FirstDayOfWeek" />.
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns the first day of the current week with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTimeOffset BeginningOfWeek(this DateTimeOffset source) {
            var beginningOfWeek = source;
            var dateTimeFormatInfo = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
            while (beginningOfWeek.DayOfWeek != dateTimeFormatInfo.FirstDayOfWeek) {
                beginningOfWeek = beginningOfWeek.Yesterday();
            }

            return beginningOfWeek.BeginningOfDay();
        }

        /// <summary>
        /// Returns the last day of the current week with the time value set to (23:59:59).
        /// This method is culture-aware method which calculates based on <see cref="System.Globalization.DateTimeFormatInfo.FirstDayOfWeek" />.
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns the last day of the current week with the time value set to (23:59:59).</returns>
        public static DateTimeOffset EndOfWeek(this DateTimeOffset source) {
            return source.NextWeek().BeginningOfWeek().AddSeconds(-1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTimeOffset" /> that adds seven days to the value of this instance with the time value set to 12:00:00 midnight (00:00:00).
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTimeOffset" /> that adds seven days to the value of this instance with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTimeOffset NextWeek(this DateTimeOffset source) {
            return source.AddDays(7).BeginningOfDay();
        }

        /// <summary>
        /// Returns the given <paramref name="day" /> of next week with the time value set to 12:00:00 midnight (00:00:00).
        /// This method is culture-aware method which calculates based on <see cref="System.Globalization.DateTimeFormatInfo.FirstDayOfWeek" />.
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <param name="day">The <see cref="System.DayOfWeek" /> of next week.</param>
        /// <returns>Returns the given <paramref name="day" /> of next week with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTimeOffset NextWeek(this DateTimeOffset source, DayOfWeek day) {
            var nextWeek = source.NextWeek().BeginningOfWeek();
            while (nextWeek.DayOfWeek != day) {
                nextWeek = nextWeek.AddDays(1);
            }

            return nextWeek;
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTimeOffset" /> representing the start of the current quarter (1st of January, April, July, October) with the time value set to 12:00:00 midnight (00:00:00).
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTimeOffset" /> representing the start of the current quarter (1st of January, April, July, October) with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTimeOffset BeginningOfQuarter(this DateTimeOffset source) {
            var quarterMonth = new int[] { 10, 7, 4, 1 }.First(m => m <= source.Month);
            return new DateTimeOffset(source.Year, quarterMonth, 1, 0, 0, 0, source.Offset);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTimeOffset" /> representing the end of the current quarter (last day of March, June, September, December) with the time value set to (23:59:59).
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTimeOffset" /> representing the end of the current quarter (last day of March, June, September, December) with the time value set to (23:59:59).</returns>
        public static DateTimeOffset EndOfQuarter(this DateTimeOffset source) {
            var quarterMonth = new int[] { 3, 6, 9, 12 }.First(m => m >= source.Month);
            return new DateTimeOffset(source.Year, quarterMonth, 1, 0, 0, 0, source.Offset).EndOfMonth();
        }

        /// <summary>
        /// Returns true if the instance <see cref="System.DateTimeOffset" /> is greater than <see cref="System.DateTimeOffset.Now" />, otherwise false.
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns true if the instance <see cref="System.DateTimeOffset" /> is greater than <see cref="System.DateTimeOffset.Now" />.</returns>
        public static bool IsFuture(this DateTimeOffset source) {
            return source > DateTimeOffset.Now;
        }

        /// <summary>
        /// Returns true if the instance <see cref="System.DateTimeOffset" /> is less than <see cref="System.DateTimeOffset.Now" />, otherwise false.
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <returns>Returns true if the instance <see cref="System.DateTimeOffset" /> is less than <see cref="System.DateTimeOffset.Now" />.</returns>
        public static bool IsPast(this DateTimeOffset source) {
            return source < DateTimeOffset.Now;
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTimeOffset" /> that adds the provided parameters (<paramref name="years" />, <paramref name="months" />, <paramref name="days" />, <paramref name="hours" />, <paramref name="minutes" />, <paramref name="seconds" />) value/s.
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <param name="years">The number of years to add.</param>
        /// <param name="months">The number of months to add.</param>
        /// <param name="days">The number of days to add.</param>
        /// <param name="hours">The number of hours to add.</param>
        /// <param name="minutes">The number of minutes to add.</param>
        /// <param name="seconds">The number of seconds to add.</param>
        /// <returns>Returns a new <see cref="System.DateTimeOffset" /> that adds the provided parameters (<paramref name="years" />, <paramref name="months" />, <paramref name="days" />, <paramref name="hours" />, <paramref name="minutes" />, <paramref name="seconds" />) value/s.</returns>
        public static DateTimeOffset Advance(this DateTimeOffset source, int years = 0, int months = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0) {
            return source.AddYears(years)
                .AddMonths(months)
                .AddDays(days)
                .AddHours(hours)
                .AddMinutes(minutes)
                .AddSeconds(seconds);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTimeOffset" /> that minus the provided parameters (<paramref name="years" />, <paramref name="months" />, <paramref name="days" />, <paramref name="hours" />, <paramref name="minutes" />, <paramref name="seconds" />) value/s.
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <param name="years">The number of years to reduce.</param>
        /// <param name="months">The number of months to reduce.</param>
        /// <param name="days">The number of days to reduce.</param>
        /// <param name="hours">The number of hours to reduce.</param>
        /// <param name="minutes">The number of minutes to reduce.</param>
        /// <param name="seconds">The number of seconds to reduce.</param>
        /// <returns>Returns a new <see cref="System.DateTimeOffset" /> that minus the provided parameters (<paramref name="years" />, <paramref name="months" />, <paramref name="days" />, <paramref name="hours" />, <paramref name="minutes" />, <paramref name="seconds" />) value/s.</returns>        
        public static DateTimeOffset Ago(this DateTimeOffset source, int years = 0, int months = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0) {
            return source.AddYears(years * -1)
                .AddMonths(months * -1)
                .AddDays(days * -1)
                .AddHours(hours * -1)
                .AddMinutes(minutes * -1)
                .AddSeconds(seconds * -1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTimeOffset" /> that change the provided parameters (<paramref name="years" />, <paramref name="months" />, <paramref name="days" />, <paramref name="hours" />, <paramref name="minutes" />, <paramref name="seconds" />, <paramref name="milliseconds" />) value/s.
        /// </summary>
        /// <param name="source"><see cref="System.DateTimeOffset" /> instance.</param>
        /// <param name="years">The number of years to change.</param>
        /// <param name="months">The number of months to change.</param>
        /// <param name="days">The number of days to change.</param>
        /// <param name="hours">The number of hours to change.</param>
        /// <param name="minutes">The number of minutes to change.</param>
        /// <param name="seconds">The number of seconds to change.</param>
        /// <param name="milliseconds">The number of milliseconds to change.</param>
        /// <returns>Returns a new <see cref="System.DateTimeOffset" /> that change the provided parameters (<paramref name="years" />, <paramref name="months" />, <paramref name="days" />, <paramref name="hours" />, <paramref name="minutes" />, <paramref name="seconds" />, <paramref name="milliseconds" />) value/s.</returns>
        public static DateTimeOffset Change(this DateTimeOffset source, int? years = null, int? months = null, int? days = null, int? hours = null, int? minutes = null, int? seconds = null, int? milliseconds = null) {
            var y = years ?? source.Year;
            var m = months ?? source.Month;
            var d = days ?? source.Day;
            var h = hours ?? source.Hour;
            var min = minutes ?? source.Minute;
            var s = seconds ?? source.Second;
            var ms = milliseconds ?? source.Millisecond;

            return new DateTimeOffset(y, m, d, h, min, s, ms, source.Offset);
        }
    }
}
