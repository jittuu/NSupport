namespace NSupport.Test {
    using System;
    using System.Globalization;
    using Xunit;
    
    public class StringFormattingTest {
        [Fact]
        public void Test_FormatWith() {
            Assert.Equal("This is formatting integer 1 with {1:00}: 02", "This is formatting integer {0} with {{1:00}}: {1:00}".FormatWith(1, 2));
        }

        [Fact]
        public void Test_FormatWith_with_culture() {
            var july15 = new DateTime(2011, 7, 15);
            Assert.Equal("Date in ja-JP: 2011/07/15", "Date in ja-JP: {0:d}".FormatWith(new CultureInfo("ja-JP"), july15));
        }
    }
}
