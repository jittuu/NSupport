namespace NSupport.Test {
    using System.Globalization;
    using Xunit;

    public class StringConversionTest {
        [Fact]
        public void Test_IsNumber_for_valid_strings() {
            var validValues = new string[] { 
                "1234", "  1234", "1234   ", "   1234  ",
                "123.34", "+2134", "+23.343", " 1,000", 
                "-23,000"
            };

            foreach (var value in validValues) {
                Assert.True(value.IsNumber(), string.Format("'{0}' should be valid number but now it is not.", value));
            }
        }

        [Fact]
        public void Test_IsNumber_for_invalid_strings() {
            var invalidValues = new string[] { 
                "1234sfds", "  1234...", "1234.3243.   ", "   $1234  ",
                "123.34.0", "-+2134", "++23.343", " 1,000,a", 
                "-23,000,.."
            };

            foreach (var value in invalidValues) {
                Assert.False(value.IsNumber(), string.Format("'{0}' should NOT be valid number but now it is.", value));
            }
        }

        [Fact]
        public void Test_IsNumber_with_NumberStyles_for_valid_strings() {
            var validValues = new string[] { 
                "1234", "  1234", "1234   ", "   1234  ",
                "+2134", "  -23343 "
            };

            foreach (var value in validValues) {
                Assert.True(value.IsNumber(NumberStyles.Integer), string.Format("'{0}' should be valid number but now it is not.", value));
            }
        }

        [Fact]
        public void Test_IsNumber_with_NumberStyles_for_invalid_strings() {
            var invalidValues = new string[] { 
                "1,000", "  1234.", "1234.32   ", "   $1234  "
            };

            foreach (var value in invalidValues) {
                Assert.False(value.IsNumber(NumberStyles.Integer), string.Format("'{0}' should NOT be valid number but now it is.", value));
            }
        }
    }
}
