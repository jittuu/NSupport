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

        public static long MegaByte(this int source) {
            return source.MegaBytes();
        }

        public static long MegaBytes(this int source) {
            return source * 1024.KiloBytes();
        }

        public static long GigaByte(this int source) {
            return source.GigaBytes();
        }

        public static long GigaBytes(this int source) {
            return source * 1024.MegaBytes();
        }

        public static long TeraByte(this int source) {
            return source.TeraBytes();
        }

        public static long TeraBytes(this int source) {
            return source * 1024.GigaBytes();
        }
    }
}
