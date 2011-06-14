namespace NSupport {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class EnumerableAccess {
        public static IEnumerable<T> From<T>(this IEnumerable<T> source, int index) {
            return source.Skip(index);
        }

        public static IEnumerable<T> To<T>(this IEnumerable<T> source, int index) {
            return source.Take(++index);
        }
    }
}
