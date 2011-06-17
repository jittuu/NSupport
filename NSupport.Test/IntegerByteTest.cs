namespace NSupport.Test {
    using Xunit;

    public class IntegerByteTest {
        [Fact]
        public void Test_Byte() {
            Assert.Equal(1, 1.Byte());
        }

        [Fact]
        public void Test_Bytes() {
            Assert.Equal(10, 10.Bytes());
        }

        [Fact]
        public void Test_KiloByte() {
            Assert.Equal(1024, 1.Kilobyte());
        }

        [Fact]
        public void Test_KiloBytes() {
            Assert.Equal(10 * 1024, 10.Kilobytes());
        }

        [Fact]
        public void Test_MegaByte() {
            Assert.Equal(1024L * 1024, 1.Megabyte());
        }

        [Fact]
        public void Test_MegaBytes() {
            Assert.Equal(10L * 1024 * 1024, 10.Megabytes());
        }

        [Fact]
        public void Test_GigaByte() {
            Assert.Equal(1024L * 1024 * 1024, 1.Gigabyte());
        }

        [Fact]
        public void Test_GigaBytes() {
            Assert.Equal(10L * 1024 * 1024 * 1024, 10.Gigabytes());
        }

        [Fact]
        public void Test_TeraByte() {
            Assert.Equal(1024L * 1024 * 1024 * 1024, 1.Terabyte());
        }

        [Fact]
        public void Test_TeraBytes() {
            Assert.Equal(10L * 1024 * 1024 * 1024 * 1024, 10.Terabytes());
        }
    }
}
