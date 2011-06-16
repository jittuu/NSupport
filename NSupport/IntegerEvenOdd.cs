namespace NSupport {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class IntegerEvenOdd {
        public static bool IsOdd(this int source) {
            return source % 2 != 0;
        }
    }
}
