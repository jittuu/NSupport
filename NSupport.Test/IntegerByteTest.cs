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
    }
}
