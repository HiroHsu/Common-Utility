using System;

namespace Common.Utility.Difference
{
    public static class DateDifference
    {
        /// <summary>
        /// 計算兩個日期之間的月份數
        /// </summary>
        /// <param name="StartDate">比對基準日期</param>
        /// <param name="EndDate">比對差異目標日期</param>
        /// <returns></returns>
        public static int MonthsDifference(this DateTime StartDate, DateTime EndDate)
        {
            //                        24216     +      5         -      24216 + 4
            int totalMonth = (EndDate.Year * 12 + EndDate.Month) - (StartDate.Year * 12 + StartDate.Month);

            return totalMonth;

        }
    }
}
