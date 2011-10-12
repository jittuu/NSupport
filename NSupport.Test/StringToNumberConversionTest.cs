namespace NSupport.Test {
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Xunit;

    public class StringToNumberConversionTest {
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

        [Fact]
        public void Test_ToInt32_for_valid_strings() {
            var validValues = new Dictionary<string, int>() { 
                { "1234", 1234 }, 
                {"  1234", 1234 }, 
                {"1234   ", 1234 }, 
                {"   1234  ", 1234},
                {"+1234", 1234}, 
                {"  -1234  ", -1234}
            };

            foreach (var kv in validValues) {
                Assert.Equal(kv.Value, kv.Key.ToInt32());
            }
        }

        [Fact]
        public void Test_ToInt32_for_invalid_strings() {            
            var invalidValues = new string[] { 
                "1,000", "  1234.", "1234.32   ", "   $1234  "
            };

            foreach (var value in invalidValues) {
                Assert.Throws<FormatException>(() => {
                    value.ToInt32();
                });
            }
        }

        [Fact]
        public void Test_ToInt32_with_NumberStyles_for_valid_strings() {
            var validValues = new Tuple<string, NumberStyles, int>[]{ 
                new Tuple<string, NumberStyles, int>("123.0", NumberStyles.AllowDecimalPoint, 
                    123),
                new Tuple<string, NumberStyles, int>("$123", NumberStyles.AllowCurrencySymbol, 
                    123),
                new Tuple<string, NumberStyles, int>("$123.0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol, 
                    123),
            };

            foreach (var value in validValues) {
                Assert.Equal(value.Item3, value.Item1.ToInt32(value.Item2));
            }
        }

        [Fact]
        public void Test_ToInt32_with_NumberStyles_for_invalid_strings() {
            var invalidValues = new Dictionary<string, NumberStyles> { 
                { "$123.0", NumberStyles.AllowDecimalPoint },
                { "123.0", NumberStyles.AllowCurrencySymbol },
                { "+123.0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol }
            };

            foreach (var kv in invalidValues) {
                Assert.Throws<FormatException>(() => {
                    kv.Key.ToInt32(kv.Value);
                });
            }
        }

        [Fact]
        public void Test_AsInt32_for_valid_strings() {
            var validValues = new Dictionary<string, int>() { 
                { "1234", 1234 }, 
                {"  1234", 1234 }, 
                {"1234   ", 1234 }, 
                {"   1234  ", 1234},
                {"+1234", 1234}, 
                {"  -1234  ", -1234}
            };

            foreach (var kv in validValues) {
                Assert.Equal(kv.Value, kv.Key.AsInt32());
            }
        }

        [Fact]
        public void Test_AsInt32_for_invalid_strings() {
            var invalidValues = new string[] { 
                "1,000", "  1234.", "1234.32   ", "   $1234  "
            };

            foreach (var value in invalidValues) {
                Assert.Null(value.AsInt32());
            }
        }

        [Fact]
        public void Test_AsInt32_with_NumberStyles_for_valid_strings() {
            var validValues = new Tuple<string, NumberStyles, int>[]{ 
                new Tuple<string, NumberStyles, int>("123.0", NumberStyles.AllowDecimalPoint, 
                    123),
                new Tuple<string, NumberStyles, int>("$123", NumberStyles.AllowCurrencySymbol, 
                    123),
                new Tuple<string, NumberStyles, int>("$123.0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol, 
                    123),
            };

            foreach (var value in validValues) {
                Assert.Equal(value.Item3, value.Item1.AsInt32(value.Item2));
            }
        }

        [Fact]
        public void Test_AsInt32_with_NumberStyles_for_invalid_strings() {
            var invalidValues = new Dictionary<string, NumberStyles> { 
                { "$123.0", NumberStyles.AllowDecimalPoint },
                { "123.0", NumberStyles.AllowCurrencySymbol },
                { "+123.0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol }
            };

            foreach (var kv in invalidValues) {
                Assert.Null(kv.Key.AsInt32(kv.Value));
            }
        }

        [Fact]
        public void Test_ToInt64_for_valid_strings() {
            var validValues = new Dictionary<string, long>() { 
                { "1234", 1234 }, 
                {"  1234", 1234 }, 
                {"1234   ", 1234 }, 
                {"   1234  ", 1234},
                {"+1234", 1234}, 
                {"  -1234  ", -1234},
                {"9223372036854", 9223372036854}
            };

            foreach (var kv in validValues) {
                Assert.Equal(kv.Value, kv.Key.ToInt64());
            }
        }

        [Fact]
        public void Test_ToInt64_for_invalid_strings() {
            var invalidValues = new string[] { 
                "1,000", "  1234.", "1234.32   ", "   $1234  "
            };

            foreach (var value in invalidValues) {
                Assert.Throws<FormatException>(() => {
                    value.ToInt64();
                });
            }
        }

        [Fact]
        public void Test_ToInt64_with_NumberStyles_for_valid_strings() {
            var validValues = new Tuple<string, NumberStyles, long>[]{ 
                new Tuple<string, NumberStyles, long>("123.0", NumberStyles.AllowDecimalPoint, 
                    123),
                new Tuple<string, NumberStyles, long>("$9223372036854", NumberStyles.AllowCurrencySymbol, 
                    9223372036854),
                new Tuple<string, NumberStyles, long>("$123.0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol, 
                    123),
            };

            foreach (var value in validValues) {
                Assert.Equal(value.Item3, value.Item1.ToInt64(value.Item2));
            }
        }

        [Fact]
        public void Test_ToInt64_with_NumberStyles_for_invalid_strings() {
            var invalidValues = new Dictionary<string, NumberStyles> { 
                { "$123.0", NumberStyles.AllowDecimalPoint },
                { "123.0", NumberStyles.AllowCurrencySymbol },
                { "+9223372036854.0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol }
            };

            foreach (var kv in invalidValues) {
                Assert.Throws<FormatException>(() => {
                    kv.Key.ToInt64(kv.Value);
                });
            }
        }

        [Fact]
        public void Test_AsInt64_for_valid_strings() {
            var validValues = new Dictionary<string, long>() { 
                { "1234", 1234 }, 
                {"  1234", 1234 }, 
                {"1234   ", 1234 }, 
                {"   1234  ", 1234},
                {"+1234", 1234}, 
                {"  -9223372036854  ", -9223372036854}
            };

            foreach (var kv in validValues) {
                Assert.Equal(kv.Value, kv.Key.AsInt64());
            }
        }

        [Fact]
        public void Test_AsInt64_for_invalid_strings() {
            var invalidValues = new string[] { 
                "1,000", "  1234.", "1234.32   ", "   $9223372036854  "
            };

            foreach (var value in invalidValues) {
                Assert.Null(value.AsInt64());
            }
        }

        [Fact]
        public void Test_AsInt64_with_NumberStyles_for_valid_strings() {
            var validValues = new Tuple<string, NumberStyles, long>[]{ 
                new Tuple<string, NumberStyles, long>("123.0", NumberStyles.AllowDecimalPoint, 
                    123),
                new Tuple<string, NumberStyles, long>("$123", NumberStyles.AllowCurrencySymbol, 
                    123),
                new Tuple<string, NumberStyles, long>("$9223372036854.0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol, 
                    9223372036854),
            };

            foreach (var value in validValues) {
                Assert.Equal(value.Item3, value.Item1.AsInt64(value.Item2));
            }
        }

        [Fact]
        public void Test_AsInt64_with_NumberStyles_for_invalid_strings() {
            var invalidValues = new Dictionary<string, NumberStyles> { 
                { "$123.0", NumberStyles.AllowDecimalPoint },
                { "123.0", NumberStyles.AllowCurrencySymbol },
                { "+9223372036854.0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol }
            };

            foreach (var kv in invalidValues) {
                Assert.Null(kv.Key.AsInt64(kv.Value));
            }
        }
    }
}
