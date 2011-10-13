namespace NSupport.Test {
    using System.Linq;
    using Xunit;
    using System;

    public class EnumerableAccessTest {
        [Fact]
        public void Test_From_with_null() {
            string[] source = null;
            var ex = Assert.Throws<ArgumentNullException>(() => source.From(0));

            Assert.Equal(ex.ParamName, "source");
        }

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

        [Fact]
        public void Test_To_out_range_index() {
            var array = new string[] { "a", "b", "c", "d" }.To(10);

            Assert.Equal(4, array.Count());
            Assert.Single(array, "a");
            Assert.Single(array, "b");
            Assert.Single(array, "c");
            Assert.Single(array, "d");
        }

        [Fact]
        public void Test_To_in_range_index() {
            var array = new string[] { "a", "b", "c", "d" }.To(1);

            Assert.Equal(2, array.Count());
            Assert.Single(array, "a");
            Assert.Single(array, "b");
            Assert.DoesNotContain("c", array);
            Assert.DoesNotContain("d", array);
        }

        [Fact]
        public void Test_To_with_zero_index() {
            var array = new string[] { "a", "b", "c", "d" }.To(0);
            Assert.Equal(1, array.Count());
            Assert.Single(array, "a");
        }
    }
}
