namespace NSupport.Test {
    using System;
    using Xunit;

    public class DateTimeOffsetCalculationsTest {
        [Fact]
        public void Test_Tomorrow() {
            Assert.Equal(new DateTimeOffset(2010, 6, 15, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 6, 14, 0, 0, 0, TimeSpan.Zero).Tomorrow());
            Assert.Equal(new DateTimeOffset(2010, 6, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 5, 31, 0, 0, 0, TimeSpan.Zero).Tomorrow()); // between months
            Assert.Equal(new DateTimeOffset(2011, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 12, 31, 0, 0, 0, TimeSpan.Zero).Tomorrow()); // between years
        }

        [Fact]
        public void Test_Yesterday() {
            Assert.Equal(new DateTimeOffset(2010, 6, 13, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 6, 14, 0, 0, 0, TimeSpan.Zero).Yesterday());
            Assert.Equal(new DateTimeOffset(2010, 5, 31, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 6, 1, 0, 0, 0, TimeSpan.Zero).Yesterday()); // between months
            Assert.Equal(new DateTimeOffset(2010, 12, 31, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 1, 1, 0, 0, 0, TimeSpan.Zero).Yesterday()); // between years
        }

        [Fact]
        public void Test_NextYear() {
            Assert.Equal(new DateTimeOffset(2011, 1, 14, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 14, 0, 0, 0, TimeSpan.Zero).NextYear());
        }

        [Fact]
        public void Test_PreviousYear() {
            Assert.Equal(new DateTimeOffset(2009, 1, 14, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 14, 0, 0, 0, TimeSpan.Zero).PreviousYear());
        }

        [Fact]
        public void Test_NextMonth() {
            Assert.Equal(new DateTimeOffset(2010, 2, 14, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 14, 0, 0, 0, TimeSpan.Zero).NextMonth());
            Assert.Equal(new DateTimeOffset(2011, 1, 14, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 12, 14, 0, 0, 0, TimeSpan.Zero).NextMonth()); // between years
        }

        [Fact]
        public void Test_PreviousMonth() {
            Assert.Equal(new DateTimeOffset(2010, 1, 14, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 2, 14, 0, 0, 0, TimeSpan.Zero).PreviousMonth());
            Assert.Equal(new DateTimeOffset(2009, 12, 14, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 14, 0, 0, 0, TimeSpan.Zero).PreviousMonth()); // between years
        }

        [Fact]
        public void Test_BeginningOfDay() {
            Assert.Equal(new DateTimeOffset(2011, 6, 14, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 6, 14, 10, 0, 0, TimeSpan.Zero).BeginningOfDay());
        }

        [Fact]
        public void Test_Midnight() {
            Assert.Equal(new DateTimeOffset(2011, 6, 14, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 6, 14, 10, 0, 0, TimeSpan.Zero).Midnight());
        }

        [Fact]
        public void Test_EndOfDay() {
            Assert.Equal(new DateTimeOffset(2011, 6, 14, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 6, 14, 10, 0, 0, TimeSpan.Zero).EndOfDay());
        }

        [Fact]
        public void Test_BeginningOfMonth() {
            Assert.Equal(new DateTimeOffset(2011, 6, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 6, 14, 10, 0, 0, TimeSpan.Zero).BeginningOfMonth());
        }

        [Fact]
        public void Test_EndOfMonth() {
            Assert.Equal(new DateTimeOffset(2011, 6, 30, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 6, 14, 10, 0, 0, TimeSpan.Zero).EndOfMonth());
        }

        [Fact]
        public void Test_BeginningOfYear() {
            Assert.Equal(new DateTimeOffset(2011, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 6, 14, 10, 0, 0, TimeSpan.Zero).BeginningOfYear());
        }

        [Fact]
        public void Test_EndOfYear() {
            Assert.Equal(new DateTimeOffset(2011, 12, 31, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 6, 14, 10, 0, 0, TimeSpan.Zero).EndOfYear());
        }

        [Fact]
        public void Test_BeginningOfWeek() {
            Assert.Equal(new DateTimeOffset(2011, 6, 12, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 6, 14, 10, 0, 0, TimeSpan.Zero).BeginningOfWeek());
        }

        [Fact]
        public void Test_BeginningOfWeek_with_custom_FirstDayOfWeek_culture() {
            var currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;

            var culture = new System.Globalization.CultureInfo("en-US", true);
            culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

            Assert.Equal(new DateTimeOffset(2011, 6, 13, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 6, 14, 10, 0, 0, TimeSpan.Zero).BeginningOfWeek());

            System.Threading.Thread.CurrentThread.CurrentCulture = currentCulture; // reset to currentCulture
        }

        [Fact]
        public void Test_EndOfWeek() {
            Assert.Equal(new DateTimeOffset(2011, 6, 18, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 6, 14, 10, 0, 0, TimeSpan.Zero).EndOfWeek());
        }

        [Fact]
        public void Test_EndOfWeek_with_custom_FirstDayOfWeek_culture() {
            var currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;

            var culture = new System.Globalization.CultureInfo("en-US", true);
            culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

            Assert.Equal(new DateTimeOffset(2011, 6, 19, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 6, 14, 10, 0, 0, TimeSpan.Zero).EndOfWeek());

            System.Threading.Thread.CurrentThread.CurrentCulture = currentCulture; // reset to currentCulture
        }

        [Fact]
        public void Test_NextWeek() {
            Assert.Equal(new DateTimeOffset(2011, 6, 21, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 6, 14, 10, 0, 0, TimeSpan.Zero).NextWeek());
        }

        [Fact]
        public void Test_NextWeek_with_day() {
            Assert.Equal(new DateTimeOffset(2011, 6, 23, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 6, 14, 10, 0, 0, TimeSpan.Zero).NextWeek(day: DayOfWeek.Thursday));
        }

        [Fact]
        public void Test_BeginningOfQuarter() {
            // first quarter
            Assert.Equal(new DateTimeOffset(2011, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 1, 14, 10, 0, 0, TimeSpan.Zero).BeginningOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 2, 23, 10, 0, 0, TimeSpan.Zero).BeginningOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 3, 31, 10, 0, 0, TimeSpan.Zero).BeginningOfQuarter());

            // second quarter
            Assert.Equal(new DateTimeOffset(2011, 4, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 4, 14, 10, 0, 0, TimeSpan.Zero).BeginningOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 4, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 5, 23, 10, 0, 0, TimeSpan.Zero).BeginningOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 4, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 6, 30, 10, 0, 0, TimeSpan.Zero).BeginningOfQuarter());

            // third quarter
            Assert.Equal(new DateTimeOffset(2011, 7, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 7, 14, 10, 0, 0, TimeSpan.Zero).BeginningOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 7, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 8, 23, 10, 0, 0, TimeSpan.Zero).BeginningOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 7, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 9, 30, 10, 0, 0, TimeSpan.Zero).BeginningOfQuarter());

            // last quarter
            Assert.Equal(new DateTimeOffset(2011, 10, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 10, 14, 10, 0, 0, TimeSpan.Zero).BeginningOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 10, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 11, 23, 10, 0, 0, TimeSpan.Zero).BeginningOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 10, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 12, 31, 10, 0, 0, TimeSpan.Zero).BeginningOfQuarter());
        }

        [Fact]
        public void Test_EndOfQuarter() {
            // first quarter
            Assert.Equal(new DateTimeOffset(2011, 3, 31, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 1, 14, 10, 0, 0, TimeSpan.Zero).EndOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 3, 31, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 2, 23, 10, 0, 0, TimeSpan.Zero).EndOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 3, 31, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 3, 31, 10, 0, 0, TimeSpan.Zero).EndOfQuarter());

            // second quarter
            Assert.Equal(new DateTimeOffset(2011, 6, 30, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 4, 14, 10, 0, 0, TimeSpan.Zero).EndOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 6, 30, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 5, 23, 10, 0, 0, TimeSpan.Zero).EndOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 6, 30, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 6, 30, 10, 0, 0, TimeSpan.Zero).EndOfQuarter());

            // third quarter
            Assert.Equal(new DateTimeOffset(2011, 9, 30, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 7, 14, 10, 0, 0, TimeSpan.Zero).EndOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 9, 30, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 8, 23, 10, 0, 0, TimeSpan.Zero).EndOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 9, 30, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 9, 30, 10, 0, 0, TimeSpan.Zero).EndOfQuarter());

            // last quarter
            Assert.Equal(new DateTimeOffset(2011, 12, 31, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 10, 14, 10, 0, 0, TimeSpan.Zero).EndOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 12, 31, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 11, 23, 10, 0, 0, TimeSpan.Zero).EndOfQuarter());
            Assert.Equal(new DateTimeOffset(2011, 12, 31, 23, 59, 59, TimeSpan.Zero), new DateTimeOffset(2011, 12, 31, 10, 0, 0, TimeSpan.Zero).EndOfQuarter());
        }

        [Fact]
        public void Test_IsFuture() {
            Assert.Equal(true, DateTimeOffset.Now.AddDays(1).IsFuture());
            // single test should not longer than 5 seconds
            // if test is inconsistence, need to revisit this assert
            Assert.Equal(true, DateTimeOffset.Now.AddSeconds(5).IsFuture());

            Assert.Equal(false, DateTimeOffset.Now.IsFuture());
            Assert.Equal(false, new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero).IsFuture());
        }

        [Fact]
        public void Test_IsPast() {
            Assert.Equal(true, new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero).IsPast());
            Assert.Equal(true, DateTimeOffset.Now.AddDays(-1).IsPast());
            // single test should not longer than 5 seconds
            // if test is inconsistence, need to revisit this assert
            Assert.Equal(true, DateTimeOffset.Now.AddSeconds(-5).IsPast());

            Assert.Equal(false, DateTimeOffset.Now.IsPast());
            Assert.Equal(false, new DateTimeOffset(2100, 1, 1, 0, 0, 0, TimeSpan.Zero).IsPast());
        }

        [Fact]
        public void Test_Advance() {
            // with years
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2009, 1, 1, 0, 0, 0, TimeSpan.Zero).Advance(years: 1));

            // with months
            Assert.Equal(new DateTimeOffset(2010, 2, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero).Advance(months: 1));
            Assert.Equal(new DateTimeOffset(2011, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 11, 1, 0, 0, 0, TimeSpan.Zero).Advance(months: 2)); // between years

            // with days
            Assert.Equal(new DateTimeOffset(2010, 1, 3, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero).Advance(days: 2));
            Assert.Equal(new DateTimeOffset(2010, 2, 2, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 31, 0, 0, 0, TimeSpan.Zero).Advance(days: 2)); // between months
            Assert.Equal(new DateTimeOffset(2011, 1, 2, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 12, 31, 0, 0, 0, TimeSpan.Zero).Advance(days: 2)); // between years

            // with hours
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 2, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero).Advance(hours: 2));
            Assert.Equal(new DateTimeOffset(2010, 1, 2, 1, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 23, 0, 0, TimeSpan.Zero).Advance(hours: 2)); // between days
            Assert.Equal(new DateTimeOffset(2010, 2, 1, 1, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 31, 23, 0, 0, TimeSpan.Zero).Advance(hours: 2)); // between months
            Assert.Equal(new DateTimeOffset(2011, 1, 1, 1, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 12, 31, 23, 0, 0, TimeSpan.Zero).Advance(hours: 2)); // between years

            // with minutes
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 0, 20, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero).Advance(minutes: 20));
            Assert.Equal(new DateTimeOffset(2010, 1, 2, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 23, 40, 0, TimeSpan.Zero).Advance(minutes: 20)); // between hours
            Assert.Equal(new DateTimeOffset(2010, 1, 2, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 23, 40, 0, TimeSpan.Zero).Advance(minutes: 20)); // between days
            Assert.Equal(new DateTimeOffset(2010, 2, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 31, 23, 40, 0, TimeSpan.Zero).Advance(minutes: 20)); // between months
            Assert.Equal(new DateTimeOffset(2011, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 12, 31, 23, 40, 0, TimeSpan.Zero).Advance(minutes: 20)); // between years

            // with seconds
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 0, 0, 20, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero).Advance(seconds: 20));
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 23, 1, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 23, 0, 40, TimeSpan.Zero).Advance(seconds: 20)); // between minutes
            Assert.Equal(new DateTimeOffset(2010, 1, 2, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 23, 59, 40, TimeSpan.Zero).Advance(seconds: 20)); // between hours
            Assert.Equal(new DateTimeOffset(2010, 1, 2, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 23, 59, 40, TimeSpan.Zero).Advance(seconds: 20)); // between days
            Assert.Equal(new DateTimeOffset(2010, 2, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 31, 23, 59, 40, TimeSpan.Zero).Advance(seconds: 20)); // between months
            Assert.Equal(new DateTimeOffset(2011, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 12, 31, 23, 59, 40, TimeSpan.Zero).Advance(seconds: 20)); // between years
        }

        [Fact]
        public void Test_Ago() {
            // with years
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 1, 1, 0, 0, 0, TimeSpan.Zero).Ago(years: 1));

            // with months
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 2, 1, 0, 0, 0, TimeSpan.Zero).Ago(months: 1));
            Assert.Equal(new DateTimeOffset(2010, 11, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 1, 1, 0, 0, 0, TimeSpan.Zero).Ago(months: 2)); // between years

            // with days
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 3, 0, 0, 0, TimeSpan.Zero).Ago(days: 2));
            Assert.Equal(new DateTimeOffset(2010, 1, 31, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 2, 2, 0, 0, 0, TimeSpan.Zero).Ago(days: 2)); // between months
            Assert.Equal(new DateTimeOffset(2010, 12, 31, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 1, 2, 0, 0, 0, TimeSpan.Zero).Ago(days: 2)); // between years

            // with hours
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 2, 0, 0, TimeSpan.Zero).Ago(hours: 2));
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 23, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 2, 1, 0, 0, TimeSpan.Zero).Ago(hours: 2)); // between days
            Assert.Equal(new DateTimeOffset(2010, 1, 31, 23, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 2, 1, 1, 0, 0, TimeSpan.Zero).Ago(hours: 2)); // between months
            Assert.Equal(new DateTimeOffset(2010, 12, 31, 23, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 1, 1, 1, 0, 0, TimeSpan.Zero).Ago(hours: 2)); // between years

            // with minutes
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 0, 20, 0, TimeSpan.Zero).Ago(minutes: 20));
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 23, 40, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 2, 0, 0, 0, TimeSpan.Zero).Ago(minutes: 20)); // between hours
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 23, 40, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 2, 0, 0, 0, TimeSpan.Zero).Ago(minutes: 20)); // between days
            Assert.Equal(new DateTimeOffset(2010, 1, 31, 23, 40, 0, TimeSpan.Zero), new DateTimeOffset(2010, 2, 1, 0, 0, 0, TimeSpan.Zero).Ago(minutes: 20)); // between months
            Assert.Equal(new DateTimeOffset(2010, 12, 31, 23, 40, 0, TimeSpan.Zero), new DateTimeOffset(2011, 1, 1, 0, 0, 0, TimeSpan.Zero).Ago(minutes: 20)); // between years

            // with seconds
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 0, 0, 20, TimeSpan.Zero).Ago(seconds: 20));
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 23, 0, 40, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 23, 1, 0, TimeSpan.Zero).Ago(seconds: 20)); // between minutes
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 23, 59, 40, TimeSpan.Zero), new DateTimeOffset(2010, 1, 2, 0, 0, 0, TimeSpan.Zero).Ago(seconds: 20)); // between hours
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 23, 59, 40, TimeSpan.Zero), new DateTimeOffset(2010, 1, 2, 0, 0, 0, TimeSpan.Zero).Ago(seconds: 20)); // between days
            Assert.Equal(new DateTimeOffset(2010, 1, 31, 23, 59, 40, TimeSpan.Zero), new DateTimeOffset(2010, 2, 1, 0, 0, 0, TimeSpan.Zero).Ago(seconds: 20)); // between months
            Assert.Equal(new DateTimeOffset(2010, 12, 31, 23, 59, 40, TimeSpan.Zero), new DateTimeOffset(2011, 1, 1, 0, 0, 0, TimeSpan.Zero).Ago(seconds: 20)); // between years
        }

        [Fact]
        public void Test_Change() {
            // with years
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 1, 1, 0, 0, 0, TimeSpan.Zero).Change(years: 2010));

            // with months
            Assert.Equal(new DateTimeOffset(2010, 10, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero).Change(months: 10));

            // with days
            Assert.Equal(new DateTimeOffset(2010, 1, 10, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero).Change(days: 10));

            // with hours
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 10, 0, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero).Change(hours: 10));

            // with minutes
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 0, 10, 0, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero).Change(minutes: 10));

            // with seconds
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 0, 0, 10, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero).Change(seconds: 10));

            // with milliseconds
            Assert.Equal(new DateTimeOffset(2010, 1, 1, 0, 0, 0, 100, TimeSpan.Zero), new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero).Change(milliseconds: 100));
        }
    }
}
