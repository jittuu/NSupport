namespace NSupport.Test {
    using Xunit;

    public class StringAccessTest {
        [Fact]
        public void Test_IsNullOrEmpty_with_null() {
            string nullString = null;
            Assert.Equal(true, nullString.IsNullOrEmpty());
        }

        [Fact]
        public void Test_IsNullOrEmpty_with_empty_string() {
            var empty = "";
            Assert.Equal(true, empty.IsNullOrEmpty());
        }

        [Fact]
        public void Test_IsNullOrEmpty_with_string_value() {
            Assert.Equal(false, "value".IsNullOrEmpty());
        }

        [Fact]
        public void Test_IsBlank_with_null() {
            string nullString = null;
            Assert.Equal(true, nullString.IsBlank());
        }

        [Fact]
        public void Test_IsBlank_with_empty_string() {
            var empty = "";
            Assert.Equal(true, empty.IsBlank());
        }

        [Fact]
        public void Test_IsBlank_with_whitespace() {
            var space = "       ";
            Assert.Equal(true, space.IsBlank());
        }

        [Fact]
        public void Test_IsBlank_with_string_value() {
            Assert.Equal(false, "value".IsBlank());
        }

        [Fact]
        public void Test_IsBlank_with_string_value_with_whitespace() {
            Assert.Equal(false, "value  option".IsBlank());
        }
    }
}
