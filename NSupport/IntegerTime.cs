﻿namespace NSupport {
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
    }
}