namespace NSupport.Test {
    using Xunit;
    using System;

    public class StringHumanizationTest {
        [Fact]
        public void Test_TitleCase_with_null() {
            string nullValue = null;
            Assert.Throws<ArgumentNullException>(() => nullValue.ToTitleCase());
        }

        [Fact]
        public void Test_TitleCase_with_words() {
            var value = "war aNd peaCe";
            Assert.Equal("War And Peace", value.ToTitleCase());
        }

        [Fact]
        public void Test_TitleCase_with_all_uppercase() {
            var value = "WAR AND PEACE";
            Assert.Equal("War And Peace", value.ToTitleCase());
        }
    }
}
