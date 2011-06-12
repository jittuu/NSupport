namespace NSupport.Test {
    using Xunit;
    using System.Collections.Generic;
    using System.Linq;

    public class IEnumerableAccessTest {
        [Fact]
        public void Test_From_with_index_0() {
            var array = new string[] { "a", "b", "c", "d" }.From(0);

            Assert.Equal(4, array.Count());
            Assert.Single(array, "a");
            Assert.Single(array, "b");
            Assert.Single(array, "c");
            Assert.Single(array, "d");
        }

        [Fact]
        public void Test_From_in_range_index() {
            var array = new string[] { "a", "b", "c", "d" }.From(2);

            Assert.Equal(2, array.Count());
            Assert.DoesNotContain("a", array);
            Assert.DoesNotContain("b", array);
            Assert.Single(array, "c");
            Assert.Single(array, "d");
        }

        [Fact]
        public void Test_From_out_range_index() {
            var array = new string[] { "a", "b", "c", "d" }.From(4);
            Assert.Empty(array);
        }
    }
}
