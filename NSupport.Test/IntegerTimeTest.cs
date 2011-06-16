namespace NSupport.Test {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Xunit;

    public class IntegerTimeTest {
        [Fact]
        public void Test_Second() {
            Assert.Equal(new TimeSpan(0, 0, 1), 1.Second());
        }

        [Fact]
        public void Test_Seconds() {
            Assert.Equal(new TimeSpan(0, 0, 2), 2.Seconds());

            Assert.Equal(new TimeSpan(0, 0, 60), 60.Seconds());
        }

        [Fact]
        public void Test_Minute() {
            Assert.Equal(new TimeSpan(0, 1, 0), 1.Minute());
        }

        [Fact]
        public void Test_Minutes() {
            Assert.Equal(new TimeSpan(0, 2, 0), 2.Minutes());

            Assert.Equal(new TimeSpan(0, 60, 0), 60.Minutes());
        }

        [Fact]
        public void Test_Hour() {
            Assert.Equal(new TimeSpan(1, 0, 0), 1.Hour());
        }

        [Fact]
        public void Test_Hours() {
            Assert.Equal(new TimeSpan(2, 0, 0), 2.Hours());

            Assert.Equal(new TimeSpan(60, 0, 0), 60.Hours());
        }

        [Fact]
        public void Test_Day() {
            Assert.Equal(new TimeSpan(1, 0, 0, 0), 1.Day());
        }

        [Fact]
        public void Test_Days() {
            Assert.Equal(new TimeSpan(2, 0, 0, 0), 2.Days());

            Assert.Equal(new TimeSpan(60, 0, 0, 0), 60.Days());
        }

        [Fact]
        public void Test_Week() {
            Assert.Equal(new TimeSpan(7, 0, 0, 0), 1.Week());
        }

        [Fact]
        public void Test_Weeks() {
            Assert.Equal(new TimeSpan(14, 0, 0, 0), 2.Weeks());

            Assert.Equal(new TimeSpan(35, 0, 0, 0), 5.Weeks());
        }
    }
}
