using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utility.ConvertTo.Tests
{
    [TestFixture()]
    public class DateTests
    {


        [TestCase("65/05/08", ExpectedResult = "1976/05/08")]
        [TestCase("65-05-08", ExpectedResult = "1976/05/08")]
        [TestCase("650508", ExpectedResult = "1976/05/08")]
        [TestCase("0650508", ExpectedResult = "1976/05/08")]
        public string ToDateTest(string twDate)
        {
            return twDate.ToDate().ToString("yyyy/MM/dd");
        }
    }
}