namespace NSupport {
    using System;

    internal static class Guard {
        public static void ArgumentNotNull<T>(string paramName, T value) where T : class {
            if (value == null) {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void StringNotEmpty(string paramName, string value) {
            if (value.Length == 0) {
                throw new ArgumentException("{0} cannot be empty string".FormatWith(paramName), paramName);
            }
        }
    }
}
