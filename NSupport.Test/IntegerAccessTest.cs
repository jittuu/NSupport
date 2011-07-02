namespace NSupport.Test {
    using System;
    using Xunit;

    public class IntegerAccessTest {
        [Fact]
        public void Test_Integer_Times_with_null() {
            Assert.DoesNotThrow(() => { 5.Times((Action)null); });
            Assert.DoesNotThrow(() => { 5.Times((Action<int>)null); });
        }

        [Fact]
        public void Test_Integer_Times_without_index() {
            var count = 0;
            5.Times(() => count++);
            Assert.Equal(5, count);
        }

        [Fact]
        public void Test_Integer_Times_with_index() {
            var index = 0;
            5.Times((i) => {
                Assert.Equal(index, i);
                index++;
            });
        }
    }
}
