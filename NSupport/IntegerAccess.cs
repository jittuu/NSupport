namespace NSupport {    
    using System;

    /// <summary>
    /// Provides extension methods for <see cref="int"/> for easy access.
    /// </summary>
    public static class IntegerAccess {
        private static Action emptyAction = (() => { });
        private static Action<int> emptyIndexAction = ((i) => { });

        /// <summary>
        /// Loops the current <see cref="int" /> times with the given <paramref name="action"/>.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <param name="action">A <see cref="Action" /> to loop.</param>
        public static void Times(this int source, Action action) {            
            source.Times((i) => { (action ?? emptyAction)(); });
        }

        /// <summary>
        /// Loops the current <see cref="int" /> times with the given <paramref name="action"/>.
        /// </summary>
        /// <param name="source">A <see cref="int"/> instance.</param>
        /// <param name="action">A <see cref="Action{T}" /> to loop.</param>
        public static void Times(this int source, Action<int> action) {            
            for (int i = 0; i < source; i++) {
                (action ?? emptyIndexAction)(i);
            }
        }
    }
}
