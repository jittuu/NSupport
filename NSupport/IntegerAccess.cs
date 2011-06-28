namespace NSupport {    
    using System;

    public static class IntegerAccess {
        private static Action emptyAction = (() => { });
        private static Action<int> emptyIndexAction = ((i) => { });

        public static void Times(this int source, Action action) {            
            source.Times((i) => { (action ?? emptyAction)(); });
        }

        public static void Times(this int source, Action<int> action) {            
            for (int i = 0; i < source; i++) {
                (action ?? emptyIndexAction)(i);
            }
        }
    }
}
