using System;
using Xunit;
using DateRange;

namespace DataRange.Tests
{
    public class UnitTest1
    {

        [Theory]
        [InlineData("11")]
        [InlineData("11-06")]
        [InlineData("Ababa")]
        [InlineData("1231231")]
        [InlineData("2020")]
        [InlineData("")]
        [InlineData("11-12-13-2020")]
        [InlineData("11/23/10 05:21:50")]
        [InlineData("05:21:50")]
        [InlineData("3.05.2020")]
        [InlineData("03 May 2020")]
        public void ParseDate_WrongFormat(string date)
        {
            Assert.Throws<FormatException>(() => DateRange.Program.ParseDate(date));

        }
        [Theory]
        [InlineData("30.02.2020")]
        [InlineData("29.02.2013")]
        [InlineData("31.06.2013")]
        [InlineData("20.02.-1233")]
        [InlineData("13.-02.2013")]
        [InlineData("-29.01.2013")]
        [InlineData("00.01.2013")]
        [InlineData("01.00.2013")]
        [InlineData("01.01.0000")]
        public void ParseDate_IncorrectDate(string date)
        {
            Assert.Throws<FormatException>(() => DateRange.Program.ParseDate(date));
        }

        [Fact]
        public void FormatRange_CorrectFormating_DiffYears()
        {
            string result = DateRange.Program.FormatRange(DateTime.Parse("20.02.1997"), DateTime.Parse("30.06.1998"));

            Assert.Equal("20.02.1997 - 30.06.1998", result);
        }

        [Fact]
        public void FormatRange_CorrectFormating_DiffMonths()
        {
            string result = DateRange.Program.FormatRange(DateTime.Parse("20.02.1997"), DateTime.Parse("30.06.1997"));

            Assert.Equal("20.02 - 30.06.1997", result);
        }

        [Fact]
        public void FormatRange_CorrectFormating_DiffDays()
        {
            string result = DateRange.Program.FormatRange(DateTime.Parse("20.02.1997"), DateTime.Parse("28.02.1997"));

            Assert.Equal("20 - 28.02.1997", result);
        }
        [Fact]
        public void FormatRange_CorrectFormating_SameDay()
        {
            string result = DateRange.Program.FormatRange(DateTime.Parse("20.02.1997"), DateTime.Parse("20.02.1997"));

            Assert.Equal("20.02.1997", result);
        }
    }
}
    
