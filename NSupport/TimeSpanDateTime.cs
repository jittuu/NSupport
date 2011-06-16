namespace NSupport {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class TimeSpanDateTime {
        public static DateTime Ago(this TimeSpan source) {
            return source.Until(DateTime.Now);
        }

        public static DateTime FromNow(this TimeSpan source) {
            return DateTime.Now.Add(source);
        }

        public static DateTime Until(this TimeSpan source, DateTime time) {
            return time.Subtract(source);
        }
    }
}
