namespace NSupport {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class IEnumerableAccess {
        public static IEnumerable<T> From<T>(this IEnumerable<T> source, int index) {
            int localIndex = 0;

            foreach (var item in source) {
                if (localIndex++ >= index) {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> To<T>(this IEnumerable<T> source, int index) {
            int localIndex = 0;

            foreach (var item in source) {
                if (localIndex++ <= index) {
                    yield return item;
                }
            }
        }
    }
}
