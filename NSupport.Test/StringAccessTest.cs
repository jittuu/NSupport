namespace NSupport.Test {
    using Xunit;
    using System.Web;
    using System;

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

        [Fact]
        public void Test_UrlEncode_with_space_and_plus_string() {
            var value = "product=100+ Drink";
            // space should be encoded as 20% rather than +
            // ref: http://stackoverflow.com/q/1211229/102940
            var encoded = HttpUtility.UrlEncode(value).Replace("+", "%20");
            Assert.Equal(encoded, value.UrlEncode(), StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void Test_UrlDecode_with_space_and_plus_string_as_browser_encoding() {
            var value = "produce=100+ drink";

            // browser encode
            var encoded = HttpUtility.UrlEncode(value);
            Assert.Equal(value, encoded.UrlDecode(), StringComparer.OrdinalIgnoreCase);            
        }

        [Fact]
        public void Test_UrlDecode_with_space_and_plus_string_as_standard_encoding(){
            var value = "produce=100+ drink";

            // standard encode
            var encoded = HttpUtility.UrlEncode(value).Replace("+", "%20");
            Assert.Equal(value, encoded.UrlDecode(), StringComparer.OrdinalIgnoreCase);            
        }
    }
}
