namespace NSupport.Test {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
    }
}
