namespace NSupport.Test {
    using System;
    using Xunit;

    public class TimeSpanDateTimeTest {
        [Fact]
        public void Test_Ago() {            
            Assert.Equal(DateTime.Now.AddSeconds(-1), new TimeSpan(0, 0, 1).Ago()); // seconds
            Assert.Equal(DateTime.Now.AddMinutes(-1), new TimeSpan(0, 1, 0).Ago()); // minutes
            Assert.Equal(DateTime.Now.AddHours(-1), new TimeSpan(1, 0, 0).Ago()); // hours
            Assert.Equal(DateTime.Now.AddDays(-1), new TimeSpan(1, 0, 0, 0).Ago()); // days            
        }

        [Fact]
        public void Test_FromNow() {
            Assert.Equal(DateTime.Now.AddSeconds(1), new TimeSpan(0, 0, 1).FromNow()); // seconds
            Assert.Equal(DateTime.Now.AddMinutes(1), new TimeSpan(0, 1, 0).FromNow()); // minutes
            Assert.Equal(DateTime.Now.AddHours(1), new TimeSpan(1, 0, 0).FromNow()); // hours
            Assert.Equal(DateTime.Now.AddDays(1), new TimeSpan(1, 0, 0, 0).FromNow()); // days            
        }

        [Fact]
        public void Test_Until(){
            Assert.Equal(new DateTime(2011, 6, 15, 23, 59, 59), new TimeSpan(0, 0, 1).Until(new DateTime(2011, 6, 16))); // seconds
            Assert.Equal(new DateTime(2011, 6, 15, 23, 59, 0), new TimeSpan(0, 1, 0).Until(new DateTime(2011, 6, 16))); // minutes
            Assert.Equal(new DateTime(2011, 6, 15, 23, 0, 0), new TimeSpan(1, 0, 0).Until(new DateTime(2011, 6, 16))); // hours
            Assert.Equal(new DateTime(2011, 6, 15, 0, 0, 0), new TimeSpan(1, 0, 0, 0).Until(new DateTime(2011, 6, 16))); // days     
        }

        [Fact]
        public void Test_Since() {
            Assert.Equal(new DateTime(2011, 6, 16, 0, 0, 1), new TimeSpan(0, 0, 1).Since(new DateTime(2011, 6, 16))); // seconds
            Assert.Equal(new DateTime(2011, 6, 16, 0, 1, 0), new TimeSpan(0, 1, 0).Since(new DateTime(2011, 6, 16))); // minutes
            Assert.Equal(new DateTime(2011, 6, 16, 1, 0, 0), new TimeSpan(1, 0, 0).Since(new DateTime(2011, 6, 16))); // hours
            Assert.Equal(new DateTime(2011, 6, 17, 0, 0, 0), new TimeSpan(1, 0, 0, 0).Since(new DateTime(2011, 6, 16))); // days     
        }
    }
}
