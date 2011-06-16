namespace NSupport {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class TimeSpanDateTime {
        public static DateTime Ago(this TimeSpan source) {
            return DateTime.Now.Subtract(source);
        }
    }
}
