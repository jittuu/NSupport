namespace NSupport {

    public static class IntegerByte {
        public static int Byte(this int source) {
            return source.Bytes();
        }

        public static int Bytes(this int source) {
            return source;
        }

        public static int KiloByte(this int source) {
            return source.KiloBytes();
        }

        public static int KiloBytes(this int source) {
            return source * 1024;
        }
    }
}
