namespace NSupport {

    public static class IntegerByte {
        public static int Byte(this int source) {
            return source.Bytes();
        }

        public static int Bytes(this int source) {
            return source;
        }

        public static int Kilobyte(this int source) {
            return source.Kilobytes();
        }

        public static int Kilobytes(this int source) {
            return source * 1024;
        }

        public static long Megabyte(this int source) {
            return source.Megabytes();
        }

        public static long Megabytes(this int source) {
            return source * 1024.Kilobytes();
        }

        public static long Gigabyte(this int source) {
            return source.Gigabytes();
        }

        public static long Gigabytes(this int source) {
            return source * 1024.Megabytes();
        }

        public static long Terabyte(this int source) {
            return source.Terabytes();
        }

        public static long Terabytes(this int source) {
            return source * 1024.Gigabytes();
        }
    }
}
