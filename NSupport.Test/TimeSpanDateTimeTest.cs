namespace NSupport.Test {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Xunit;

    public class TimeSpanDateTimeTest {
        [Fact]
        public void Test_Ago() {            
            Assert.Equal(DateTime.Now.AddSeconds(-1), new TimeSpan(0, 0, 1).Ago()); // seconds
            Assert.Equal(DateTime.Now.AddMinutes(-1), new TimeSpan(0, 1, 0).Ago()); // minutes
            Assert.Equal(DateTime.Now.AddHours(-1), new TimeSpan(1, 0, 0).Ago()); // hourss
            Assert.Equal(DateTime.Now.AddDays(-1), new TimeSpan(1, 0, 0, 0).Ago()); // days            
        }

        [Fact]
        public void Test_FromNow() {
            Assert.Equal(DateTime.Now.AddSeconds(1), new TimeSpan(0, 0, 1).FromNow()); // seconds
            Assert.Equal(DateTime.Now.AddMinutes(1), new TimeSpan(0, 1, 0).FromNow()); // minutes
            Assert.Equal(DateTime.Now.AddHours(1), new TimeSpan(1, 0, 0).FromNow()); // hourss
            Assert.Equal(DateTime.Now.AddDays(1), new TimeSpan(1, 0, 0, 0).FromNow()); // days            
        }
    }
}
