namespace NSupport {
    using System;

    internal static class Guard {
        public static void ArgumentNotNull<T>(string paramName, T value) where T : class {
            if (value == null) {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
