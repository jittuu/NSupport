namespace NSupport {
    /// <summary>
    /// Provides extension methods for <see cref="int"/> for even/odds conversion.
    /// </summary>
    public static class IntegerEvenOdd {
        /// <summary>
        /// Returns true if the number is odd, otherwise false.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>Returns true if the number is odd, otherwise false.</returns>
        public static bool IsOdd(this int source) {
            return source % 2 != 0;
        }

        /// <summary>
        /// Returns true if the number is even, otherwise false.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <returns>Returns true if the number is even, otherwise false.</returns>        
        public static bool IsEven(this int source) {
            return !source.IsOdd();
        }

        /// <summary>
        /// Returns true if the number is multiple of <paramref name="number"/>, otherwise false.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <param name="number">The multiplier.</param>
        /// <returns>Returns true if the number is multiple of <paramref name="number" />, otherwise false.</returns>        
        public static bool IsMultipleOf(this int source, int number) {
            return source % number == 0;
        }
    }
}
