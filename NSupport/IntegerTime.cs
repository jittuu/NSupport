﻿namespace NSupport {
    using System;

    public static class IntegerTime {
        public static TimeSpan Second(this int source) {
            return source.Seconds();
        }

        public static TimeSpan Seconds(this int source) {
            return new TimeSpan(0, 0, source);
        }

        public static TimeSpan Minute(this int source) {
            return source.Minutes();
        }

        public static TimeSpan Minutes(this int source) {
            return new TimeSpan(0, source, 0);
        }

        public static TimeSpan Hour(this int source) {
            return source.Hours();
        }

        public static TimeSpan Hours(this int source) {
            return new TimeSpan(source, 0, 0);
        }

        public static TimeSpan Day(this int source) {
            return source.Days();
        }

        public static TimeSpan Days(this int source) {
            return new TimeSpan(source, 0, 0, 0);
        }

        public static TimeSpan Week(this int source) {
            return source.Weeks();
        }

        public static TimeSpan Weeks(this int source) {
            return (source * 7).Days();
        }

        public static TimeSpan Month(this int source) {
            return source.Months();
        }

        public static TimeSpan Months(this int source) {
            return (30 * source).Days();
        }

        public static TimeSpan Year(this int source) {
            return source.Years();
        }

        public static TimeSpan Years(this int source) {
            return (365 * source).Days() + (6 * source).Hours();
        }
    }
}
