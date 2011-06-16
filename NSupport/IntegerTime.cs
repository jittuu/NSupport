namespace NSupport {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
    }
}
