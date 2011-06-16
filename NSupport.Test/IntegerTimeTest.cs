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
    }
}
