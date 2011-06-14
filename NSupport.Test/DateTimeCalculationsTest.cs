namespace NSupport.Test {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Xunit;

    public class DateTimeCalculationsTest {
        [Fact]
        public void Test_Tomorrow() {
            Assert.Equal(new DateTime(2010, 6, 15), new DateTime(2010, 6, 14).Tomorrow());
            Assert.Equal(new DateTime(2010, 6, 1), new DateTime(2010, 5, 31).Tomorrow()); // between months
            Assert.Equal(new DateTime(2011, 1, 1), new DateTime(2010, 12, 31).Tomorrow()); // between years
        }

        [Fact]
        public void Test_Yesterday() {
            Assert.Equal(new DateTime(2010, 6, 13), new DateTime(2010, 6, 14).Yesterday());
            Assert.Equal(new DateTime(2010, 5, 31), new DateTime(2010, 6, 1).Yesterday()); // between months
            Assert.Equal(new DateTime(2010, 12, 31), new DateTime(2011, 1, 1).Yesterday()); // between years
        }

        [Fact]
        public void Test_NextYear() {
            Assert.Equal(new DateTime(2011, 1, 14), new DateTime(2010, 1, 14).NextYear());
        }

        [Fact]
        public void Test_PreviousYear() {
            Assert.Equal(new DateTime(2009, 1, 14), new DateTime(2010, 1, 14).PreviousYear());
        }

        [Fact]
        public void Test_NextMonth() {
            Assert.Equal(new DateTime(2010, 2, 14), new DateTime(2010, 1, 14).NextMonth());
            Assert.Equal(new DateTime(2011, 1, 14), new DateTime(2010, 12, 14).NextMonth()); // between years
        }

        [Fact]
        public void Test_PreviousMonth() {
            Assert.Equal(new DateTime(2010, 1, 14), new DateTime(2010, 2, 14).PreviousMonth());
            Assert.Equal(new DateTime(2009, 12, 14), new DateTime(2010, 1, 14).PreviousMonth()); // between years
        }
    }
}
