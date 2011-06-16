namespace NSupport {
    using System;

    public static class TimeSpanDateTime {
        public static DateTime Ago(this TimeSpan source) {
            return source.Until(DateTime.Now);
        }

        public static DateTime FromNow(this TimeSpan source) {
            return source.Since(DateTime.Now);
        }

        public static DateTime Until(this TimeSpan source, DateTime time) {
            return time.Subtract(source);
        }

        public static DateTime Since(this TimeSpan source, DateTime time) {
            return time.Add(source);
        }
    }
}
