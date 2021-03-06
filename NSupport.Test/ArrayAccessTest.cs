﻿namespace NSupport.Test {
    using System;
    using Xunit;

    public class ArrayAccessTest {
        [Fact]
        public void Test_IndexOf_with_null() {
            int[] nullArray = null;
            Assert.Throws<ArgumentNullException>(() => nullArray.IndexOf(1));
        }

        [Fact]
        public void Test_IndexOf_with_existing_value() {
            var ints = new[] { 1, 2, 3, 4, 5, 1 };
            Assert.Equal(0, ints.IndexOf(1));
        }

        [Fact]
        public void Test_IndexOf_with_non_existing_value() {
            var ints = new[] { 1, 2, 3, 4, 5 };
            Assert.Equal(-1, ints.IndexOf(7));
        }

        [Fact]
        public void Test_LastIndexOf_with_null() {
            int[] nullArray = null;
            Assert.Throws<ArgumentNullException>(() => nullArray.LastIndexOf(1));
        }

        [Fact]
        public void Test_LastIndexOf_with_existing_value() {
            var ints = new[] { 1, 2, 3, 4, 5, 1 };
            Assert.Equal(5, ints.LastIndexOf(1));
        }

        [Fact]
        public void Test_LastIndexOf_with_non_existing_value() {
            var ints = new[] { 1, 2, 3, 4, 5, 1 };
            Assert.Equal(-1, ints.LastIndexOf(7));
        }

        [Fact]
        public void Test_Empty_with_null() {
            int[] ints = null;
            Assert.Throws<ArgumentNullException>(() => ints.Empty());
        }

        [Fact]
        public void Test_Empty_with_existing_value() {
            var ints = new[] { 1, 2, 3, 4, 5, 1 };

            var values = ints.Empty();

            Assert.NotEmpty(ints);
            Assert.Empty(values);
        }
    }
}
