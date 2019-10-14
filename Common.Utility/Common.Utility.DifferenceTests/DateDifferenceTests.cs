using NUnit.Framework;
using Common.Utility.Difference;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utility.Difference.Tests
{
    [TestFixture()]
    public class DateDifferenceTests
    {
        [TestCase(1925, 11, 15, 1925, 11, 25, ExpectedResult = 0)]
        [TestCase(1925, 12, 01, 1926, 1, 30, ExpectedResult = 1)]

        public int MonthsDifferenceTest(int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay)
        {
            var startDate = new DateTime(startYear, startMonth, startDay);
            var endDate = new DateTime(endYear, endMonth, endDay);
            var result = startDate.MonthsDifference(endDate);
            return result;
        }
    }
}