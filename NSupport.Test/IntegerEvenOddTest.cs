namespace NSupport.Test {
    using Xunit;

    public class IntegerEvenOddTest {
        [Fact]
        public void Test_IsOdd() {
            Assert.Equal(true, 1.IsOdd());
            Assert.Equal(true, 13.IsOdd());
            Assert.Equal(true, (-1).IsOdd());

            Assert.Equal(false, 2.IsOdd());
            Assert.Equal(false, 0.IsOdd());
            Assert.Equal(false, 24.IsOdd());
            Assert.Equal(false, (-4).IsOdd());
        }

        [Fact]
        public void Test_IsEven() {
            Assert.Equal(false, 1.IsEven());
            Assert.Equal(false, 13.IsEven());
            Assert.Equal(false, (-1).IsEven());

            Assert.Equal(true, 2.IsEven());
            Assert.Equal(true, 0.IsEven());
            Assert.Equal(true, 24.IsEven());
            Assert.Equal(true, (-4).IsEven());
        }

        [Fact]
        public void Test_IsMultipleOf() {
            Assert.Equal(true, 0.IsMultipleOf(1));
            Assert.Equal(true, 0.IsMultipleOf(2));
            Assert.Equal(true, 5.IsMultipleOf(1));
            Assert.Equal(true, 5.IsMultipleOf(5));
            Assert.Equal(true, 12.IsMultipleOf(3));
            Assert.Equal(true, 20.IsMultipleOf(2));

            Assert.Equal(false, 1.IsMultipleOf(2));
            Assert.Equal(false, 5.IsMultipleOf(2));
            Assert.Equal(false, 15.IsMultipleOf(4));
            Assert.Equal(false, 12.IsMultipleOf(7));
            Assert.Equal(false, 1.IsMultipleOf(2));
        }
    }
}
