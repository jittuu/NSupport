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
            Assert.Equal(1024, 1.KiloByte());
        }

        [Fact]
        public void Test_KiloBytes() {
            Assert.Equal(10 * 1024, 10.KiloBytes());
        }
    }
}
