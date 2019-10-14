using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Common.Utility.ConvertTo
{
    public static class Date
    {
        private static readonly CultureInfo _taiwanDate = new CultureInfo("zh-TW");


        /// <summary>
        /// 將簡易民國日期字串(例:0640501)轉成西元日期類型，只處理日期，不處理時間
        /// </summary>
        /// <param name="obj">可處理為有分隔符號 / (64/05/01)或 - (64-05-01)，亦可處理連續年月日，如(640501)</param>        
        /// <returns>西元年</returns>
        public static DateTime ToDate(this string obj)
        {
            var tempDate = obj.Replace("/", "").Replace("-", "");

            if (tempDate.Length < 6)
            {
                throw new System.FormatException("無法處理小於6碼日期，請於年月日之前補零。");
            }

            if (tempDate.Length >= 6)
            {
                //先判斷是否含有非數值文字
                int rocDate = 0;
                int.TryParse(tempDate, out rocDate);
                if (rocDate != 0)
                {
                    tempDate = tempDate.PadLeft(7, '0');
                }
                else
                {
                    throw new System.FormatException("無法處理非數字字串。");
                }
            }

            _taiwanDate.DateTimeFormat.Calendar = new TaiwanCalendar();
            int year, month, day;
            year = Convert.ToInt32(tempDate.Substring(0, 3));

            if (year <= 0)
            {
                throw new System.FormatException("無法處理年號數小於等於0。");
            }

            month = Convert.ToInt32(tempDate.Substring(3, 2));
            if (month <= 0)
            {
                throw new System.FormatException("無法處理月份小於等於0。");
            }
            if (month > 12)
            {
                throw new System.FormatException("無法處理年號數大於等於12。");
            }
            day = Convert.ToInt32(tempDate.Substring(5, 2));

            if (day <= 0)
            {
                throw new System.FormatException("無法處理日數小於等於0。");
            }
            if (day > 31)
            {
                throw new System.FormatException("無法處理日數大於31。");
            }
            return DateTime.Parse(year + "/" + month + "/" + day, _taiwanDate).Date;
        }
        /// <summary>
        /// 將西元日期轉換成完整民國日期，不處理時間
        /// </summary>
        /// <param name="datetime">西元年</param>
        /// <returns>完整民國年，如 民國 XX 年 XX 年 XX 日</returns>
        public static string ToFullTaiwanDate(this DateTime datetime)
        {
            if (datetime == null)
            {
                return "";
            }
            TaiwanCalendar taiwanCalendar = new TaiwanCalendar();

            return string.Format("民國 {0} 年 {1} 月 {2} 日",
                taiwanCalendar.GetYear(datetime),
                datetime.Month,
                datetime.Day);
        }
        /// <summary>
        ///  將西元日期轉換成簡易民國日期，可指定輸出單純年、年月或年月日
        /// </summary>
        /// <param name="datetime">西元年</param>
        /// <param name="type">1=年,2=年月,3=年月日</param>
        /// <returns>簡易民國年，如 0640501，年數不滿3碼，會自動補零至3碼</returns>
        public static string ToSimpleTaiwanDate(this DateTime datetime, int type = 3)
        {
            if (datetime == null)
            {
                return "";
            }

            var datetimeParse = new DateTime();

            if (!DateTime.TryParse(datetime.ToShortDateString(), out datetimeParse))
            {
                return "";
            }

            TaiwanCalendar taiwanCalendar = new TaiwanCalendar();
            var year = taiwanCalendar.GetYear(datetime).ToString().Length <= 2 ? "0" + taiwanCalendar.GetYear(datetime).ToString() : taiwanCalendar.GetYear(datetime).ToString();
            var month = datetime.Month.ToString().Length <= 1 ? "0" + datetime.Month.ToString() : datetime.Month.ToString();
            var day = datetime.Day.ToString().Length <= 1 ? "0" + datetime.Day.ToString() : datetime.Day.ToString();
            switch (type)
            {
                case 1:
                    return string.Format("{0}", year);

                case 2:
                    return string.Format("{0}{1}", year, month);

                case 3:
                    return string.Format("{0}{1}{2}", year, month, day);
            }

            return string.Format("{0}{1}{2}", year, month, day);
        }

    }
}
