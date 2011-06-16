namespace NSupport {

    public static class IntegerByte {
        public static int Byte(this int source) {
            return source.Bytes();
        }

        public static int Bytes(this int source) {
            return source;
        }
    }
}
