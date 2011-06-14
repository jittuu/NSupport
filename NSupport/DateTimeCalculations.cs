namespace NSupport {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class DateTimeCalculations {
        public static DateTime Tomorrow(this DateTime source) {
            return source.AddDays(1);
        }

        public static DateTime Yesterday(this DateTime source) {
            return source.AddDays(-1);
        }
    }
}
