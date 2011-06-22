namespace NSupport {
    /// <summary>
    /// Provides extension methods for <see cref="int"/> for byte/kilobyte/etc conversion.
    /// </summary>
    public static class IntegerByte {
        /// <summary>
        /// A byte.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>A byte.</returns>
        public static int Byte(this int source) {
            return source.Bytes();
        }

        /// <summary>
        /// The bytes in number.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>The bytes in number.</returns>
        public static int Bytes(this int source) {
            return source;
        }

        /// <summary>
        /// A kilobyte.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>A kilobyte.</returns>
        public static int Kilobyte(this int source) {
            return source.Kilobytes();
        }

        /// <summary>
        /// The kilobytes in number.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>The kilobytes in number.</returns>
        public static int Kilobytes(this int source) {
            return source * 1024;
        }

        /// <summary>
        /// A megabyte.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>A megabyte.</returns>
        public static long Megabyte(this int source) {
            return source.Megabytes();
        }

        /// <summary>
        /// The megabytes in number.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>The megabytes in number.</returns>
        public static long Megabytes(this int source) {
            return source * 1024.Kilobytes();
        }

        /// <summary>
        /// A gigabype.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>A gigabyte.</returns>
        public static long Gigabyte(this int source) {
            return source.Gigabytes();
        }

        /// <summary>
        /// The gigabytes in number.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>The gigabytes in number.</returns>
        public static long Gigabytes(this int source) {
            return source * 1024.Megabytes();
        }

        /// <summary>
        /// A terabyte.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>A terabyte.</returns>
        public static long Terabyte(this int source) {
            return source.Terabytes();
        }

        /// <summary>
        /// The terabytes in number.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>The terabytes in number.</returns>
        public static long Terabytes(this int source) {
            return source * 1024.Gigabytes();
        }
    }
}
